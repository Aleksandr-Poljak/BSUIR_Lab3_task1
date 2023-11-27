using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_3
{
    internal class Car
    {
        public readonly string Make = "no install";
        public string Model = "no install";

        private int petrolTankVolume;
        private double amountPetrol;
        private int currentSpeed;
        private double fuelFlow_100km;
        private double[] wheelPressures;

        public int PetrolTankVolume
        {
            get { return petrolTankVolume; }
            set
            {
                if (value > 0)
                {
                    petrolTankVolume = value;
                }
                else { throw new Exception("Объем бака должен быть больше 0"); }
            }
        }

        public double AmountPetrol
        {
            get { return amountPetrol; }
            set
            {
                if(value> 0 & value <= petrolTankVolume) { amountPetrol = value; }
                else { throw new Exception("Количество топлива должно быть больше 0 и меньше или равно объему бака."); }
            }
        }

        public int CurrentSpeed
        {
            get { return currentSpeed; }
            set
            {
                if( value >= 0 & value<260) { currentSpeed = value; }
                else { throw new Exception("Некорректное значение.Допустимо от 0 до 260"); }
            }
        }

        public double FuelFlow_100km
        {
            get { return fuelFlow_100km; }
            set
            {
                if(value >=1) { fuelFlow_100km = value; }
                else { throw new Exception("Некорректное значение. Допустимо больше 1"); }
            }
        }

        public double[] WheelPressuress {
            get { return wheelPressures; }
            set
            {
                int size = 4;
                wheelPressures = new double[size];
                for(int i = 0; i<size; i++)
                {
                    if (value[i] >= 0){ wheelPressures[i] = value[i]; }
                    else { throw new Exception($"Давление {i} не соотвествует. Все значения должны быть больше или равны 0."); }
                }
               
            } 
        }

        public  Car() 
        { 
            PetrolTankVolume=1;
            AmountPetrol=1;
            CurrentSpeed = 0;
            FuelFlow_100km=1;
            WheelPressuress = new double[] { 1.0, 1.0, 1.0, 1.0 };

        }

        public Car( string make, string model) :this()
        {
            Make = make;
            Model = model;
        }

        public Car(string make, string model, int petrolTankVolume, double amountPetrol, int currentSpeed, double fuelFlow_100km,
           double[] wheelPressuress)
            :this(make, model)
        {
            PetrolTankVolume = petrolTankVolume;
            AmountPetrol = amountPetrol;
            CurrentSpeed = currentSpeed;
            FuelFlow_100km = fuelFlow_100km;
            WheelPressuress = wheelPressuress;
            
        }

        public double RemainingDistance()
        {
            // Опредление максимального пробега на оставшемся топливе.
            return AmountPetrol * (100 / FuelFlow_100km);
        }

        public bool TirePressureMonitoring(double minPressure=1.2)
        {
            //Определяет пробой колеса. (если хотя бы в одном колесе давление меньше нормы – автомобиль останавливается
            bool flatTire = false;
            flatTire = Array.Exists(WheelPressuress, pressure => pressure > minPressure);
            
            if(flatTire)
            {
                CurrentSpeed = 0;
            }
            return flatTire;
        }

        public bool SpeedComparsion(Car car)
        {
            //определяeт более быстрый автомобиль из двух (возвращает true, если скорость текущего авто выше)
            return this.currentSpeed > car.CurrentSpeed;
        }

        public static Car? SpeedComparsion(Car car1, Car car2, Car car3)
        {
            // метод, определяющий более быстрый автомобиль из трех (возвращает авто, чья скорость выше или null)
            Car resultCar = null;
            if(car1.currentSpeed > car2.currentSpeed &  car1.currentSpeed > car3.currentSpeed)
            {
                resultCar = car1;
            }
            else
            {
                if(car2.currentSpeed > car3.currentSpeed & car2.CurrentSpeed > car1.currentSpeed)
                {
                    resultCar = car2;
                }
                else
                {
                    if(car3.currentSpeed > car2.CurrentSpeed & car3.CurrentSpeed > car1.CurrentSpeed)
                    {
                        resultCar = car3;
                    }
                }
            }

            return resultCar;
        }


        public override string ToString()
        {
            string str = $"Марка: {Make}. Модель: {Model}.\n" +
                $"Объем бака: {PetrolTankVolume} литров.\nТекущее количество топлива: {AmountPetrol} литров.\n" +
                $"Текущая скорость: {CurrentSpeed} km/h.\n" +
                $"Расход толпива на 100km: {FuelFlow_100km} литров.\n" +
                $"Давление в колесах: {WheelPressuress[0]}-{WheelPressuress[1]}-{WheelPressuress[2]}-{WheelPressuress[3]} гПа.\n";
            return str ;
        }



    }
}
