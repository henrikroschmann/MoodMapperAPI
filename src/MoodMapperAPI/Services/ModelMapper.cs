namespace MoodMapperAPI.Services;

public class ModelMapper : IModelMapper
{
    public TTarget MapToModel<TTarget, TSource>(TSource source) where TTarget : class, new()
    {
        var target = new TTarget();
        var sourceProperties = typeof(TSource).GetProperties();
        var targetProperties = typeof(TTarget).GetProperties();

        foreach (var sourceProperty in sourceProperties)
        {
            var targetProperty = targetProperties.FirstOrDefault(p => p.Name == sourceProperty.Name);
            if (targetProperty == null) continue;

            if (!targetProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType)) continue;

            try
            {
                var value = sourceProperty.GetValue(source);
                targetProperty.SetValue(target, value);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error mapping property {sourceProperty.Name}: {ex.Message}");  
            }
        }

        return target;
    }

}
