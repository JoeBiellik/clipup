using System;
using System.Drawing;
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
        string Website { get; }

        /// <summary>
        /// Gets the description of the upload provider.
        /// </summary>
        /// <value>The provider description.</value>
        [JsonIgnore]
        string Description { get; }

        /// <summary>
        /// Gets the icon of the upload provider.
        /// </summary>
        /// <value>The provider icon.</value>
        [JsonIgnore]
        Icon Icon { get; }

        /// <summary>
        /// Gets the name of the provider author.
        /// </summary>
        /// <value>The provider author name.</value>
        [JsonIgnore]
        string AuthorName { get; }

        /// <summary>
        /// Gets the website of the provider author.
        /// </summary>
        /// <value>The provider author website.</value>
        [JsonIgnore]
        string AuthorWebsite { get; }

        /// <summary>
        /// Gets the maximum upload size supported by the upload provider.
        ///
        /// Set to -1 to disable limit.
        /// </summary>
        /// <value>The maximum supported upload size in bytes.</value>
        [JsonIgnore]
        long MaxSize { get; }
    }
}
