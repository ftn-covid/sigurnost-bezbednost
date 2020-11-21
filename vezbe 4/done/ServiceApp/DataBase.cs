using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceApp
{
    public class Database
    {
        internal static Dictionary<int, Car> cars = new Dictionary<int, Car>();

        static Database()
        {
            Car c1 = new Car(Brand.Audi, "A1", 2015, 90);
            Car c2 = new Car(Brand.BMW, "Q3", 2017, 140);
            Car c3 = new Car(Brand.Nissan, "Qashqai", 2020, 160);

            cars.Add(1, c1);
            cars.Add(2, c2);
            cars.Add(3, c3);
        }
    }
}
