using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jimmy_mcnamara_test;";
    }
    [TestMethod]
    public void GetAllStylists_DbStartsEmpty_0()
    {
      int result = Stylist.GetAllStylists().Count;
      Assert.AreEqual(0, result);
    }
    [TestMethod]
    public void Save_SaveToDb_StylistList()
    {
      Stylist testStylist = new Stylist("name", "days", 3, "555-5555");
      testStylist.Save();
      List<Stylist> testList1 = Stylist.GetAllStylists();
      List<Stylist> testList2 = new List<Stylist> {testStylist};
      Assert.AreEqual(testList1[0].GetName(), testList2[0].GetName());
    }
  }
}
