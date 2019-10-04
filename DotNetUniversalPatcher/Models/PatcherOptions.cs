using System.Collections.Generic;

namespace DotNetUniversalPatcher.Models
{
    public class PatcherOptions
    {
        public PatcherInfo PatcherInfo { get; set; } = new PatcherInfo();
        public Dictionary<string, string> Placeholders { get; set; } = new Dictionary<string, string>();
    }
}