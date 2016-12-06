using System.Windows.Forms;

namespace ClipUp.Sdk.Interfaces
{
    public interface IConfigurableProvider
    {
        void Configure(Control.ControlCollection controls);
    }
}
