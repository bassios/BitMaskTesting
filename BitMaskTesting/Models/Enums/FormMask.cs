using System;

namespace BitMaskTesting.Models.Enums
{
    [Flags]
    public enum FormMask
    {
        None = 0,
        Form1 = 1,
        Form2 = 2,
        Form3 = 4
    }
}
