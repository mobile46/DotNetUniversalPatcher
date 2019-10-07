using dnlib.DotNet.Emit;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel;

namespace DotNetUniversalPatcher.Models
{
    public class Target
    {
        public string FullName { get; set; }

        [JsonIgnore]
        public Instruction[] Instructions { get; set; }

        [JsonProperty("Instructions")]
        public List<ILCode> ILCodes { get; set; } = new List<ILCode>();

        public List<string> Indices { get; set; } = new List<string>();

        [JsonConverter(typeof(StringEnumConverter))]
        public ActionMethod? Action { get; set; }

        [DefaultValue("")]
        public string Optional { get; set; }
    }
}