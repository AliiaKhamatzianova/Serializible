using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class BaseClass
    {
        private int _field;
        public int Field;
        public int Property { get; set; }
        private void Foo() { }
        public virtual string Bar() { return "Hello"; }
        public BaseClass()
        {
            Console.WriteLine("BaseClass()");
        }

        ~BaseClass()
        {
            Console.WriteLine("~BaseClass()");
        }

        public override string ToString()
        {
            //return base.ToString();
            return Bar();
        }
    }

    public class DerrivedClass : BaseClass
    {
        public DerrivedClass()
        //: base()
        {
            Console.WriteLine("DerrivedClass()");
        }

        ~DerrivedClass()
        {
            Console.WriteLine("~DerrivedClass()");
        }

        public /*new*/ override string Bar()
        {
            return "Hello from Derrived";
        }

        public override string ToString()
        {
            //return base.ToString();
            return "Hello from derrived";
        }
    }


}
