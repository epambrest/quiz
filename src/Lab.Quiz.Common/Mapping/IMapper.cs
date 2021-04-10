namespace Lab.Quiz.Common.Mapping
{
    /// <summary>
    /// The common interface for mapping models.
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Create a new equivalent destination model from the source model, based on provided types.
        /// </summary>
        /// <typeparam name="TSource">The source model type to map from.</typeparam>
        /// <typeparam name="TDestination">The destination model type to create.</typeparam>
        /// <param name="source">The source model to map from.</param>
        /// <returns>New object equivalent to the source model.</returns>
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
