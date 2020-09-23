namespace ServerMonitor.Tests
{
    using NUnit.Framework;
    using ServerMonitor.Tests.Contexts;

    internal class BaseTest<T,K> 
        where T : class 
        where K : BaseContext<T>, new()
    {
        protected K Context;

        [SetUp]
        public void Setup()
        {            
            this.Context = new K();
        }
    }
}
