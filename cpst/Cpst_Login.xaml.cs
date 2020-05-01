using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace cpst
{    
    public partial class Cpst_Login : Window
    {       

        DatabaseManager databaseConnection = new DatabaseManager();
        
        public Cpst_Login()
        {
            InitializeComponent();
        }             
        
        public string hashingPassword()
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(pw_box.Password);
            var sha1data = sha1.ComputeHash(data);
            var hashedPassword = Encoding.ASCII.GetString(sha1data);
            System.Console.WriteLine(hashedPassword);
            return hashedPassword;            
        }

        private void login()
        {          
            if (databaseConnection.Login(txt_username.Text, hashingPassword()))
            {
                Cpst_main main = new Cpst_main();
                main.Show();
                this.Close();
            }
        }

        //Button login in database
        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {                        
            login();            
        }

        //Enter key on Passwordbox     
        private void Pw_box_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {         
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                login();
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
            Application.Current.Shutdown();
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