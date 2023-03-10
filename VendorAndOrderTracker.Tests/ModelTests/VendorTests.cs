using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorAndOrderTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorAndOrderTracker.Tests
{
  [TestClass]
  public class VendorTests
  {
    [TestInitialize]
    public void ClearAll_VendorsInitializedEmpty()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstancesOfVendorWithDescription_Vendor()
    {
        string vendorName = "Suzie's Cafe";
        string vendorDescription = "A cozy cafe serving breakfast and lunch";
        Vendor newVendor = new Vendor(vendorName, vendorDescription);

        Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }


    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Test Vendor";
      Vendor newVendor = new Vendor(name, "description");

      string result = newVendor.Name;
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetId_ReturnsVendorId_Int()
    {
      string name = "Test Vendor";
      Vendor newVendor = new Vendor(name, "description");

      int result = newVendor.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      string name1 = "Suzie's Cafe";
      string name2 = "Husky Deli";
      Vendor newVendor1 = new Vendor(name1, "description");
      Vendor newVendor2 = new Vendor(name2, "description");
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2};

      List<Vendor> result = Vendor.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      string name1 = "Suzie's Cafe";
      string name2 = "Husky Deli";
      Vendor newVendor1 = new Vendor(name1, "description");
      Vendor newVendor2 = new Vendor(name2, "description");

      Vendor result = Vendor.Find(2);

      Assert.AreEqual(newVendor2, result);
    }

    [TestMethod]
    public void AddOrder_AssociatesOrderWithVendor_OrderList()
    {
      string description = "10 Bread";
      decimal price = 10.00m;
      DateTime date = new DateTime(2022, 3, 1);
      Order newOrder = new Order(description, "vendor", price, date); // add fourth argument
      List<Order> newList = new List<Order> { newOrder };
      string name = "Suzie's Cafe";
      Vendor newVendor = new Vendor(name, "description");
      newVendor.AddOrder(newOrder);

      List<Order> result = newVendor.Orders;

      CollectionAssert.AreEqual(newList, result);
    }
    
  }
}
