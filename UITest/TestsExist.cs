using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace UITest
{
    [TestFixture(Platform.Android)]
   // [TestFixture(Platform.iOS)]
    public class TestsExist
    {
        IApp app;
        Platform platform;

        public TestsExist(Platform platform)
        {
            this.platform = platform;
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
        public void TestElements(string id)
        {
            app.Tap(id);
        }
    }
}
