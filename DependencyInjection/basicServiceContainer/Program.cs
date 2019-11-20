using System;
using Microsoft.Extensions.DependencyInjection;

namespace basicServiceContainer
{
    class Program
    {
        static void Main(string[] args)
        {
               var collection = new ServiceCollection();
            collection.AddScoped<IDataAccess, APIDataAccess>();
            var provider = collection.BuildServiceProvider();

            var data = provider.GetService<IDataAccess>();
            Console.WriteLine(data.GetType());
        }
    }

    public interface IDataAccess { }

    public class DBDataAccess : IDataAccess
    {

    }

    public class APIDataAccess : IDataAccess
    {

    }



}