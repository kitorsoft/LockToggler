using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockToggler
{
    class Sound
    {
        /// <summary>
        /// Play the bing.wav sound from the embedded resources
        /// </summary>
        public static void play()
        {
            System.Reflection.Assembly a = typeof(Sound).Assembly;
            //System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream s = a.GetManifestResourceStream("LockToggler.Resources.bing.wav");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(s);
            player.Play();
        }
    }
}
