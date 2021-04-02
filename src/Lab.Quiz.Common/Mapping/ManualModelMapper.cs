using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Quiz.Common.Mapping
{
    /// <inheritdoc />
    public class ManualModelMapper : IMapper
    {
        private readonly ICollection<IManualMapperProfile> _profiles;

        public ManualModelMapper(ICollection<IManualMapperProfile> profiles)
        {
            _profiles = profiles;
        }

        /// <inheritdoc />
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var profile = _profiles
                .OfType<IManualMapperProfile<TSource, TDestination>>()
                .FirstOrDefault();

            if (profile == null)
                throw new NotSupportedException($"Mapping from type {typeof(TSource).FullName} to {typeof(TSource)} is not supported. Required profile is missed.");

            if (source == null)
                return default;

            return profile.MapManual(source);
        }
    }
}
