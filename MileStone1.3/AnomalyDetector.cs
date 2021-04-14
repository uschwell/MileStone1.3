using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace MileStone1._3
{
    class AnomalyDetector
    {
        const string dll_path = @"C:\Users\noamk\source\repos\AnomalyDetectorLib\x64\Debug\AnomalyDetectorLib.dll";

        [DllImport(dll_path, EntryPoint = "learn")]
        static extern void learn(IntPtr detector, IntPtr names, int size, IntPtr sw);

        [DllImport(dll_path, EntryPoint = "detect")]
        static extern IntPtr detect(IntPtr detector, IntPtr names, int size, IntPtr sw);

        [DllImport(dll_path, EntryPoint = "createSimpleAnomalyDetectorInstance")]
        static extern IntPtr createSimpleAnomalyDetectorInstance();

        [DllImport(dll_path, EntryPoint = "dispose")]
        static extern int dispose(IntPtr v);

        [DllImport(dll_path, EntryPoint = "getTimeStep")]
        static extern int getTimeStep(IntPtr v, int index);

        [DllImport(dll_path, EntryPoint = "getDesciption")]
        static extern IntPtr getDiscription(IntPtr v, int index);

        [DllImport(dll_path, EntryPoint = "createString")]
        static extern IntPtr createString(int len);

        [DllImport(dll_path, EntryPoint = "addCharToString")]
        static extern void addCharToString(IntPtr sw, char c);

        [DllImport(dll_path, EntryPoint = "getChar")]
        static extern char getChar(IntPtr sw, int index);

        [DllImport(dll_path, EntryPoint = "len")]
        static extern int len(IntPtr sw);

        [DllImport(dll_path, EntryPoint = "getAnomalyCount")]
        static extern int getAnomalyCount(IntPtr vw);

        [DllImport(dll_path, EntryPoint = "getFunc")]
        static extern IntPtr getFunc(IntPtr vw, int index);

        IntPtr detector;
        IntPtr AnomalyReportVector;
        public AnomalyDetector()
        {
            this.detector = createSimpleAnomalyDetectorInstance();
        }

        public IntPtr sw_string(string s)
        {
            IntPtr STR = createString(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                addCharToString(STR, s[i]);
            }
            return STR;
        }
        public void LearnNormal(string names, string filename)
        {
            IntPtr sw_filename = sw_string(filename);
            IntPtr sw_names = sw_string(names);
            learn(detector, sw_names, names.Length, sw_filename);
            dispose(sw_filename);
            dispose(sw_names);
        }
        public void Detect(string names, string filename)
        {
            IntPtr sw_filename = sw_string(filename);
            IntPtr sw_names = sw_string(names);
            AnomalyReportVector = detect(this.detector, sw_names, names.Length, sw_filename);
            dispose(sw_filename);
            dispose(sw_names);
        }

        public string GetDiscription(int index)
        {
            IntPtr sw = getDiscription(AnomalyReportVector, index);
            string s = "";
            for (int i = 0; i < len(sw); i++)
            {
                s += getChar(sw, i);
            }
            dispose(sw);
            return s;
        }

        public int GetTimeStep(int index)
        {
            return getTimeStep(AnomalyReportVector, index);
        }
        public int AnomalyCount()
        {
            return getAnomalyCount(AnomalyReportVector);
        }

        public string GetFunction(int index)
        {
            IntPtr sw = getFunc(detector, index); string s = "";
            for (int i = 0; i < len(sw); i++)
            {
                s += getChar(sw, i);
            }
            dispose(sw);
            return s;
        }

        ~AnomalyDetector()
        {
            dispose(detector);
            dispose(AnomalyReportVector);
        }
    }
}