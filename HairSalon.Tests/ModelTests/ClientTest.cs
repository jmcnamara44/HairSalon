using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
    }
    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jimmy_mcnamara_test;";
    }
    [TestMethod]
    public void GetAllClients_DbStartsEmpty_0()
    {
      int result = Client.GetAllClients().Count;
      Assert.AreEqual(0, result);
    }
    [TestMethod]
    public void Save_SaveToDb_ClientList()
    {
      Client testClient = new Client("name", "555-5555", 3);
      testClient.Save();
      List<Client> testList1 = Client.GetAllClients();
      List<Client> testList2 = new List<Client> {testClient};
      Assert.AreEqual(testList1[0].GetName(), testList2[0].GetName());
    }
  }
}
