using System;  
using System.Collections.Generic;  
using System.Linq;  
namespace ServiceLocator.StrongExample
{  
    public interface IService  
    {  
        void ExecuteService();  
    }  
    
    public class ReturnService : IService  
    {  
        public void ExecuteService()  
        {  
            Console.WriteLine("Executing Return Service");  
        }  
    }  
  
    public static class ServiceLocator  
    {  
        public static IService objectService = null;  
          
        //Service locator function returning strong type   
        public static IService GetService(IService tempService)  
        {  
            if (objectService == null) return new ReturnService();  
            return objectService;  
        }  
          
        //Execute service  
        public static void ExecuteService()  
        {  
            objectService.ExecuteService();  
        }  
    }  
  
    class Program  
    {  
        static void Main(string[] args)  
         {  
           IService service =  ServiceLocator.GetService(new ReturnService());  
           service.ExecuteService();  
           Console.ReadLine();  
        }  
    }  
}