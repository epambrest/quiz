namespace Lab.Quiz.Common.Mapping
{
    /// <summary>
    /// The base interface for manual mapper profile.
    /// </summary>
    public interface IManualMapperProfile
    {
    }

    /// <summary>
    /// The interface for custom profiles which allows to perform manual mapping.
    /// </summary>
    /// <typeparam name="TSource">The source model.</typeparam>
    /// <typeparam name="TDestination">The destination model.</typeparam>
    public interface IManualMapperProfile<TSource, TDestination> : IManualMapperProfile
    {
        /// <summary>
        /// Supposed to be executed every time when appropriate mapping required.
        /// </summary>
        /// <param name="source">The source model.</param>
        /// <returns>The destination model.</returns>
        TDestination MapManual(TSource source);
    }
}