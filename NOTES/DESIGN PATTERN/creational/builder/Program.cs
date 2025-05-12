using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder
{
    class Car
    {
        public int Seats { get; set; }
        public String Engine { get; set; }
        public bool TripComputer { get; set; }
        public bool Gps { get; set; }

        public void ShowSpecifications()
        {
            Console.WriteLine($"Seats; {Seats}");
            Console.WriteLine($"Engine: {Engine}");
            Console.WriteLine($"TripComputer; {TripComputer}");
            Console.WriteLine($"Gps; {Gps}");
        }
    }

    class MAnual
    {
        public string SeatInstructions { get; set; }
        public string EngineInstructions { get; set; }
        public string TripComputerInstructions { get; set; }
        public string GpsInstructions { get; set; }
        public void ShowInstructions()
        {
            Console.WriteLine($"Seat Instructions: {SeatInstructions}");
            Console.WriteLine($"Engine Instructions: {EngineInstructions}");
            Console.WriteLine($"Trip Computer Instructions: {TripComputerInstructions}");
            Console.WriteLine($"GPS Instructions: {GpsInstructions}");
        }
    }

    interface IBuilder
    {
        void Reset();
        void SetSeats(int number);
        void SetEngine(String engine);
        void SetTripComputer(bool tripComputer);
        void SetGps(bool hasGps);
    }
    class CarBuilder : IBuilder
    {
        private Car car;
        public CarBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this.car = new Car();
        }
        public void SetSeats(int number)
        {
            this.car.Seats = number;
        }

        public void SetEngine(string engine)
        {
            this.car.Engine = engine;
        }
        public void SetTripComputer(bool hasTripComputer)
        {
            this.car.TripComputer = hasTripComputer;
        }
        public void SetGps(bool hasGps)
        {
            this.car.Gps = hasGps;
        }

        public Car GetProduct()
        {
            Car product = this.car;
            this.Reset();
            return product;
        }
    }
    class CarManualBuilder : IBuilder
    {
        private MAnual manual;
        public CarManualBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this.manual = new MAnual();
        }

        public void SetSeats(int number)
        {
            this.manual.SeatInstructions = $"This car has {number} seats.";

        }

        public void SetEngine(string engine)
        {
            this.manual.EngineInstructions = $"This car uses a {engine} engine.";
        }

        public void SetTripComputer(bool hasTripComputer)
        {
            this.manual.TripComputerInstructions = hasTripComputer ? "This car has a trip computer." : "This car does not have a trip computer.";
        }

        public void SetGps(bool hasGps)
        {
            this.manual.GpsInstructions = hasGps ? "This car has a GPS system." : "This car does not have a GPS system.";
        }

        public MAnual GetProduct()
        {
            MAnual product = this.manual;
            this.Reset();
            return product;
        }
    }

    class Director
    {
        public void ConstructSportsCar(IBuilder builder)
        {

            builder.Reset();
            builder.SetSeats(2);
            builder.SetEngine("SportEngine");
            builder.SetTripComputer(true);
            builder.SetGps(true);
        }


        public void ConstructSUV(IBuilder builder)
        {
            builder.Reset();
            builder.SetSeats(5);
            builder.SetEngine("SUVEngine");
            builder.SetTripComputer(true);
            builder.SetGps(true);
        }
    }

    class Application
    {
        public static void Main(string[] args)
        {
            Director director = new Director();
            CarBuilder carBuilder = new CarBuilder();
            director.ConstructSportsCar(carBuilder);
            Car car = carBuilder.GetProduct();
            car.ShowSpecifications();
            CarManualBuilder manualBuilder = new CarManualBuilder();
            director.ConstructSportsCar(manualBuilder);
            MAnual manual = manualBuilder.GetProduct();
            manual.ShowInstructions();
        }
    }
}