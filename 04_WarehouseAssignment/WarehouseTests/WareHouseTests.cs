using Microsoft.VisualStudio.TestTools.UnitTesting;
using WareHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Tests
{
    [TestClass()]
    public class WareHouseTests
    {
        [TestMethod()]
        public void AddToStockTest()
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("red shirt", 20);
            wareHouse.AddToStocks("blue shirt", 0);
          
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToStockAllNumbersInNameTest()
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("854788", 20);
          

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToStockLargeQTest()
        {
            WareHouse wareHouse = new WareHouse();
            
            wareHouse.AddToStocks("rice grain", 100000);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToStockNegativeValueTest()
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("red shirt", -20);
        }
        //¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ in stock
        [TestMethod()]
        public void InStock()
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("red shirt", 20);

          bool answer =  wareHouse.InStock("red shirt");
            Assert.IsTrue(answer);

        }
        [TestMethod()]
        public void InStockWithQZeroTest()
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("red shirt", 0);

            bool answer = wareHouse.InStock("red shirt");
            Assert.IsFalse(answer);

        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void InStockWithQNegativeTest()
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("red shirt", -20); //tää kaatuu jo täs kohtaa ku lisäsin throwit tonne funktioon

            bool answer = wareHouse.InStock("red shirt");
            Assert.IsFalse(answer);

        }
        //¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ take from stock
        [TestMethod()]
     
        public void TakeFromStockTest()
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("red shirt", 20);


            wareHouse.TakeFromStock("red shirt", 6);
            wareHouse.TakeFromStock("red shirt", 0);


        }
        [TestMethod()]
         [ExpectedException(typeof(ArgumentException))]
        public void TakeFromStockMoreThanQTest()
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("red shirt", 20);


            wareHouse.TakeFromStock("red shirt", 126);


        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TakeFromStockNegativeAmountTest()
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("red shirt", 20);

            wareHouse.TakeFromStock("red shirt", -126);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TakeFromStockItemNotExistTest()
        {
            WareHouse wareHouse = new WareHouse();
         
            wareHouse.TakeFromStock("hawk shirt", 3);

        }
        //¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ stock count
        [TestMethod()]
    
        public void StockCountTest()
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("red shirt", 20);

          int count =  wareHouse.StockCount("red shirt");
            Assert.AreEqual(20, count);

        }
        [TestMethod()]
    
        public void StockCountAmountZeroTest()
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("red shirt", 0);

            int count = wareHouse.StockCount("red shirt");
            Assert.AreEqual(0, count);

        }
         [TestMethod()]
       
        public void StockCountAdditionTest()
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("red shirt", 20);
            wareHouse.AddToStocks("red shirt", 10);
            wareHouse.AddToStocks("red shirt", 6);
         int count =  wareHouse.StockCount("red shirt");
            Assert.AreEqual(36, count);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void StockCountNegativeTest() //oversold
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("red shirt", 20);
            wareHouse.TakeFromStock("red shirt", 30); //tää tuottaa jo exceptionin
            int count = wareHouse.StockCount("red shirt");
            Assert.AreEqual(-10, count);

        }
        //¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤¤ funktional
        [TestMethod()]
        public void FunctionalTest() 
        {
            WareHouse wareHouse = new WareHouse();
            wareHouse.AddToStocks("red shirt", 20);
           
            int count = wareHouse.StockCount("red shirt");
            Assert.AreEqual(20, count);

            wareHouse.TakeFromStock("red shirt", 10);
            int count2 = wareHouse.StockCount("red shirt");
            Assert.AreEqual(10, count2);

        }

    }
}

/*TakeFromStock:
    Ota viimeinen esine varastosta.                  mikä viimeinen esine? Viimeksi lisätty esinekö? Tälle ei ole olemassa funtiota
 


*/