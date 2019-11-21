using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.WebClient.Models
{
    public interface IBookRepo
    {
        int GetBookNumber();
    }
    public class BookRepo : IBookRepo
    {
        public int GetBookNumber()
        {
            return 3;
        }
    }
}
