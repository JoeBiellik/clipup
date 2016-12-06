using System;
using Newtonsoft.Json;

namespace ClipUp.Sdk.Interfaces
{
    public interface IUploadProvider : ICloneable
    {
        [JsonIgnore]
        string Name { get; }

        [JsonIgnore]
        Version Version { get; }

        [JsonIgnore]
        string Link { get; }

        [JsonIgnore]
        string Description { get; }

        [JsonIgnore]
        long MaxSize { get; }
    }
}
