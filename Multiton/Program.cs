using System;
using System.Collections.Generic;

namespace Multiton
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera1 = Camera.GetCamera("Nikon");
            Camera camera2 = Camera.GetCamera("Canon");
            Camera camera3 = Camera.GetCamera("Canon");
            Camera camera4 = Camera.GetCamera("Nikon");
            Console.WriteLine(camera1.id);
            Console.WriteLine(camera2.id);
            Console.WriteLine(camera3.id);
            Console.WriteLine(camera4.id);
            Console.ReadLine();
        }
    }
    class Camera
    {
        static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        static object _lock = new object();
        public Guid id { get; set; }
        private string brand;
        private Camera()
        {
            id = Guid.NewGuid();
        }
        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera());
                }
            }
            return _cameras[brand];
        }
    }
}
