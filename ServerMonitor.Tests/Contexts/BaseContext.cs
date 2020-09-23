namespace ServerMonitor.Tests.Contexts
{
    internal class BaseContext<T> where T : class
    {
        protected T Obj;

        public T Build()
        {
            return this.Obj;
        }
    }
}
