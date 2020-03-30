using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LockToggler
{
    /// <summary>
    /// Holds information about mapped keys, when it was pressed down, and its corresponding create code
    /// </summary>
    class KeyMap
    {
        /// <summary>
        /// Holds the time and break code for a mapped key
        /// </summary>
        public class KeyData
        {
            /// <summary>
            /// when the key was pressed down. null if the key is up.
            /// </summary>
            public DateTime? started;
            /// <summary>
            /// break code of the key, used to generate a keystroke using keybd_event()
            /// </summary>
            public byte breakCode;
        };

        // make codes from http://faydoc.tripod.com/structures/00/0006.htm
        // break code = make code | 0x80
        /// <summary>
        /// The mapping of key to their break code and the time they were depressed.
        /// Keys mapped in here will automatically have a setting on the DetailsForm.
        /// </summary>
        public static Dictionary<Keys, KeyData> dtKeys = new Dictionary<Keys, KeyData>()
        {
            // IMPORTANT: when adding a mapping here, you will also need to define a corresponding setting.
            //            the setting will be named delayXXX, where XXX is the name as per the Keys enum
            {Keys.CapsLock, new KeyData { started=null, breakCode=0x80 + 0x3a } },
            {Keys.NumLock,  new KeyData { started=null, breakCode=0x80 + 0x45 } },
            {Keys.Scroll,   new KeyData { started=null, breakCode=0x80 + 0x46 } },
            {Keys.Insert,   new KeyData { started=null, breakCode=0x80 + 0x52 } }
        };

    }
}
