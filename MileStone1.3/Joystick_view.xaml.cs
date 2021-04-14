using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for JoyStick_view.xaml
    /// </summary>
    public partial class JoyStick_view : UserControl
    {
        passData_VM vm;
        double out_minEle, out_maxEle, out_maxAli, out_minAli;
        public JoyStick_view()
        {
            InitializeComponent();
            //     vm = new JoyStick_VM();
            //    DataContext = vm;
            //   vm.PropertyChanged += Vm_PropertyChanged;
            out_maxEle = 0;
            out_minEle = 0;
            out_maxAli = 0;
            out_minAli = 0;
        }
        public void SetVM(passData_VM vm)
        {
            this.vm = vm;
            DataContext = vm;
            vm.PropertyChanged += Vm_PropertyChanged;
        }
        private double map(double x, double in_min, double in_max, double out_min, double out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("VM_elevator"))
            {
                double xAxis = map(vm.VM_aileron, -1, 1, 0, cnv.ActualHeight - stick_controller.ActualHeight);
                double yAxis = map(vm.VM_elevator, -1, 1, 0, cnv.ActualWidth - stick_controller.ActualWidth);
                setHeadPoition(xAxis, yAxis);
            }
        }

        private void JoyStick_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public void setHeadPoition(double x, double y)
        {
            //stick_controller.SetValue(Canvas.LeftProperty, x);
            Dispatcher.BeginInvoke(new Action(() => Canvas.SetLeft(stick_controller, x)));
            Dispatcher.BeginInvoke(new Action(() => Canvas.SetTop(stick_controller, y)));
        }
    }
}
