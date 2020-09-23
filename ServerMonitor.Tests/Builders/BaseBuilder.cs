namespace ServerMonitor.Tests.Builders
{
    internal class BaseBuilder<T> where T : class, new()
    {
        protected readonly T Obj;

        public BaseBuilder()
        {
            this.Obj = new T();
        }

        public T Build()
        {
            return this.Obj;
        }
    }
}
