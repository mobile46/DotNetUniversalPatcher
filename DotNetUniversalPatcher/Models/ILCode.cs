using System.ComponentModel;

namespace DotNetUniversalPatcher.Models
{
    public class ILCode
    {
        [DefaultValue("")]
        public string OpCode { get; set; }

        [DefaultValue("")]
        public string Operand { get; set; }
    }
}