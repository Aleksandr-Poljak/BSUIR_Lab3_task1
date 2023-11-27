using BSUIR_Lab_3;

// Демонстрация всех  конструткорв 
Car car1 = new Car();
Console.WriteLine(car1);

Car audi = new Car("Audi", "A4");
Console.WriteLine(audi);

double[] wheel = { 1, 2, 3, 4 };
Car BMW = new Car("BMW", "X5", 86, 35, 48, 10, wheel);
Console.WriteLine(BMW);

// Демострация всех методов и свойств.
Console.WriteLine(new string('*',60));

car1.Model = "No installed!!!";
car1.PetrolTankVolume = 40;
car1.AmountPetrol = 20;
car1.FuelFlow_100km = 4.5;
car1.CurrentSpeed = 35;
car1.WheelPressuress = new double[] { 4, 4, 4, 4 };
Console.WriteLine(car1);

Console.WriteLine($"Максимальный пробег на оставшемся топливе: {BMW.RemainingDistance()} км.");
if (BMW.SpeedComparsion(car1))
{
    Console.WriteLine($"{BMW.Make}  движется быстрее чем {car1.Make}");
}

BMW.TirePressureMonitoring(2); //Проверка давления в шинах.
Console.WriteLine($"Текущая скорость {BMW.Make}: {BMW.CurrentSpeed} км.час");

audi.CurrentSpeed = 160;
Console.WriteLine($"На данный момент быстрее движентся: {Car.SpeedComparsion(car1, audi, BMW)?.Make ?? "Не опредеелно"}.") ;

//Перемещение объекта в другую перменную.проверка ссылок полей.
Console.WriteLine(new string('*', 60));
Car NewCar;
NewCar = BMW;
NewCar.CurrentSpeed = audi.CurrentSpeed -10;
Console.WriteLine($"Ранее BMW был остановлен.Новая скорость BMW: {BMW.CurrentSpeed}");



