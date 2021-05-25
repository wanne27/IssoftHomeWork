using System.Runtime.Loader;

namespace task1_2
{
    internal class TrackingAssemblyLoadContext : AssemblyLoadContext
    {
        public TrackingAssemblyLoadContext() : base("Tracking ALC", true)
        {
           
        }
    }
}