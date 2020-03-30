# LockToggler

LockToggler is an example of a keyboard hook in C#. It may server as an example for others.

The program allows you to define delays for Cap Lock, Scroll Lock, Num Lock, and INS keys. This helps avoiding accidentally hitting such keys.

For me, 500ms delay work fine to prevent this. If you set the delay to -1, the key will be completely disabled; this is what I personally like to use for the insert key.

I wrote this as a little excercise and because I wanted the functionality. Learning about Windows hooks was also a good side-effect.

No warranty, obviously :-) If you find bugs, I will try to fix them when I have time.

If you d not want to build the tool from code, you can download the executable here: https://github.com/kitorsoft/LockToggler/releases/download/1.0/LockToggler.exe
