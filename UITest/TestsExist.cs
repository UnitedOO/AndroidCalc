using Android.Widget;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
   [TestFixture(Platform.Android)]
   // [TestFixture(Platform.iOS)]
    public class TestsExist
    {
        IApp app;
        Platform platform;
        private Pom calc;

        public TestsExist(Platform platform)
        {
            this.platform = platform;
            calc = new Pom();
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }
               
        [TestCase("textA")]
        [TestCase("textB")]
        [TestCase("textOp")]
        [TestCase("textRes")]
        [TestCase("btnRes")]
        public void TestElementsExist(string id)
        {
            AppResult[] results = app.Query(c => c.Marked(id));
            Assert.IsTrue(results.Length != 0);
        }

        [TestCase("52", "23", "52", "23")]
        [TestCase("611", "344", "611", "344")]
        [TestCase("7456", "4654", "7456", "4654")]
        [TestCase("82340", "10900", "82340", "10900")]
        public void TestComplex(string a, string b, string resA, string resB)
        {
            app.Tap(calc.ANumber);
            app.EnterText(a);
            app.Tap(calc.BNumber);
            app.EnterText(b);
            AppResult[] anum = app.Query(calc.ANumber);
            AppResult[] bnum = app.Query(calc.BNumber);
            Assert.AreEqual(resA, anum[0].Text);
            Assert.AreEqual(resB, bnum[0].Text);
        }

        [TestCase("5", "2", "+", "5", "2", "+")]
        [TestCase("6", "3", "-", "6", "3", "-")]
        [TestCase("7", "4", "*", "7", "4", "*")]
        [TestCase("8", "1", "/", "8", "1", "/")]
        public void TestSimple(string a, string b, string op, string resA, string resB, string resOp)
        {
            app.Tap(calc.ANumber);
            app.EnterText(a);
            app.Tap(calc.BNumber);
            app.EnterText(b);
            app.Tap(calc.Op);
            app.EnterText(op);
            AppResult[] anum = app.Query(calc.ANumber);
            AppResult[] bnum = app.Query(calc.BNumber);
            AppResult[] oper = app.Query(calc.Op);
            Assert.AreEqual(resA, anum[0].Text);
            Assert.AreEqual(resB, bnum[0].Text);
            Assert.AreEqual(resOp, oper[0].Text);
        }

        //[TestCase("11", "7", "+", "18")]
        //[TestCase("14", "3", "-", "11")]
        //[TestCase("15", "6", "*", "90")]
        //[TestCase("80", "20", "/", "4")]
        //public void Calc_RealJob(string a, string b, string op, string expRes)
        //{
        //    app.Tap(calc.ANumber);
        //    app.EnterText(a);
        //    app.Tap(calc.BNumber);
        //    app.EnterText(b);
        //    app.Tap(calc.Op);
        //    app.EnterText(op);
        //    app.Tap(calc.btnRes);
        //    AppResult[] results = app.Query(calc.textRes);
        //    Assert.AreEqual(expRes, results[0].Text);
        //}

    }
}
