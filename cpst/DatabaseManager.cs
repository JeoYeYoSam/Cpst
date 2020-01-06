﻿using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Collections.Generic;

namespace cpst
{
    class DatabaseManager
    {
        public string querySensor1 = "select * From sensor_one";
        public string querySensor2 = "select * From sensor_two";
        public string querySensor3 = "select * From sensor_three";
        public string querySensor4 = "select * From sensor_four";
        public string querySensor5 = "select * From sensor_five";
        public string querySensor6 = "select * From sensor_six";
        public string checkcanlogin;
        public string username;
       

        //Connection String to connect to Database
        public MySqlConnection con = new MySqlConnection(@"Server=192.168.0.102;Port=3306;Uid=root;pwd=qweasd;Database=db_laser_sensor");   
        
        public void Open()
        {
            con.Open();
        }        
        public void Close()
        {
            con.Close();
        }
        
        // Method to analyse login when loginButton is pressed or hit the Enter Key
        public bool Login(string username, string password)
        {
            string queryAuthentication = $"SELECT * FROM users WHERE username ='"+username+"' AND password='"+password+"'";

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
                    List<int> values = new List<int>();
                    
                    while (myReader.Read())
                    {                           
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
                Close();
            }
            return new List<int>();            
        }


      


    }
}
