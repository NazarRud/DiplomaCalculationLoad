using System;
using System.Linq;
using Data;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataModel dm = new DataModel())
            {
                Console.WriteLine(dm.Database.Connection.ConnectionString);

               Console.WriteLine(dm.Faculties.Count());
                var a = dm.Cathedras.ToList();

                foreach (var cathedra in a)
                {
                    Console.WriteLine(cathedra.Faculty.Name);
                }
            }
        }
    }
}
