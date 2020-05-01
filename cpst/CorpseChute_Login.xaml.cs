using System.Windows;
using System.Windows.Media;

namespace cpst
{
    /// <summary>
    /// Interaktionslogik für Cpst_Login.xaml
    /// </summary>
    public partial class Cpst_Login : Window
    {       

        DatabaseManager databaseConnection = new DatabaseManager();
        public string username { get; set; }
        public Cpst_Login()
        {
            InitializeComponent();
        }             
        
        

        //button login in database
        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
           if(databaseConnection.Login(txt_username.Text, pw_box.Password.ToString()))
            {
                username = txt_username.Text;
                Cpst_main main = new Cpst_main();
                main.Show();
                this.Close();                
            }
            
        }

        //Enter key on Passwordbox     
        private void Pw_box_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {         
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (databaseConnection.Login(txt_username.Text, pw_box.Password.ToString()))
                {
                    Cpst_main main = new Cpst_main();
                    main.Show();
                    this.Close();
                }
            }

        }

        //Dragmove label
        private void Label_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        //close button
        private void Lbl_close_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lbl_close.Background = Brushes.WhiteSmoke;
        }
        private void Lbl_close_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            lbl_close.Background = Brushes.DarkRed;
        }
        private void Lbl_close_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Lbl_close_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lbl_close.Background = Brushes.Red;
        }

        //minimize button
        private void Lbl_minimize_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lbl_minimize.Background = Brushes.WhiteSmoke;
        }
        private void Lbl_minimize_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            lbl_minimize.Background = Brushes.LightSlateGray;
        }
        private void Lbl_minimize_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Lbl_minimize_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lbl_minimize.Background = Brushes.LightSlateGray;
        }               
    }
}