using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MileStone1._3;
//using MyServer;
using Handler;
using System.Xml;

namespace Tester
{
    public class Test1
    {
        public static void MyTest()
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");
            //InitializeComponent();
            //flightController = FlightController.GetInstance;
            FileHandler fh = new FileHandler();
            MyClient mc = new MyClient();
            String s1 = "127.0.0.1";
            mc.Connect(s1 ,5400);
            //passData_VM passdata = new passData_VM();
            //data_viewer.SetVM(passdata);
            //joystick.SetVM(passdata);
            Console.WriteLine("Holy Crap! It worked!");
            Console.WriteLine("Hello World!");
        }
    }
}
