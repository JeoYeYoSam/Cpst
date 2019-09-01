﻿using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System;


namespace cpst
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Cpst_main : Window
    {
        readonly DatabaseManager databaseConnection = new DatabaseManager();

        DispatcherTimer dispatchertimer = new DispatcherTimer();


        public Cpst_main()
        {
            InitializeComponent();
            Timer();
            Usernamelogoutbutton();
        }

        private void SetCircleColor(SensorTypes sentype, int val)
        {
            SolidColorBrush color = Brushes.Red;
            if (val == 0)
            {
                 color = Brushes.Gray;
            }
            else if (val == 1)
            {
                color = Brushes.Green;
            }
            switch (sentype)
            {
                case SensorTypes.Sensor1:
                    circle_fill_color_1.Fill = color;
                    break;
                case SensorTypes.Sensor2:
                    circle_fill_color_2.Fill = color;
                    break;
                case SensorTypes.Sensor3:
                    circle_fill_color_3.Fill = color;
                    break;
                case SensorTypes.Sensor4:
                    circle_fill_color_4.Fill = color;
                    break;
                case SensorTypes.Sensor5:
                    circle_fill_color_5.Fill = color;
                    break;
                case SensorTypes.Sensor6:
                    circle_fill_color_6.Fill = color;
                    break;
                default:
                    break;
            }
        }

        private void GetSensorStatus(SensorTypes sentype)
        {
            var values = databaseConnection.GetSensorStatus(sentype);
            foreach (var val in values)
            {                
                    for (int n = listboxstatus.Items.Count - 1; n >= 0; --n)
                    {
                        if (listboxstatus.Items[n].ToString() == "0")
                        {
                            listboxstatus.Items[n] = "Off";

                        }
                        else
                        {
                            if (listboxstatus.Items[n].ToString() == "1")
                            {
                                listboxstatus.Items[n] = "Frei";
                            }
                            else
                            {
                                listboxstatus.Items[n] = "Belegt";
                            }
                        }
                    }
                SetCircleColor(sentype, val);
            }
        }

        public void Timer()
        {
            dispatchertimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatchertimer.Interval = new TimeSpan(0, 0, 5);
            dispatchertimer.Start();
        }
        public void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            foreach (SensorTypes sentype in Enum.GetValues(typeof(SensorTypes))) 
            {
                //SensorTypes realsentype=(SensorTypes) sentype;
                GetSensorStatus(sentype);
            }
        }



        //Minimize button
        private void Lbl_minimize_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lbl_minimize.Background = Brushes.WhiteSmoke;
        }
        private void Lbl_minimize_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            lbl_minimize.Background = Brushes.Gray;
        }
        private void Lbl_minimize_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Lbl_minimize_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lbl_minimize.Background = Brushes.LightGray;
        }

        //Close button
        private void Lbl_close_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Lbl_close_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            lbl_close.Background = Brushes.DarkRed;
        }    
        private void Lbl_close_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lbl_close.Background = Brushes.WhiteSmoke;
        }
        private void Lbl_close_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lbl_close.Background = Brushes.Red;
        }

        //Logout button
        private void TextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var main = new Cpst_Login();
            this.Close();            
            main.Show();
            dispatchertimer.Stop();
            
        }
        private void TextBlock_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            txtbox_logout.Background = Brushes.LightGray;
        }
        private void Txtbox_logout_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            txtbox_logout.Background = Brushes.White;
        }
        private void Txtbox_logout_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            txtbox_logout.Background = Brushes.Gray;
        }
        private void Usernamelogoutbutton()
        {            
           // txtbox_logout.Text = txt_username.Text;                
        }

        //Move window with label
        private void Label_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }    
}



