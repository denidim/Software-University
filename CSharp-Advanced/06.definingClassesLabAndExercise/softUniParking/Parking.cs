using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;

        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new Dictionary<string, Car>();
        }

        public int Count => cars.Count;

        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }
            if (cars.Count == capacity)
            {
                return $"Parking is full!";
            }
            cars.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {

            if (!cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            cars.Remove(registrationNumber);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber) => cars.FirstOrDefault(x => x.Key == registrationNumber).Value;

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var num in RegistrationNumbers)
            {
                cars.Remove(num);
            }
        }

    }
}
