namespace Interfaces;
public interface ILocator  
{  
    T GetService<T>();  
} 