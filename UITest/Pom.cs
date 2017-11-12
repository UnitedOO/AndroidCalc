using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest.Queries;

namespace UITest
{
    public class Pom
    {
        public Func<AppQuery, AppQuery> ANumber { get; } = c => c.Id("textA");

        public Func<AppQuery, AppQuery> BNumber { get; } = c => c.Id("textB");

        public Func<AppQuery, AppQuery> Op { get; } = c => c.Id("textOp");

        public Func<AppQuery, AppQuery> btnRes { get; } = c => c.Id("btnRes");

        public Func<AppQuery, AppQuery> textRes { get; } = c => c.Id("textRes");
    }
}