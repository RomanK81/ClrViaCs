using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ClrViaDotNet
{
    // Declare a delegate type; instances refer to a method that
    // takes an Int32 parameter and returns void.
    internal delegate void Feedback(Int32 value);
/*
    internal class Feedback : System.MulticastDelegate
    {
        // Constructor
        public Feedback(Object @object, IntPtr method);
        // Method with same prototype as specified by the source code
        public virtual void Invoke(Int32 value);
        // Methods allowing the callback to be called asynchronously
        public virtual IAsyncResult BeginInvoke(Int32 value, AsyncCallback callback, Object @object);
        public virtual void EndInvoke(IAsyncResult result);
    }
*/
    public static class DelegatesDemo
    {
/*
        public static void TestDelegate()
        {
            Console.WriteLine("----- Chain Delegate Demo 2 -----");
            Feedback fb1 = new Feedback(FeedbackToConsole);
            Feedback fb3 = new Feedback(FeedbackToFile);
            Feedback fbChain = null;
            //fbChain = (Feedback)Delegate.Combine(fbChain, fb1);
            fbChain += fb1;
            fbChain += fb3;
            Counter(1, 2, fbChain);
            Console.WriteLine();
            //bChain = (Feedback) Delegate.Remove(fbChain, new Feedback(FeedbackToMsgBox));
            fbChain -= new Feedback(FeedbackToFile);
            //Counter(1, 3, new Feedback(FeedbackToConsole));
            Counter(1, 2, fbChain);
        }
 */

        private static void Counter(Int32 from, Int32 to, Feedback fb)
        {
            for (Int32 val = from; val <= to; val++)
            {
                // If any callbacks are specified, call them
                if (fb != null) fb(val);
            }
        }
        private static void FeedbackToConsole(Int32 value)
        {
            Console.WriteLine("Item=" + value);
        }

        private static void FeedbackToFile(Int32 value)
        {
            using (StreamWriter sw = new StreamWriter("Status", true))
            {
                sw.WriteLine("Item=" + value);
            }
        }
    }
}
