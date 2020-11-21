using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Contracts
{

    public enum Brand { Audi, BMW, Citroen, Fiat, Nissan}

    public class Car
    {
        Brand brand;
        string model;
        int year;
        int horsepower;

        public Car(Brand brand, string model, int year, int horsepower)
        {
            this.brand = brand;
            this.model = model;
            this.year = year;
            this.horsepower = horsepower;
        }
    }
}
