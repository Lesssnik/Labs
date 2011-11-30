using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Configuration;
using System.Numerics;

namespace Rumyantsev.Lab5.Reflaction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Properties.Settings.Default.Path;
            DirectoryInfo di = new DirectoryInfo(path);
            Console.WriteLine(Reflection.ReflectMany(di));

            Console.Write("Input file name: ");
            Assembly assembly = Assembly.LoadFrom(di.FullName + '\\' + Console.ReadLine() + ".dll");
            Console.Write("Input full typename: ");
            Type type = assembly.GetType(Console.ReadLine());
            dynamic obj = Activator.CreateInstance(type);
            Console.Write("Input method name: ");
            MethodInfo method = type.GetMethod(Console.ReadLine());
            var paramArray = new object[method.GetParameters().Length];
            method.Invoke(obj, paramArray);

            //Пример работы со сборкой HTMLWorker.dll
            // В данном примере нужно вызвать метод CreateNewDocument,
            // а затем WriteResult. В результате в result будет
            // созданный "нулевой" HTML документ
            /*Console.Write("Input file name: ");
            Assembly assembly = Assembly.LoadFrom(di.FullName + '\\' + Console.ReadLine() + ".dll");
            Console.Write("Input full typename: ");
            Type type = assembly.GetType(Console.ReadLine());
            dynamic obj = Activator.CreateInstance(type);
            Console.Write("Input method name: ");
            MethodInfo method = type.GetMethod(Console.ReadLine());
            var paramArray = new object[method.GetParameters().Length];
            method.Invoke(obj, paramArray);
            Console.Write("Input method name: ");
            MethodInfo method2 = type.GetMethod(Console.ReadLine());
            string result = method2.Invoke(obj, paramArray);*/
         
            //Пример работы со сборкой AllMath.dll
            // В данном примере нужно вызвать процедуры ChangeNumbers чтобы вбить числа не нули
            // затем вызвать любую процедуру, чтобы произвести какие-нибудь подсчеты
            // а затем вызвать WriteResult, чтобы вывести результат действий
            /*Console.Write("Input file name: ");
            Assembly assembly = Assembly.LoadFrom(di.FullName + '\\' + Console.ReadLine() + ".dll");
            Console.Write("Input full typename: ");
            Type type = assembly.GetType(Console.ReadLine());
            dynamic obj = Activator.CreateInstance(type);
            Console.Write("Input method name: ");
            MethodInfo method = type.GetMethod(Console.ReadLine());
            var paramArray = new object[method.GetParameters().Length];
            paramArray[0] = (BigInteger)1;
            paramArray[1] = (BigInteger)2;
            method.Invoke(obj, paramArray);
            Console.Write("Input method name: ");
            MethodInfo method2 = type.GetMethod(Console.ReadLine());
            var paramArray2 = new object[method2.GetParameters().Length];
            method2.Invoke(obj, paramArray2);
            Console.Write("Input method name: ");
            MethodInfo method3 = type.GetMethod(Console.ReadLine());
            var paramArray3 = new object[method3.GetParameters().Length];
            string result = method3.Invoke(obj, paramArray3);
            Console.WriteLine(result);*/
        }
    }
}
