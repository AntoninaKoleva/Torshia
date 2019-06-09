using SIS.MvcFramework;
using System;

namespace Torshia.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
