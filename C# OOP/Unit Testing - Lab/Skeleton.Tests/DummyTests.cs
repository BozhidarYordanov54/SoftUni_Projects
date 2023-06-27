using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void LosesHealthAfterAttack()
        {
            Dummy dummy = new Dummy(100, 10);

            dummy.TakeAttack(10);

            Assert.That(dummy.Health, Is.EqualTo(90), "Dummy doesn't take damage.");
        }

        [Test]
        public void DeadDummyAttackException()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(2));
           
        }

        [Test]
        public void DeadDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);

            int xp = dummy.GiveExperience();

            Assert.AreEqual(10, xp);
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>( () => dummy.GiveExperience());
        }
    }
}