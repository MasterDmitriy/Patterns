namespace Patterns.Builders
{
    public abstract class Builder<T> : IBuilder<T>
        where T : class, new()
    {
        protected readonly T Entity;

        protected Builder()
        {
            Entity = new T();
        }

        protected Builder(T entity)
        {
            Entity = entity;
        }

        public T Build() => Entity;
    }
}