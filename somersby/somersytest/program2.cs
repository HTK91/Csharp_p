using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using somersby.Tools;
using somersby.Extensions;

namespace somersytest
{
    class program2
    {
        static void Main(string[] args)
        {
            string temp = "test";

            Console.WriteLine("IsNumeric? : " + temp.IsNumeric());
            Console.WriteLine("IsDateTime? : " + temp.IsDateTime());
        }
    }
}
