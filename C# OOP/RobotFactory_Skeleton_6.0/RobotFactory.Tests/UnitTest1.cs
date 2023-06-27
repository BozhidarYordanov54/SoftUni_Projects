using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [Test]
        public void ProduceRobot_AddsRobotToList()
        {
            // Arrange
            var factory = new Factory("Factory", 10);

            // Act
            factory.ProduceRobot("Model A", 1000.0, 2);

            // Assert
            Assert.AreEqual(1, factory.Robots.Count);
        }

        [Test]
        public void ProduceRobot_ReturnsSuccessMessage()
        {
            // Arrange
            var factory = new Factory("Factory", 10);

            // Act
            var result = factory.ProduceRobot("Model A", 1000.0, 2);

            // Assert
            StringAssert.Contains("Produced", result);
        }

        [Test]
        public void ProduceRobot_ReturnsErrorMessageWhenFactoryIsFull()
        {
            // Arrange
            var factory = new Factory("Factory", 1);
            factory.ProduceRobot("Model A", 1000.0, 2);

            // Act
            var result = factory.ProduceRobot("Model B", 2000.0, 3);

            // Assert
            StringAssert.Contains("unable to produce", result);
        }

        [Test]
        public void ProduceSupplement_AddsSupplementToList()
        {
            // Arrange
            var factory = new Factory("Factory", 10);

            // Act
            factory.ProduceSupplement("Supplement A", 2);

            // Assert
            Assert.AreEqual(1, factory.Supplements.Count);
        }

        [Test]
        public void UpgradeRobot_AddsSupplementToRobot()
        {
            // Arrange
            var factory = new Factory("Factory", 10);
            var robot = new Robot("Model A", 1000.0, 2);
            factory.Robots.Add(robot);
            var supplement = new Supplement("Supplement A", 2);

            // Act
            var result = factory.UpgradeRobot(robot, supplement);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, robot.Supplements.Count);
        }

        [Test]
        public void UpgradeRobot_ReturnsFalseWhenSupplementIsAlreadyAttached()
        {
            // Arrange
            var factory = new Factory("Factory", 10);
            var robot = new Robot("Model A", 1000.0, 2);
            factory.Robots.Add(robot);
            var supplement = new Supplement("Supplement A", 2);
            robot.Supplements.Add(supplement);

            // Act
            var result = factory.UpgradeRobot(robot, supplement);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(1, robot.Supplements.Count);
        }

        [Test]
        public void SellRobot_ReturnsHighestPricedRobotUnderGivenPrice()
        {
            // Arrange
            var factory = new Factory("Factory", 10);
            factory.ProduceRobot("Model A", 1000.0, 2);
            factory.ProduceRobot("Model B", 2000.0, 3);
            factory.ProduceRobot("Model C", 1500.0, 2);

            // Act
            var result = factory.SellRobot(1600.0);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Model C", result.Model);
        }
    }
}
