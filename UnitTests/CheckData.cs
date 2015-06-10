using System;
using NUnit.Framework;
using NUnit;
using Ninject.Modules;

namespace UnitTests
{
    [TestFixture]
    public class CheckData
    {
        [Test]
        public void TestMethod1()
        {
            
        }
    }

    class LoadData : NinjectModule
    {
        public override void Load()
        {
            //this.Bind<List<Flow>>().To<Educ>()
        }
    }
}
