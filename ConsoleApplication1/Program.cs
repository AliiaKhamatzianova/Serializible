using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Collections;
using ClassLibrary1;

namespace ConsoleApplication1
{
    struct myValueType
    {
        int _code;
        string _name;

        public myValueType(int code, string name)
        {
            _code = code;
            _name = name;
        }

        public int getCode()
        {
            return _code;
        }

        public void setCode(int code)
        {
            _code = code;
        }

        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }
    }


    class MyReferenceType
    {
        int _code;
        string _name;

    public string Description;

        public MyReferenceType(int code, string name)
        {
            _code = code;
            _name = name;
        }

        public int GetCode()
        {
            return _code;
        }

        public void SetCode(int code)
        {
            _code = code;
        }

    public int Code
    {
        get { return _code; }
        set { _code = value; }
    }
}

    [Serializable]
    [DataContract]
    public class Student
    {
        private class InnerClass
        {
            public int IntProperty { get; set; }

            private Student _student;

            public InnerClass (Student s)
            {
                _student = s;
            }

            public void foo()
            {
                //_student._field;//
            }
        }

        private InnerClass _field;


        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }

        public Student()
        {
            Console.WriteLine("Default constructor");
        }

        //public Student (int id)
        //{
        //    Id = id;
        //    Console.WriteLine("Int constructor");
        //}

        //public Student(int id, string name) : this(id)
        //{
        //    //Id = id;
        //    Name = name;
        //    Console.WriteLine("Int, string constructor");
        //}

        //public Student(int id, string name, DateTime birthDate) : this(id,name)
        //{
        //    BirthDate = birthDate;
        //    Console.WriteLine("Int, string, dateTime constructor");
        //}

        public Student(int id=0, string name="", DateTime birthDate=new DateTime()) 
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            _field = new InnerClass(this);
            _field.IntProperty =5;
            Console.WriteLine("Int, string, dateTime constructor");
        }


        //[IgnoreDataMember]
        //public int Age1 { get { return (int)(DateTime.Now - BirthDate).TotalDays / 365; } }
        [IgnoreDataMember]
        public int Age => (DateTime.Now - BirthDate).Days / 365;


    }

    public abstract class Animal
    {
        public double Weight { get; private set; }

        protected bool Hungry { get; private set; } = true;

        private void Eat()
        {
            if(!_hungry)
                Weight *= 1.01;
        }

        public virtual void Feed()
        {
            Eat();
        }

        public abstract void Say();

        public virtual void Run()
        {
            if (Hungry)
                Weight *= 0.99;
            else
                Hungry = true;
        }

        protected Animal(double weight)
        {
            Weight = weight;
        }
    }

    public class Cat : Animal
    {
        private enum Mood { Good, Bad}

        private Mood _mood = Mood.Good;

        public void Pet()
        {
            _mood = Mood.Good;
        }

        public override void Say()
        {
            Console.WriteLine(Name + ": " +(_mood==Mood.Good?"Purr":"Mew"));
        }

        public sealed override void Feed()
        {
            base.Feed();
            _mood = Mood.Good;
        }

        public override void Run()
        {
            base.Run();
            _mood = Mood.Bad;
        }

        public string Name { get; }

        public Cat(double weight) : base(weight)
        {
        }
         
        public Cat (string name, double weight) : base(weight)
        {
            Name = name;
        }

    }



    class Program
        {
            static void Main(string[] args)
            {
            #region
            /*
            myValueType v = new myValueType(1,"one");
            myValueType v2 = v;
            v.setCode(5);

            Console.WriteLine(v.getCode());
            Console.WriteLine(v2.getCode())*/
            ;

            /*MyReferenceType r = new MyReferenceType(1, "one");
            MyReferenceType r2 = r;
            //r.setCode(5);
            r.Code = 5;

            Console.WriteLine(r.Code);//r.GetCode());
            Console.WriteLine(r2.GetCode());*/

            //Student s = new Student
            //{
            //    Id = 1,
            //    BirthDate = new DateTime(1995, 1, 1),
            //    Name ="Ivan"
            //};

            /*Student s2 = new Student(2,"petya",new DateTime(1995,12,12));

            //Student s3 = new Student(name: "petya", id:2,  birthDate:new DateTime(1995, 12, 12));

            using (var sw = new StreamWriter("output.txt"))
            {
                var ser = new XmlSerializer(typeof(Student));
                ser.Serialize(sw, s2);

                //var ser = new DataContractSerializer(typeof(Student));
                //ser.WriteObject(sw,s2);
            }

            Student s3;

            using (var sr = new StreamReader("output.txt"))
            {
                var ser = new XmlSerializer(typeof(Student));
                s3 = (Student)ser.Deserialize(sr);
            }

            using (var fs = new FileStream("output.json",FileMode.Create))
            {
                var jser = new DataContractJsonSerializer(typeof(Student));
                jser.WriteObject(fs, s2);
            }

            Student s4;

            using (var fs = new FileStream("output.json", FileMode.Open))
            {
                var jser = new DataContractJsonSerializer(typeof(Student));
                s4 = (Student)jser.ReadObject(fs);
            }

            using (var fs = new FileStream("output.bin", FileMode.Create))
            {
                var bf = new BinaryFormatter();

                bf.Serialize(fs,s2);
            }

            Student s5;

            using (var fs = new FileStream("output.bin", FileMode.Open))
            {
                var bf = new BinaryFormatter();
                s5 = (Student)bf.Deserialize(fs);
            }

            using (var fs = new FileStream("output.soap", FileMode.Create))
            {
                var sf = new SoapFormatter();

                sf.Serialize(fs, s2);
            }

            Student s6;

            using (var fs = new FileStream("output.soap", FileMode.Open))
            {
                var sf = new SoapFormatter();
                s6 = (Student)sf.Deserialize(fs);
            }*/
            #endregion

            #region
            /*
            DerrivedClass d = new DerrivedClass();

            BaseClass b = d;

            Console.WriteLine(d);

            Console.WriteLine(b);
            */
            #endregion

            #region

            //object box = (int)1024;
            //int unboxIint = (int)box;

            // Console.WriteLine(1024);
            #endregion

            #region

            /*Nullable<int> x; //int? x;
            x = null;*/
            #endregion
            #region

            //List<int> intList = new List<int>();
            //List<double> doubleList = new List<double>();
            //intList.Add(1);
            #endregion

            #region
            /*ArrayList l = new ArrayList();
            l.Add(1);
            l.Add(1.5);*/
            /*
            BaseClass b = new BaseClass();
            Console.ReadKey();*/
            #endregion

            Animal barsik = new Cat("Barsik",5);


        }

    }
}
