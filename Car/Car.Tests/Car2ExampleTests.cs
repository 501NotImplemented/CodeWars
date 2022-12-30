using NUnit.Framework;

namespace Car.Tests;

[TestFixture]
public class Car2ExampleTests
{
    [Test]
    public void Car2RandomTestConsumption()
    {
        var car = new Car(20, 14);

        car.EngineStart();

        Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(250));
        car.BrakeBy(8);
        Enumerable.Range(0, 17).ToList().ForEach(s => car.FreeWheel());
        car.Accelerate(123);
        var expected = 19.98;
        Console.WriteLine($"Difference {expected - car.fuelTankDisplay.FillLevel}");

        Assert.AreEqual(expected, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
    }

    [Test]
    public void Car2RandomTestsSped()
    {
        var car = new Car(20, 13);

        car.EngineStart();
        Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(250));
        car.BrakeBy(6);
        Enumerable.Range(0, 10).ToList().ForEach(s => car.FreeWheel());
        car.Accelerate(125);
        Assert.AreEqual(125, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void TestAccelerateBy10()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

        car.Accelerate(160);
        Assert.AreEqual(110, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        car.Accelerate(160);
        Assert.AreEqual(120, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        car.Accelerate(160);
        Assert.AreEqual(130, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        car.Accelerate(160);
        Assert.AreEqual(140, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        car.Accelerate(145);
        Assert.AreEqual(145, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void TestAccelerateBy5()
    {
        var car = new Car(30, 5);

        car.EngineStart();

        Enumerable.Range(0, 23).ToList().ForEach(s => car.Accelerate(112));

        Assert.AreEqual(112, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void TestAccelerateOnlyUntil250()
    {
        var car = new Car(20, 20);

        car.EngineStart();
        Enumerable.Range(0, 14).ToList().ForEach(s => car.Accelerate(260));
        Assert.AreEqual(250, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void TestAccelerationAndBraking()
    {
        var car = new Car(20, 15);

        car.EngineStart();

        Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(250));
        car.BrakeBy(9);

        Assert.AreEqual(141, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void TestBraking()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

        car.BrakeBy(20);

        Assert.AreEqual(90, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

        car.BrakeBy(10);

        Assert.AreEqual(80, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void TestConsumptionAsRunIdleWhenFreeWheelingAt0()
    {
        var car = new Car(1, 20);

        car.EngineStart();
        Enumerable.Range(0, 199).ToList().ForEach(s => car.FreeWheel());

        Assert.AreEqual(0.93999999999999995d, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
    }

    [Test]
    public void TestConsumptionSpeedUpTo30()
    {
        var car = new Car(1, 20);

        car.EngineStart();

        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);

        Assert.AreEqual(0.98, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
    }

    [Test]
    public void TestFreeWheelSpeed()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

        Assert.AreEqual(100, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

        car.FreeWheel();
        car.FreeWheel();
        car.FreeWheel();

        Assert.AreEqual(97, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void TestMaxAccelerationOutOfRange()
    {
        var car = new Car(20, 25);

        car.EngineStart();
        car.Accelerate(21);
        Assert.AreEqual(20, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }

    [Test]
    public void TestStartSpeed()
    {
        var car = new Car();

        car.EngineStart();

        Assert.AreEqual(0, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
    }
}