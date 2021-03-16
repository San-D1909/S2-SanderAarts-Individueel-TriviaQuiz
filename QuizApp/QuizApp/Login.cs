using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Web.Mvc;
using QuizApp.Models;

namespace QuizApp
{
    public class Login
    {
        public static UserModel SelectUserData(string Uname, string Password, UserModel userModel)
        {

            if (Uname != null)
            {
                List<string> Commands = new List<string>
            {
                "SELECT `unique_id` FROM `user` WHERE `email` = '" + Uname + "' AND `password` = '" + Password + "';",
                "SELECT `firstname` FROM `user` WHERE `email` = '" + Uname + "' AND `password` = '" + Password + "';",
                "SELECT `lastname` FROM `user` WHERE `email` = '" + Uname + "' AND `password` = '" + Password + "';",
                "SELECT `adres` FROM `user` WHERE `email` = '" + Uname + "' AND `password` = '" + Password + "';",
                "SELECT `gender` FROM `user` WHERE `email` = '" + Uname + "' AND `password` = '" + Password + "';"
            };
                List<string> userInfo = new List<string> { };
                MySqlConnection databaseConnection = new MySqlConnection(QuizApp.Models.DB_Credentials.DbConnectionString);
                for (int i = 0; i < Commands.Count; i++)
                {

                    MySqlCommand command = new MySqlCommand(Commands[i], databaseConnection);
                    command.CommandTimeout = 60;
                    try
                    {
                        databaseConnection.Open();
                        MySqlDataReader executeString = command.ExecuteReader();
                        while (executeString.Read())
                        {
                            string output = executeString.GetString(0);
                            if (output != "")
                            {
                                userInfo.Add(output);
                                databaseConnection.Close();
                                executeString.Close();
                            }
                            else
                            {
                                databaseConnection.Close();
                                return null;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("error: " + e.Message);
                    }
                }
                if (userInfo.Count > 0)
                {
                    userModel.Unique_id = userInfo[0];
                    userModel.First_Name = userInfo[1];
                    userModel.Last_Name = userInfo[2];
                    userModel.Adress = userInfo[3];
                    userModel.Gender = userInfo[4];
                    return userModel;
                }
                else
                {
                    userModel.Unique_id = "0";
                    return userModel;
                }
            }
                return null;
        }
    }
}