using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _name;
    private string _daysAvailable;
    private int _yearsActive;
    private string _phoneNumer;
    private int _id;

    public Stylist(string name, string daysAvailable, int yearsActive, string phoneNumber, int id = 0)
    {
      _name = name;
      _daysAvailable = daysAvailable;
      _yearsActive = yearsActive;
      _phoneNumer = phoneNumber;
      _id = id;
    }
    public static List<Stylist> GetAllStylists()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string daysAvailable = rdr.GetString(2);
        int yearsActive = rdr.GetInt32(3);
        string phone = rdr.GetString(4);
        Stylist newStylist = new Stylist(name, daysAvailable, yearsActive, phone, id);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }
  }
}
