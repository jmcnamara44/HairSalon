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
  }
}
