using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VendorAndOrderTracker.Models;
using System;

namespace VendorAndOrderTracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("test", "test order", 10.00m, DateTime.Now);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string description = "10 Breads";

      Order newOrder = new Order("test", description, 10.00m, DateTime.Now);
      string result = newOrder.Description;

      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      string description = "10 Breads";
      Order newOrder = new Order("test", description, 10.00m, DateTime.Now);

      string updatedDescription = "20 Pastries";
      newOrder.Description = updatedDescription;
      string result = newOrder.Description;

      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      List<Order> newList = new List<Order> { };

      List<Order> result = Order.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsOrders_OrderList()
    {
      string description1 = "10 Breads";
      string description2 = "20 Pastries";
      Order newOrder1 = new Order("test", description1, 10.00m, DateTime.Now);
      Order newOrder2 = new Order("test", description2, 15.00m, DateTime.Now);
      List<Order> newList = new List<Order> {newOrder1, newOrder2};

      List<Order> result = Order.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
      string description1 = "10 Breads";
      string description2 = "20 Pastries";
      Order newOrder1 = new Order("test", description1, 10.00m, DateTime.Now);
      Order newOrder2 = new Order("test", description2, 15.00m, DateTime.Now);

      Order result = Order.Find(2);

      Assert.AreEqual(newOrder2, result);
    }

    [TestMethod]
    public void GetAll_ReturnsOrdersInOrder_OrderList()
    {
      string description1 = "10 Breads";
      string description2 = "20 Pastries";
      Order newOrder1 = new Order("test", description1, 10.00m, DateTime.Now);
      Order newOrder2 = new Order("test", description2, 15.00m, DateTime.Now);

      List<Order> result = Order.GetAll();

      Assert.AreEqual(newOrder1, result[0]);
      Assert.AreEqual(newOrder2, result[1]);
    }
    
  }
}
