using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using somersby.Tools;

namespace somersytest
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager log = new LogManager(null,"_somersbytest");
            log.WriteLine("[Begin Processing]----");

            for ( int index = 0; index <10; index++)
            {
                log.WriteLine("Processing : " + index);

                //do
                System.Threading.Thread.Sleep(500);

                log.WriteLine("Done : " + index);
            }
            log.WriteLine("[End Processtin]----");

        }
    }
}
