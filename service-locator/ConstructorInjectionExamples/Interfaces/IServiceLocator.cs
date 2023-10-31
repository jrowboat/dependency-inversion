namespace Interfaces;
public interface IServiceLocator
{
  T GetService<T>();
}