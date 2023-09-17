namespace Tests
{
    public class DummyTests
    {
        private const int dummyInitialHealth = 10;
        private const int dummyInitiaExperience = 5;

        private Dummy aliveDummy;
        private Dummy deadDummy;

        [SetUp]
        public void Setup()
        {
            aliveDummy = new Dummy(dummyInitialHealth, dummyInitiaExperience);
            deadDummy = new Dummy(0, dummyInitiaExperience);
        }

        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            var attackPoints = 5;

            aliveDummy.TakeAttack(attackPoints);

            var expectedDummyHealth = dummyInitialHealth - attackPoints;
            Assert.AreEqual(expectedDummyHealth, aliveDummy.Health, "Dummy doesn't lose health when attacked");
        }

        [Test]
        public void DeadDummyThrowsAnExceptionWhenAttacked()
        {
            var attackPoints = 5;

            var exception = Assert.Throws<InvalidOperationException>(
                () => deadDummy.TakeAttack(attackPoints),
                "Dummy soesn't throw an exception when taking an attack dead");

            Assert.AreEqual(
                "Dummy is dead.",
                exception.Message,
                "Exception message is incorrect");
        }

        [Test]
        public void DeadDummyGivesExperience()
        {
            var experience = deadDummy.GiveExperience();

            Assert.AreEqual(dummyInitiaExperience, experience, "Dummy gave wrong experience");
        }

        [Test]
        public void AliveDummyDoesntGiveExperience()
        {
            Assert.Throws<InvalidOperationException>(
                () => aliveDummy.GiveExperience(),
                "Alive dummy gave experience");
        }
    }
}
