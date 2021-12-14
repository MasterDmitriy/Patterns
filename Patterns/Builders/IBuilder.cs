namespace Patterns.Builders
{
    public interface IBuilder<out T> 
        where T : class, new()
    {
        T Build();
    }
}