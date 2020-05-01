using System.Windows;

namespace cpst
{    
    public partial class Cpst_PasswdChange : Window
    {
        public Cpst_PasswdChange()
        {
            InitializeComponent();
        }       
        
        DatabaseManager databaseConnection = new DatabaseManager();


        private void PasswdChange()
        {          
           if (Pwbox_repeatNewPw.Password == Pwbox_newPw.Password)
           {
               if(databaseConnection.Login(Global.username, Pwbox_currentPw.Password))
               {
                    databaseConnection.ChangePassword(Pwbox_newPw.Password);
                    this.Close();
               }
           }            
        }


        private void btn_acceptPwChange_Click(object sender, RoutedEventArgs e)
        {

            PasswdChange();
        }

        private void btn_cancelPwChange_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Label_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        
    }
}
