using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System;


namespace cpst
{   
    public partial class Cpst_main : Window
    {
        DatabaseManager databaseConnection = new DatabaseManager();
        DispatcherTimer dispatchertimer = new DispatcherTimer();

        public Cpst_main()
        {
            InitializeComponent();
            Timer();            
        }
        
        //Sensor gets data from database
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

        private void SetStatusTime(SensorTypes sentype, string val)
        {
            switch (sentype)
            {
                case SensorTypes.Sensor1:
                    txt_sensoronetime.Text = val;
                    break;
                case SensorTypes.Sensor2:
                    txt_sensortwotime.Text = val;
                    break;
                case SensorTypes.Sensor3:
                    txt_sensorthreetime.Text = val;
                    break;
                case SensorTypes.Sensor4:
                    txt_sensorfourime.Text = val;
                    break;
                case SensorTypes.Sensor5:
                    txt_sensorfivetime.Text = val;
                    break;
                case SensorTypes.Sensor6:
                    txt_sensorsixtime.Text = val;
                    break;
                default:
                    break;
            }
        }

        private void GetSensorStatus(SensorTypes sentype)
        {
            var valuesStatus = databaseConnection.GetSensorStatus(sentype);
            var valueStatusTime = databaseConnection.GetSensorStatusTime(sentype);
            foreach (var val in valuesStatus)
            {               
                SetCircleColor(sentype, val);                
            }
            foreach (var val in valueStatusTime)
            {
                SetStatusTime(sentype, val);
            }
        }

        //Timer to Check every second Data from Database
        public void Timer()
        {
            dispatchertimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatchertimer.Interval = new TimeSpan(0, 0, 1);
            dispatchertimer.Start();
        }
        public void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            
            foreach (SensorTypes sentype in Enum.GetValues(typeof(SensorTypes))) 
            {                
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
            Application.Current.Shutdown();
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
            dispatchertimer.Stop();
            var login = new Cpst_Login();
            this.Close();            
            login.Show();      
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

        //Move window with label
        private void Label_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        //PasswordChangeIcon
        private void PwChange_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var pwchange = new Cpst_PasswdChange();
            pwchange.Show();
        }
     
    }    
}




