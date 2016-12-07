using System;
using Newtonsoft.Json;

namespace ClipUp.Sdk.Interfaces
{
    /// <summary>
    /// Interface implemented by all upload providers.
    /// </summary>
    public interface IUploadProvider : ICloneable
    {
        /// <summary>
        /// Gets the name of the upload provider.
        /// </summary>
        /// <value>The provider name.</value>
        [JsonIgnore]
        string Name { get; }

        /// <summary>
        /// Gets the version of the upload provider.
        /// </summary>
        /// <value>The provider version.</value>
        [JsonIgnore]
        Version Version { get; }

        /// <summary>
        /// Gets the full website URL of the upload provider.
        /// </summary>
        /// <value>The provider website.</value>
        [JsonIgnore]
        string Link { get; }

        /// <summary>
        /// Gets the description of the upload provider.
        /// </summary>
        /// <value>The provider description.</value>
        [JsonIgnore]
        string Description { get; }

        /// <summary>
        /// Gets the maximum upload size supported by the upload provider.
        /// </summary>
        /// <value>The maximum supported upload size in bytes.</value>
        [JsonIgnore]
        long MaxSize { get; }
    }
}
