using System;

namespace ClipUp.Sdk.Providers
{
    /// <summary>
    /// Thrown when provider SDK version number doesn't match current SDK version number.
    /// </summary>
    public class ProviderSdkVersionException : Exception
    {
        /// <summary>
        /// Gets the provider file that had the incorrect target SDK version number.
        /// </summary>
        public string File { get; protected set; }

        /// <summary>
        /// Gets the target SDK version number.
        /// </summary>
        public uint Version { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderSdkVersionException"/> class.
        /// </summary>
        /// <param name="file">The provider file that was being loaded.</param>
        public ProviderSdkVersionException(string file) : base($"Unable to load provider \"{file}\" as it was built without an SDK target version.")
        {
            this.File = file;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderSdkVersionException"/> class.
        /// </summary>
        /// <param name="file">The provider file that was being loaded.</param>
        /// <param name="version">The SDK version the provider was built against.</param>
        public ProviderSdkVersionException(string file, uint version) : base($"Unable to load provider \"{file}\" as it was built against the wrong SDK version (target version {version}, current version {UploadProvider.SDK_VERSION}).")
        {
            this.File = file;
            this.Version = version;
        }
    }
}
