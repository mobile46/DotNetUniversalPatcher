using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotNetUniversalPatcher.Models
{
    public class Patch
    {
        [JsonIgnore]
        public string Name { get; set; }

        public Patch(string name)
        {
            Name = name;
        }

        public TargetInfo TargetInfo { get; set; } = new TargetInfo();
        public List<Target> TargetList { get; set; } = new List<Target>();

        public override string ToString()
        {
            return Name;
        }
    }
}