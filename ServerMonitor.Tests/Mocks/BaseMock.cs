namespace ServerMonitor.Tests.Mocks
{
    using Moq;

    internal class BaseMock<T> where T : class
    {
        protected readonly Mock<T> Mock;

        public BaseMock()
        {
            this.Mock = new Mock<T>();
        }

        public T Object => this.Mock.Object;
    }
}
