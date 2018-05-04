using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    private string _name;
    private string _phoneNumer;
    private int _stylistId;
    private int _id;

    public Client(string name, string phoneNumber, int stylistId, int id = 0)
    {
      _name = name;
      _phoneNumer = phoneNumber;
      _stylistId = stylistId;
      _id = id;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumer;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }
    public int GetId()
    {
      return _id;
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, phone_number, stylist_id) VALUES (@name, @phoneNumber, @stylistId);";

      cmd.Parameters.Add(new MySqlParameter("@name", _name));
      cmd.Parameters.Add(new MySqlParameter("@phoneNumber", _phoneNumer));
      cmd.Parameters.Add(new MySqlParameter("@stylistId", _stylistId));

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;  // Notice the slight update to this line of code!

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static List<Client> GetAllClients()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string phone = rdr.GetString(2);
        int stylistId = rdr.GetInt32(3);
        Client newClient = new Client(name, phone, stylistId, id);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
