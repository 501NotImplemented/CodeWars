using NUnit.Framework;

namespace Car.Tests;

[TestFixture]
public class Car2ExampleTests
{
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
    public void TestAccelerateOnlyUntil250()
    {
        var car = new Car();

        car.EngineStart();
        Enumerable.Range(0, 200).ToList().ForEach(s => car.Accelerate(250));
        car.Accelerate(260);
        Assert.AreEqual(250, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
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
    public void TestConsumptionSpeedUpTo30()
    {
        var car = new Car(1);

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
        var car = new Car();

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