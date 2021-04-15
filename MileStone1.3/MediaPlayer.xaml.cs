using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MileStone1._3
{
    /// <summary>
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : UserControl
    {
        MediaController_VM vm;
        double oldval;

        public MediaPlayer()
        {
            //InitializeComponent();
            vm = new MediaController_VM();
            this.DataContext = vm;

        }

        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_play();
        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_pause();
        }

        private void btn_gotoLine_Click(object sender, RoutedEventArgs e)
        {
            int percent = int.Parse(tb_line.Text);
            vm.VM_goto(percent);
        }

        private void btn_setSpeed_Click(object sender, RoutedEventArgs e)
        {
            double newSpeed = double.Parse(tb_setSpeed.Text);
            vm.VM_setSpeed(newSpeed);
        }

        private void timeline_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //if(Math.Abs(timeline_slider.Value - oldval)>=2)
            //{
            //    double percent = ((timeline_slider.Value / timeline_slider.Maximum) * 100);
            //    vm.VM_goto((int)percent);
            //    oldval = timeline_slider.Value;
            //}
            //oldval = timeline_slider.Value;
        }


        private void btn_gotostar_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_goto(0);
        }

        private void btn_gotoend_Click(object sender, RoutedEventArgs e)
        {
            vm.VM_goto(100);
        }
    }
}
