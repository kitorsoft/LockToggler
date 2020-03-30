using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockToggler
{
    class UI
    {
        private static System.Resources.ResourceManager rm = null;
        public static string getLabel(string v)
        {
            if (rm == null)
            {
                rm = new System.Resources.ResourceManager("LockToggler.Resources.Strings", typeof(UI).Assembly);
            }

            string retVal = rm.GetString(v);
            if (retVal == null)
            {
                retVal = v;
            }

            return retVal;
        }
    }
}
