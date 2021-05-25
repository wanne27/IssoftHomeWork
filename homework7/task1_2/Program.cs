using System;
using System.Reflection;


namespace task1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var alc = new TrackingAssemblyLoadContext();

            var name = new AssemblyName { Name = "task1_1" };
            try
            {
                var assembly = alc.LoadFromAssemblyName(name);
                Console.WriteLine($"Assembly loaded: {assembly.FullName}");
                foreach (var module in assembly.GetModules())
                {
                    Console.WriteLine($"Module: {module.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.Message);
            }

            alc.Unload();
            GC.Collect();
            
        }
    }
}
