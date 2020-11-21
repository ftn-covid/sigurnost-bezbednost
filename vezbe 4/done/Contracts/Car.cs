
using System;
using System.Runtime.Serialization;

namespace Contracts
{
    [DataContract]
    public enum Brand {[EnumMember] Audi, [EnumMember] BMW, [EnumMember] Citroen, [EnumMember] Fiat, [EnumMember] Nissan}
    
    [DataContract]
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

        [DataMember]
        public Brand Brand { get => brand; set => brand = value; }
        [DataMember]
        public string Model { get => model; set => model = value; }
        [DataMember]
        public int Year { get => year; set => year = value; }
        [DataMember]
        public int Horsepower { get => horsepower; set => horsepower = value; }

        public override string ToString()
        {
            return String.Format($"Brand : {Brand}, model : {Model}, year : {Year}, horsepower : {Horsepower}");
        }
    }
}
