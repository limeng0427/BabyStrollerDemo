using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using BabyStroller.SDK;

namespace BabyStroller.MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var folder = Path.Combine(Environment.CurrentDirectory, "Animals");
            var files = Directory.GetFiles(folder);
            var animalTypes = new List<Type>();
            foreach (var file in files)
            {
                if (file.Contains(".DS_Store")) continue;
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.GetInterfaces().Contains(typeof(IAnimal)))
                    {
                        var isUnfinished = type.GetCustomAttributes(false).Any(a => a.GetType() == typeof(UnfinishedAttribute));
                        if(isUnfinished == false) 
                            animalTypes.Add(type);
                    }
                }
            }

            while (true)
            {
                for (int i = 0; i < animalTypes.Count; i++)
                {
                    Console.WriteLine($"{i+1}.{animalTypes[i].Name}");
                }
                Console.WriteLine("====================");
                Console.WriteLine("Please choose an animal");
                int index = int.Parse(Console.ReadLine());
                if(index < 1 || index > animalTypes.Count - 1)
                {
                    Console.WriteLine("No animal. Try again");
                    continue;
                }
                Console.WriteLine("How many times?");
                int times = int.Parse(Console.ReadLine());
                var t = animalTypes[index - 1];
                var m = t.GetMethod("Voice");
                var o = Activator.CreateInstance(t);
                var a = o as IAnimal;
                a.Voice(times);
            }
        }
    }
}
