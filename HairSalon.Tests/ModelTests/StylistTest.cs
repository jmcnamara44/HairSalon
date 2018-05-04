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
  }
}
