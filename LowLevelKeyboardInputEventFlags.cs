using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockToggler
{
    /// <summary>
    /// Defines the meaning of LowLevelKeyboardInputEvent.Flags
    /// </summary>
    [Flags]
    enum LowLevelKeyboardInputEventFlags
    {
        LLKHF_EXTENDED = 0x0100 >> 8,
        LLKHF_LOWER_IL_INJECTED = 0x00000002,
        LLKHF_INJECTED = 0x00000010,
        LLKHF_ALTDOWN = 0x2000 >> 8,
        LLKHF_UP = 0x8000 >> 8
    }
}
