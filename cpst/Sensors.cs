//using System;
//using System.Windows;
//using System.Windows.Media;
//using MySql.Data.MySqlClient;

//namespace cpst
//{
//    class Sensors
//    {

//        private int sensor1status;
//        private int sensor2status;
//        private int sensor3status;
//        private int sensor4status;
//        private int sensor5status;
//        private int sensor6status;

//        readonly DatabaseManager databaseConnection = new DatabaseManager();
//        readonly Cpst_main cpst_main = new Cpst_main();


//        //listbox von Sensortime
//        private void Checksensor1ontest()
//        {

//            MySqlCommand commandDatabase = new MySqlCommand(databaseConnection.querySensor1, databaseConnection.con)
//            {
//                CommandTimeout = 60
//            };

//            try
//            {

//                databaseConnection.con.Open();

//                MySqlDataReader myReader = commandDatabase.ExecuteReader();


//                if (myReader.HasRows)
//                {

//                    for (int n = cpst_main.listboxsensor1on.Items.Count - 1; n >= 0; --n)
//                    {
//                        {
//                            cpst_main.listboxsensor1on.Items.RemoveAt(n);
//                        }

//                    }

//                    while (myReader.Read())
//                    {

//                        Console.WriteLine(myReader["time on"].ToString());
//                        cpst_main.listboxsensor1on.Items.Add("von: " + myReader.GetString("time on"));
//                    }

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

//            MySqlCommand commandDatabase = new MySqlCommand(databaseConnection.querySensor1, databaseConnection.con)
//            {
//                CommandTimeout = 60
//            };

//            try
//            {

//                databaseConnection.constring.Open();

//                MySqlDataReader myReader = commandDatabase.ExecuteReader();


//                if (myReader.HasRows)
//                {

//                    for (int n = cpst_main.listboxsensor1off.Items.Count - 1; n >= 0; --n)
//                    {
//                        {
//                            cpst_main.listboxsensor1off.Items.RemoveAt(n);
//                        }

//                    }

//                    while (myReader.Read())
//                    {

//                        Console.WriteLine(myReader["time off"].ToString());
//                        this.cpst_main.listboxsensor1off.Items.Add("bis: " + myReader.GetString("time off"));
//                    }

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


//        //Check Sensors from database
//        private void Checksensor1()
//        {


//        }
//        private void Sensor1Data()
//        {
//            cpst_main.listboxSensor1Data.Items.Clear();

//            for (int n = cpst_main.listboxstatus.Items.Count - 1; n >= 0; --n)
//            {

//                cpst_main.listboxSensor1Data.Items.Add(cpst_main.listboxsensor1on.Items[n] + " " + cpst_main.listboxsensor1off.Items[n] + " " + cpst_main.listboxstatus.Items[n]);
//            }

//        }

//        private void Checksensor2()
//        {

//            MySqlCommand commandDatabase = new MySqlCommand(databaseConnection.querySensor2, databaseConnection.con)
//            {
//                CommandTimeout = 60
//            };


//            try
//            {

//                databaseConnection.constring.Open();

//                MySqlDataReader myReader = commandDatabase.ExecuteReader();


//                if (myReader.HasRows)
//                {
//                    while (myReader.Read())
//                    {

//                        Console.WriteLine(myReader["status"].ToString());
//                        this.sensor2status = myReader.GetInt16("status");

//                    }

//                    if (this.sensor2status == 0)
//                    {
//                        cpst_main.circle_fill_color_2.Fill = Brushes.Gray;
//                        databaseConnection.constring.Close();
//                    }
//                    else
//                    {
//                        if (this.sensor2status == 1)
//                        {
//                            cpst_main.circle_fill_color_2.Fill = Brushes.Green;
//                            databaseConnection.constring.Close();
//                        }
//                        else
//                        {
//                            cpst_main.circle_fill_color_2.Fill = Brushes.Red;
//                            databaseConnection.constring.Close();
//                        }
//                    }

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


//        private void Checksensor3()
//        {

//            MySqlCommand commandDatabase = new MySqlCommand(databaseConnection.querySensor3, databaseConnection.con)
//            {
//                CommandTimeout = 60
//            };


//            try
//            {

//                databaseConnection.constring.Open();

//                MySqlDataReader myReader = commandDatabase.ExecuteReader();


//                if (myReader.HasRows)
//                {
//                    while (myReader.Read())
//                    {

//                        Console.WriteLine(myReader["status"].ToString());
//                        this.sensor3status = myReader.GetInt16("status");

//                    }

//                    if (this.sensor3status == 0)
//                    {
//                        cpst_main.circle_fill_color_3.Fill = Brushes.Gray;
//                        databaseConnection.constring.Close();
//                    }
//                    else
//                    {
//                        if (this.sensor3status == 1)
//                        {
//                            cpst_main.circle_fill_color_3.Fill = Brushes.Green;
//                            databaseConnection.constring.Close();
//                        }
//                        else
//                        {
//                            cpst_main.circle_fill_color_3.Fill = Brushes.Red;
//                            databaseConnection.constring.Close();
//                        }
//                    }

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

//        private void Checksensor4()
//        {

//            MySqlCommand commandDatabase = new MySqlCommand(databaseConnection.querySensor4, databaseConnection.con)
//            {
//                CommandTimeout = 60
//            };


//            try
//            {

//                databaseConnection.constring.Open();

//                MySqlDataReader myReader = commandDatabase.ExecuteReader();


//                if (myReader.HasRows)
//                {
//                    while (myReader.Read())
//                    {

//                        Console.WriteLine(myReader["status"].ToString());
//                        this.sensor4status = myReader.GetInt16("status");

//                    }

//                    if (this.sensor4status == 0)
//                    {
//                        cpst_main.circle_fill_color_4.Fill = Brushes.Gray;
//                        databaseConnection.constring.Close();
//                    }
//                    else
//                    {
//                        if (this.sensor4status == 1)
//                        {
//                            cpst_main.circle_fill_color_4.Fill = Brushes.Green;
//                            databaseConnection.constring.Close();
//                        }
//                        else
//                        {
//                            cpst_main.circle_fill_color_4.Fill = Brushes.Red;
//                            databaseConnection.constring.Close();
//                        }
//                    }

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
//        private void Checksensor5()
//        {

//            MySqlCommand commandDatabase = new MySqlCommand(databaseConnection.querySensor5, databaseConnection.con)
//            {
//                CommandTimeout = 60
//            };


//            try
//            {

//                databaseConnection.constring.Open();

//                MySqlDataReader myReader = commandDatabase.ExecuteReader();


//                if (myReader.HasRows)
//                {
//                    while (myReader.Read())
//                    {

//                        Console.WriteLine(myReader["status"].ToString());
//                        this.sensor5status = myReader.GetInt16("status");

//                    }

//                    if (this.sensor5status == 0)
//                    {
//                        cpst_main.circle_fill_color_5.Fill = Brushes.Gray;
//                        databaseConnection.constring.Close();
//                    }
//                    else
//                    {
//                        if (this.sensor5status == 1)
//                        {
//                            cpst_main.circle_fill_color_5.Fill = Brushes.Green;
//                            databaseConnection.constring.Close();
//                        }
//                        else
//                        {
//                            cpst_main.circle_fill_color_5.Fill = Brushes.Red;
//                            databaseConnection.constring.Close();
//                        }
//                    }

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
//        private void Checksensor6()
//        {

//            MySqlCommand commandDatabase = new MySqlCommand(databaseConnection.querySensor6, databaseConnection.con)
//            {
//                CommandTimeout = 60
//            };


//            try
//            {

//                databaseConnection.constring.Open();

//                MySqlDataReader myReader = commandDatabase.ExecuteReader();


//                if (myReader.HasRows)
//                {
//                    while (myReader.Read())
//                    {

//                        Console.WriteLine(myReader["status"].ToString());
//                        this.sensor6status = myReader.GetInt16("status");

//                    }

//                    if (this.sensor6status == 0)
//                    {
//                        cpst_main.circle_fill_color_6.Fill = Brushes.Gray;
//                        databaseConnection.constring.Close();
//                    }
//                    else
//                    {
//                        if (this.sensor6status == 1)
//                        {
//                            cpst_main.circle_fill_color_6.Fill = Brushes.Green;
//                            databaseConnection.constring.Close();
//                        }
//                        else
//                        {
//                            cpst_main.circle_fill_color_6.Fill = Brushes.Red;
//                            databaseConnection.constring.Close();
//                        }
//                    }

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

//        public void Checkallsensors()
//        {
//            Checksensor1();
//            Checksensor1ontest();
//            Checksensor1offtest();
//            Sensor1Data();
//            Checksensor2();
//            Checksensor3();
//            Checksensor4();
//            Checksensor5();
//            Checksensor6();
//        }
//    }
//}
