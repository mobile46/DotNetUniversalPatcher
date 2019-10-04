using System.Collections.Generic;
using System.ComponentModel;

namespace DotNetUniversalPatcher.Models
{
    public class TargetInfo
    {
        public List<string> TargetFiles { get; set; } = new List<string>();

        [DefaultValue(false)]
        public bool KeepOldMaxStack { get; set; }
    }
}