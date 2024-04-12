namespace MoodMapperAPI.Abstractions
{
    public interface IModelMapper
    {
        TTarget MapToModel<TTarget, TSource>(TSource source) where TTarget : class, new();
    }
}