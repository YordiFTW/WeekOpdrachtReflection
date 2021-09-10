using System;
using System.Reflection;

namespace WeekOpdrachtReflection1
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Assembly asm = Assembly.LoadFile(@"C:\Users\Yordi\source\repos\WeekOpdrachtReflection\WeekOpdrachtReflection1\ReflectThis.dll");
            

            var types = asm.GetTypes();
            Console.WriteLine("");

            Console.WriteLine(asm.FullName);

            Console.WriteLine("All Types:");
            foreach (var type in types)
            {
                Console.WriteLine(type);
            }
            Console.WriteLine("");

            Console.WriteLine("MetaData:");
            DispalyAssembly(asm);

            Console.WriteLine("");

            foreach (var type in types)
            {
                var members = type.GetMembers();

                Console.WriteLine($"All members of type: {type} ");
                foreach(var member in members)
                {
                    Console.WriteLine(member);
                }
                Console.WriteLine("");
            }

            foreach (var type in types)
            {
                var methods = type.GetMethods();
                Console.WriteLine($"All methods of type: {type} ");
                MethodInfo[] mth = type.GetMethods();
                foreach (MethodInfo m in mth)
                {
                    Console.WriteLine("-->{0}", m.Name);
                }
                Console.WriteLine("");
            }

            foreach (var type in types)
            {
                var methods = type.GetMethods();
                Console.WriteLine($"All fields of type: {type} ");
                FieldInfo[] fld = type.GetFields();
                foreach (FieldInfo f in fld)
                {
                    Console.WriteLine("-->{0}", f.Name);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Invoking the LogOff Method from ReflectThis.DLL:");
            var theType = asm.GetType("ReflectThis.UserManager");
            var c = Activator.CreateInstance(theType);
            var method = theType.GetMethod("LogOff");
            dynamic methodreturn = method.Invoke(c, new object[] { "Yordi" });

            Console.WriteLine(methodreturn.ToString());

            Console.ReadLine();
        }



        static void DispalyAssembly(Assembly a)
        {

            Console.WriteLine("Name:{0}", a.GetName().Name);
            Console.WriteLine("Version:{0}", a.GetName().Version);
            Console.WriteLine("Culture:{0}", a.GetName().CultureInfo.DisplayName);
            Console.WriteLine("Loaded from GAC?:{0}", a.GlobalAssemblyCache);
        }

       
    }
}
