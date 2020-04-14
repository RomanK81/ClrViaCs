using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ClrViaDotNet
{
    /*When ToString is called, it attempts to translate the numeric value into its symbolic equivalent.
The numeric value is 0x0005, which has no symbolic equivalent. However, the ToString method
detects the existence of the [Flags] attribute on the Actions type, and ToString now treats the
numeric value not as a single value but as a set of bit flags. Because the 0x0001 and 0x0004 bits are set,
ToString generates the following string: “Read, Delete”. If you remove the [Flags] attribute from
the Actions type, ToString would return “5.”*/
    [Flags] // The C# compiler allows either "Flags" or "FlagsAttribute".
    internal enum Actions
    {
        None = 0,
        Read = 0x0001,
        Write = 0x0002,
        ReadWrite = Actions.Read | Actions.Write,
        Delete = 0x0004,
        Query = 0x0008,
        Sync = 0x0010
    }

    class EnumUse
    {
        void TryMyEnum()
        {
            Actions actions = Actions.Read | Actions.Delete; // 0x0005
            Console.WriteLine(actions.ToString()); // "Read, Delete" 
        }
    }
}
