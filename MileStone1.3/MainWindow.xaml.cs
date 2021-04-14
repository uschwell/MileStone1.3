
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
/*

using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tester;
using System.Xml;

namespace MileStone1._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Tester.Test1.MyTest();
            InitializeComponent();
        }
    }

    */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Handler;

namespace MileStone1._3
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        {
            FlightController flightController;
            FileHandler fileHandler;
            public MainWindow()
            {
                InitializeComponent();
                flightController = FlightController.GetInstance;
                fileHandler = new FileHandler();

                passData_VM passdata = new passData_VM();
                data_viewer.SetVM(passdata);
                joystick.SetVM(passdata);
            }

            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                this.IsEnabled = false;
                FileLoader fLoader = new FileLoader(fileHandler);
                Nullable<bool> res = fLoader.ShowDialog();
                if (res == true)
                {
                    this.IsEnabled = true;
                    string[] names = getNames();
                    flightController.loadCSV(fileHandler.csvPath, names);
                    StartFlightGear();
                }
            }
            private string[] getNames()
            {
                List<String> strings = new List<String>();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                settings.DtdProcessing = DtdProcessing.Parse;
                using (XmlReader reader = XmlReader.Create(fileHandler.xmlPath, settings))
                {
                    while (reader.Read())
                    {
                        int index, counter;
                        if (reader.Name.Equals("input"))
                        {
                            break;
                        }
                        if (reader.Name.Equals("name") && reader.NodeType.ToString().Equals("Element"))
                        {
                            if (!reader.EOF)
                            {
                                reader.Read();
                                counter = 0;
                                index = checkIfContains(strings, reader.Value);
                                while (index != -1)
                                {
                                    counter++;
                                    index = checkIfContains(strings, reader.Value + counter.ToString());
                                }
                                if (counter == 0)
                                {
                                    strings.Add(reader.Value);
                                }
                                else
                                {
                                    strings.Add(reader.Value + counter.ToString());
                                }
                            }
                        }
                    }
                }
                string[] output = strings.ToArray();
                return output;
            }
            private int checkIfContains(List<string> list, string element)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Contains(element))
                        return i;
                }
                return -1;
            }

            public void StartFlightGear()
            {
                if (fileHandler.fgPath == null)
                    throw new NullReferenceException("FlightGear Path isn't initialized");
                System.Diagnostics.Process.Start(fileHandler.fgPath, "--launcher");
            }

            private void FlightController_dataChanged(object sender, EventArgs e)
            {
                System.Diagnostics.Trace.WriteLine("WOW");
            }
        }
    }

