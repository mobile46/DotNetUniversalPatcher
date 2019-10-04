using System;
using System.ComponentModel;

namespace DotNetUniversalPatcher.Models
{
    public class PatcherInfo
    {
        public string Software { get; set; }

        [DefaultValue("")]
        public string Author { get; set; }

        [DefaultValue("")]
        public string Website { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [DefaultValue("")]
        public string ReleaseInfo { get; set; }

        [DefaultValue("")]
        public string AboutText { get; set; }

        [DefaultValue(false)]
        public bool MakeBackup { get; set; }
    }
}