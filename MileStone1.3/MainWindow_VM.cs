using System;
using System.Collections.Generic;
using System.Text;

namespace MileStone1._3
{
    class MainWindow_VM
    {

        public void StartFlightGear(string flightgear_path)
        {
            if (flightgear_path == null)
                throw new NullReferenceException("FlightGear Path isn't initialized");
            System.Diagnostics.Process.Start(flightgear_path, "--launcher");
        }
    }
}
