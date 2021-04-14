using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MileStone1._3
{
    class LineChart_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private LineChart_model model;
        private string name;

        public LineChart_VM()
        {
            name = "";
            model = new LineChart_model();
            model.PropertyChanged += delegate (Object sender, System.ComponentModel.PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public string[] VM_names
        {
            get { return model.Names; }
        }


        public LinkedList<DataPoint> VM_list
        {
            get
            {
                if (!name.Equals(""))
                {
                    string corralted = model.GetCorralatedName(name);
                    VM_CorralatedName = corralted;
                    VM_CorralatedList = model.getList(corralted);
                    NotifyPropertyChanged("VM_CorralatedList");
                    NotifyPropertyChanged("VM_CorralatedName");
                    //       NotifyPropertyChanged("VM_list");
                    NotifyPropertyChanged("dataChanged");
                    ///
                    VM_points = model.getPointsOfCorralated(name);////////////////////
                    NotifyPropertyChanged("VM_points");////////////////////////
                    ///
                    return model.getList(name);
                }
                return null;
            }
        }


        public void UpdateList(string newName)
        {
            name = newName;
            /// updates the correlative graph
            string corralted = model.GetCorralatedName(name);
            if (!corralted.Equals(""))
            {
                VM_CorralatedName = corralted;
                VM_CorralatedList = model.getList(corralted);
                NotifyPropertyChanged("VM_CorralatedList");
                NotifyPropertyChanged("VM_CorralatedName");
            }



            ///
            Tuple<DataPoint, DataPoint> twoPoints = model.linearRegOfCorrelative(newName);
            if (twoPoints != null)
            {
                List<DataPoint> lst = new List<DataPoint>();
                lst.Add(twoPoints.Item1);
                lst.Add(twoPoints.Item2);
                VM_lineRegList = lst;
                NotifyPropertyChanged("VM_lineRegList");
            }
            LinkedList<DataPoint> points = model.getPointsOfCorralated(newName);///////////////////////////////
            if (points != null)
            {
                VM_points = points;
                NotifyPropertyChanged("VM_points");
            }
            //////////////////////////////////////////////////////////////////////////



        }

        public LinkedList<DataPoint> VM_CorralatedList { get; set; }
        public string VM_CorralatedName { get; set; }


        public List<DataPoint> VM_lineRegList { get; set; }




        public LinkedList<DataPoint> VM_points { get; set; }
    }
}
