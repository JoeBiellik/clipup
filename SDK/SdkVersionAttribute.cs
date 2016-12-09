using System;

namespace ClipUp.Sdk
{
    /// <summary>
    /// Specifies the SDK version number the assembly was built against.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class SdkVersionAttribute : Attribute
    {
        /// <summary>
        /// Gets the target SDK version number.
        /// </summary>
        public uint Target { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SdkVersionAttribute"/> class.
        /// </summary>
        public SdkVersionAttribute() : this(0) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SdkVersionAttribute"/> class.
        /// </summary>
        /// <param name="target">The target SDK version number.</param>
        public SdkVersionAttribute(uint target)
        {
            this.Target = target;
        }
    }
}
