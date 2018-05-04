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

    public string GetName()
    {
      return _name;
    }
    public string GetDaysAvailable()
    {
      return _daysAvailable;
    }
    public int GetYearsActive()
    {
      return _yearsActive;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumer;
    }
    public int GetId()
    {
      return _id;
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
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (stylist_name, days_available, years_active, phone_number) VALUES (@name, @daysAvailable, @yearsActive, @phoneNumber);";

      cmd.Parameters.Add(new MySqlParameter("@name", _name));
      cmd.Parameters.Add(new MySqlParameter("@daysAvailable", _daysAvailable));
      cmd.Parameters.Add(new MySqlParameter("@yearsActive", _yearsActive));
      cmd.Parameters.Add(new MySqlParameter("@phoneNumber", _phoneNumer));

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;  // Notice the slight update to this line of code!

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
