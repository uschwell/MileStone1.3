﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MileStone1._3
{
    interface CSVParser //a basic interface to get lines from a csv file
    {
        public Dictionary<string, string> Parse(int line);


        public string GetLine(int index);
    }
}
