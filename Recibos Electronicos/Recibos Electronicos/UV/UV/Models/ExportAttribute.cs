using System;

namespace UV.Models
{
    internal class ExportAttribute : Attribute
    {
        public int FieldOrder { get; set; }
    }
}