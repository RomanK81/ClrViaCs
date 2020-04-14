using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ClrViaDotNet
{
    //[assembly: CLSCompliant(true)]
    [Serializable]
    [DefaultMemberAttribute("Main")]
    [DebuggerDisplayAttribute("Richter", Name = "Jeff", Target = typeof(AttributeTry))]
    public sealed class AttributeTry
    {
        [Conditional("Debug")]
        [Conditional("Release")]
        public void DoSomething() { }

        public AttributeTry() { }

        [CLSCompliant(true)]
        [STAThread]
        public static void Proc()
        {
            //Show the set of attributes  this type
            ShowAttributes(typeof(AttributeTry));
            //Get the set of methods associated with the type
            foreach (var mem in typeof(AttributeTry).GetTypeInfo().DeclaredMembers.OfType<MethodBase>().Where(m => m.IsPublic))
                ShowAttributes(mem);//Show the set of attributes  this member
            /*
                Attributes - AttributeTry: 
                    System.SerializableAttribute System.Diagnostics.DebuggerDisplayAttribute 
                    V=Richter, N=Jeff, T=Program System.Reflection.DefaultMemberAttribute  MemberName=Main

                Attributes - DoSomething: 
                    System.Diagnostics.ConditionalAttribute ConditionString=Release
                    System.Diagnostics.ConditionalAttribute  ConditionString=Debug

                Attributes - Main: System.CLSCompliantAttribute IsCompliant=True System.STAThreadAttribute

                Attributes - .ctor: None 
             */
        }
        private static void ShowAttributes(MemberInfo attTar)
        {
            var attributes = attTar.GetCustomAttributes<Attribute>();
            Console.WriteLine("Attributes - {0}: {1}", attTar.Name, (attributes.Count() == 0 ? "None" : string.Empty));
            foreach (Attribute att in attributes)
            {
                Console.WriteLine(" {0}", att.GetType().ToString());//Display the type of each applied attribute
                if (att is DefaultMemberAttribute dma) Console.WriteLine(" MemberName={0}", dma.MemberName);
                if (att is ConditionalAttribute cond) Console.WriteLine(" ConditionString={0}", cond.ConditionString);
                if (att is CLSCompliantAttribute cls) Console.WriteLine(" IsCompliant={0}", cls.IsCompliant);
                if (att is DebuggerDisplayAttribute d) Console.WriteLine(" V={0}, N={1}, T={2}", d.Value, d.Name, d.Target);
            }
        }
    }

    [Flags]
    internal enum Accounts
    {
        Savings = 0x0001,
        Checking = 0x0002,
        Brokerage = 0x0004
    }

    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class AccountsAttribute : Attribute
    {
        private readonly Accounts _accounts;
        public AccountsAttribute(Accounts accounts)
        {
            _accounts = accounts;
        }
        public override bool Match(Object obj)
        {
            if (obj == null) return false;
            // If the objects are of different types, they can't match
            if (this.GetType() != obj.GetType()) return false;
            // checks if 'this' accounts is a subset of others' accounts
            if ((((AccountsAttribute)obj)._accounts & _accounts) != _accounts)
                return false;
            return true; // Objects match
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            // If the objects are of different types, they can't be equal
            if (this.GetType() != obj.GetType()) return false;
            // Compare the fields to see if they have the same value 
            if (((AccountsAttribute)obj)._accounts != _accounts)
                return false;
            return true; // Objects are equal
        }
        // Override GetHashCode since we override Equals
        public override Int32 GetHashCode() { return (Int32)_accounts; }
    }

    [Accounts(Accounts.Savings)]
    internal sealed class ChildAccount { }
    [Accounts(Accounts.Savings | Accounts.Checking | Accounts.Brokerage)]
    internal sealed class AdultAccount { }

    public sealed class Program1
    {
        public static void Test()
        {
            CanWriteCheck(new ChildAccount());
            CanWriteCheck(new AdultAccount());
            // This just demonstrates that the method works correctly on
            // a type that doesn't have the AccountsAttribute applied to it.
            CanWriteCheck(new Program1());

            //The output:
                // ChildAccount types can NOT write checks.
                // AdultAccount types can write checks.
                // Program types can NOT write checks. 
        }
        private static void CanWriteCheck(Object obj)
        {

            Attribute va = obj.GetType().GetCustomAttribute<AccountsAttribute>(false);
            //"Checking" account, then the type can write a check
            if ((va != null) && new AccountsAttribute(Accounts.Checking).Match(va))
                Console.WriteLine("{0} types can write checks.", obj.GetType());
            else
                Console.WriteLine("{0} types can NOT write checks.", obj.GetType());
        }
    }
    public abstract class ArgumentValidationAttribute : Attribute
    {
        public abstract void Validate(object value, string argumentName);
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    public class NotNullAttribute : ArgumentValidationAttribute
    {
        public override void Validate(object value, string argumentName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    public class InRangeAttribute : ArgumentValidationAttribute
    {
        private int min;
        private int max;

        public InRangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public override void Validate(object value, string argumentName)
        {
            int intValue = (int)value;
            if (intValue < min || intValue > max)
            {
                throw new ArgumentOutOfRangeException(argumentName, string.Format("min={0}, max={1}", min, max));
            }
        }
    }
}