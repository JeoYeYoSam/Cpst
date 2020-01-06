//using System;
//using System.Windows;
//using System.Windows.Media;
//using MySql.Data.MySqlClient;
//
//namespace cpst
//{
//    class Sensors
//    {        
//
//
//        //listbox von Sensortime
//        private void Checksensor1ontest()
//        {
//
//            MySqlCommand commandDatabase = new MySqlCommand(databaseConnection.querySensor1, databaseConnection.con)
//            {
//                CommandTimeout = 60
//            };
//
//            try
//            {
//
//                databaseConnection.con.Open();
//
//                MySqlDataReader myReader = commandDatabase.ExecuteReader();
//
//
//                if (myReader.HasRows)
//                {
//
//                    for (int n = cpst_main.listboxsensor1on.Items.Count - 1; n >= 0; --n)
//                    {
//                        {
//                            cpst_main.listboxsensor1on.Items.RemoveAt(n);
//                        }
//
//                    }
//
//                    while (myReader.Read())
//                    {
//
//                        Console.WriteLine(myReader["time on"].ToString());
//                        cpst_main.listboxsensor1on.Items.Add("von: " + myReader.GetString("time on"));
//                    }
//
//                    databaseConnection.con.Close();
//                }
//                else
//                {
//                    MessageBox.Show("Query successfully executet but the row from table has no entries");
//                }
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show("Query error: " + e.Message);
//            }
//        }
//        //listbox bis Sensortime
//        private void Checksensor1offtest()
//        {
//
//            MySqlCommand commandDatabase = new MySqlCommand(databaseConnection.querySensor1, databaseConnection.con)
//            {
//                CommandTimeout = 60
//            };
//
//            try
//            {
//
//                databaseConnection.constring.Open();
//
//                MySqlDataReader myReader = commandDatabase.ExecuteReader();
//
//
//                if (myReader.HasRows)
//                {
//
//                    for (int n = cpst_main.listboxsensor1off.Items.Count - 1; n >= 0; --n)
//                    {
//                        {
//                            cpst_main.listboxsensor1off.Items.RemoveAt(n);
//                        }
//
//                    }
//
//                    while (myReader.Read())
//                    {
//
//                        Console.WriteLine(myReader["time off"].ToString());
//                        this.cpst_main.listboxsensor1off.Items.Add("bis: " + myReader.GetString("time off"));
//                    }
//
//                    databaseConnection.constring.Close();
//                }
//                else
//                {
//                    MessageBox.Show("Query successfully executet but the row from table has no entries");
//                }
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show("Query error: " + e.Message);
//            }
//        }
//
//
//        private void Sensor1Data()
//        {
//            cpst_main.listboxSensor1Data.Items.Clear();
//
//            for (int n = cpst_main.listboxstatus.Items.Count - 1; n >= 0; --n)
//            {
//
//                cpst_main.listboxSensor1Data.Items.Add(cpst_main.listboxsensor1on.Items[n] + " " + cpst_main.listboxsensor1off.Items[n] + " " + cpst_main.listboxstatus.Items[n]);
//            }
//
//        }
//
//}
