using System.Windows.Forms;

namespace ClipUp.Sdk.Interfaces
{
    /// <summary>
     /// Interface implemented by all providers supporting runtime user configuration.
     /// <seealso cref="IUploadProvider"/>
     /// </summary>
    public interface IConfigurableProvider
    {
        /// <summary>
        /// Collect visual controls which will be displayed to the user for configuration.
        /// </summary>
        /// <param name="controls">The collection to be filled with controls which will be displayed to the user.</param>
        void Configure(Control.ControlCollection controls);
    }
}
