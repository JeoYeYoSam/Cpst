using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace cpst
{
    class DatabaseManager
    {
        private string querySensor1 = "select * From sensor_one";
        private string querySensor2 = "select * From sensor_two";
        private string querySensor3 = "select * From sensor_three";
        private string querySensor4 = "select * From sensor_four";
        private string querySensor5 = "select * From sensor_five";
        private string querySensor6 = "select * From sensor_six";
        private string checkcanlogin;
        

        //Connection String to connect to Database
        private MySqlConnection con = new MySqlConnection(@"Server=localhost;Port=3306;Uid=root;pwd=qweasd;Database=db_laser_sensor");   
        
        public void Open()
        {
            con.Open();
        }        
        public void Close()
        {
            con.Close();
        }

        public string hashingPassword(string password)
        {
            var hashAlgorithm = new Org.BouncyCastle.Crypto.Digests.Sha3Digest(512);
            
            byte[] input = Encoding.ASCII.GetBytes(password);

            hashAlgorithm.BlockUpdate(input, 0, input.Length);

            byte[] result = new byte[64]; 
            hashAlgorithm.DoFinal(result, 0);

            string hashString = BitConverter.ToString(result);
            hashString = hashString.Replace("-", "").ToLowerInvariant();            
            return hashString;            
        }        

        public void ChangePassword(string newpassword)
        {
            con.Open();
            string query = "UPDATE users SET password = '" + hashingPassword(newpassword) + "' WHERE username = '"+ Global.username + "'";
            MySqlCommand commandDatabase = new MySqlCommand(query, con);
            commandDatabase.ExecuteReader();
            con.Close();
        }


        // Method to analyse login when loginButton is pressed or hit the Enter Key
        public bool Login(string username, string password)
        {
            string queryAuthentication = $"SELECT * FROM users WHERE username ='"+username+"' AND password='"+hashingPassword(password)+"'";
            
            try
            {
                Open();                         
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
                Close();
            }
        }

        private string GetSensorQueryString(SensorTypes sentype)
        {
            switch (sentype)
            {
                case SensorTypes.Sensor1:
                    return querySensor1;
                case SensorTypes.Sensor2:
                    return querySensor2;
                case SensorTypes.Sensor3:
                    return querySensor3;
                case SensorTypes.Sensor4:
                    return querySensor4;
                case SensorTypes.Sensor5:
                    return querySensor5;
                case SensorTypes.Sensor6:
                    return querySensor6;
            }
            return null;
        }
        public List<string> GetSensorStatusTime(SensorTypes sentype)
        {
            Open();

            MySqlCommand commandDatabase = new MySqlCommand(GetSensorQueryString(sentype), con)
            {
                CommandTimeout = 60
            };

            try
            {
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                if (myReader.HasRows)
                {
                    List<string> valuesStatusTime = new List<string>();

                    while (myReader.Read())
                    {
                        valuesStatusTime.Add(Convert.ToString(myReader["time"]));
                    }
                    return valuesStatusTime;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error: " + e.Message);

            }
            finally
            {
                Close();
            }
            return new List<string>();
        }

        public List<int> GetSensorStatus(SensorTypes sentype)
        {
            Open();

            MySqlCommand commandDatabase = new MySqlCommand(GetSensorQueryString(sentype),con)
            {
                CommandTimeout = 60
            };

            try
            {
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                if (myReader.HasRows)
                {
                    List<int> valuesStatus = new List<int>();
                   
                    while (myReader.Read())
                    {                           
                        valuesStatus.Add(Convert.ToInt32(myReader["status"]));                        
                    }                                        
                    return valuesStatus;                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Query error: " + e.Message);
                
            }
            finally
            {
                Close();
            }
            return new List<int>();            
        }

    }
}
