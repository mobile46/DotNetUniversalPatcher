using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotNetUniversalPatcher.Models
{
    public class PatcherScript
    {
        public PatcherOptions PatcherOptions { get; set; } = new PatcherOptions();
        public List<Patch> PatchList { get; set; } = new List<Patch>();

        [JsonIgnore]
        public List<string> TargetFilesText { get; set; } = new List<string>();

        [JsonIgnore]
        public int TargetFilesCount { get; set; }

        [JsonIgnore]
        public string TargetFilesTip { get; set; }
    }
}