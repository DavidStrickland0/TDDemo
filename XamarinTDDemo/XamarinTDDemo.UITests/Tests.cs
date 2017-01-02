using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinTDDemo.UITests
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }
        [Test]
        public void CalculatorFormLoads()
        {
            app.WaitForElement(c => c.Class("PageRenderer"));
            Assert.Pass();
        }
        [Test]
        public void CalculatorHasStartTimeControl()
        {
            app.WaitForElement(c => c.Class("PageRenderer"));
            var startTimeControls = app.Query(c=>c.Marked("StartTimeControl"));
            Assert.IsTrue(startTimeControls!=null && startTimeControls.Count()>0);
        }

        [Test]
        public void CalculatorHasBedTimeControl()
        {
            app.WaitForElement(c => c.Class("PageRenderer"));
            var bedTimeControls = app.Query(c => c.Marked("BedTimeControl"));
            Assert.IsTrue(bedTimeControls != null && bedTimeControls.Count() > 0);
        }

        [Test]
        public void CalculatorHasFinishedTimeControl()
        {
            app.WaitForElement(c => c.Class("PageRenderer"));
            var finishedTimeControls = app.Query(c => c.Marked("FinishedTimeControl"));
            Assert.IsTrue(finishedTimeControls != null && finishedTimeControls.Count() > 0);
        }

        [Test]
        public void CalculatorHasCalculateControl()
        {
            app.WaitForElement(c => c.Class("PageRenderer"));
            var calculateControls = app.Query(c => c.Marked("CaculateButton"));
            Assert.IsTrue(calculateControls != null && calculateControls.Count() > 0);
        }

        [Test]
        public void CaclulateTime()
        {
            app.WaitForElement(c => c.Class("PageRenderer"));
            var finishedTimeControls = app.Query(c => c.Marked("FinishedTimeControl"));
            var bedTimeControls = app.Query(c => c.Marked("BedTimeControl"));
            var startTimeControls = app.Query(c => c.Marked("StartTimeControl"));

            app.EnterText("StartTimeControl", "5:00 pm");
            app.EnterText("BedTimeControl", "9:00 pm");
            app.EnterText("FinishedTimeControl", "4:00 am");

            app.Tap("CaculateButton");

            var resultControls = app.Query(c => c.Marked("CalculateResult"));
            string actual = resultControls.First().Text;
            Assert.AreEqual("136", actual);

        }

    }
}

