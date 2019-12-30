using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Collections.Generic;

namespace cpst
{
    class DatabaseManager
    {

        private string checkcanlogin;
        //Connection String to connect to Database
        private MySqlConnection con = new MySqlConnection(@"Server=192.168.0.105;Port=3306;Uid=root;pwd=qweasd;Database=db_laser_sensor");   
        
        private void open()
        {
            con.Open();
        }
        
        private void close()
        {
            con.Close();
        }

        private string GetSensorQueryString(SensorTypes sentype)
        {
            switch (sentype)
            {
                case SensorTypes.Sensor1:
                    return "select * From sensor_one";
                case SensorTypes.Sensor2:
                    return "select * From sensor_two";
                case SensorTypes.Sensor3:
                    return "select * From sensor_three";
                case SensorTypes.Sensor4:
                    return "select * From sensor_four";
                case SensorTypes.Sensor5:
                    return "select * From sensor_five";
                case SensorTypes.Sensor6:
                    return "select * From sensor_six";
            }
            return null;
        }

        // Method to analyse login when loginButton is pressed or hit the Enter Key
        public bool Login(string username, string password)
        {
            string queryAuthentication = $"SELECT * FROM users WHERE username ='"+username+"' AND password='"+password+"'";

            try
            {
                open();                         
                MySqlCommand commandDatabase = new MySqlCommand(queryAuthentication, con);
                MySqlDataReader myReader = commandDatabase.ExecuteReader();                
                while (myReader.Read())
                {
                    checkcanlogin = myReader["can_login"].ToString();                                        
                }
                if (checkcanlogin == "Yes")
                {
                    return true;
                }                
                else if (checkcanlogin == "No")
                {                    
                    MessageBox.Show("User is deactivated");
                    return false;
                }
                else
                {
                    MessageBox.Show("Username or password is wrong");
                    return false;
                }
            }
            
            catch (Exception e)
            {                
                MessageBox.Show("Error: " + e.Message);
                return false;
            }
            finally
            {
                close();
            }
        }

        public List<int> GetSensorStatus(SensorTypes sentype)
        {
            open();

            MySqlCommand commandDatabase = new MySqlCommand(GetSensorQueryString(sentype),con)
            {
                CommandTimeout = 60
            };

            try
            {
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                if (myReader.HasRows)
                {
                    List<int> values = new List<int>();

                    while (myReader.Read())
                    {
                        Console.WriteLine(myReader["status"].ToString());
                        values.Add(Convert.ToInt32(myReader["status"]));                                         
                        
                    }
                    return values;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error: " + e.Message);
                
            }
            finally
            {
                close();
            }
            return new List<int>();            
        }      
    }
}
