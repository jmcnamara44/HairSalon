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
      _id = (int) cmd.LastInsertedId;

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
    public static List<Client> GetClientList(int selectorId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylistId;";
      cmd.Parameters.Add(new MySqlParameter("@stylistId", selectorId));

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      List<Client> clientsById = new List<Client> {};
      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string phoneNumber = rdr.GetString(2);
        int stylistId = rdr.GetInt32(3);
        Client newClient = new Client(clientName, phoneNumber, stylistId, id);
        clientsById.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return clientsById;
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
