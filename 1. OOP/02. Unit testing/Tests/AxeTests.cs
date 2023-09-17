namespace Tests
{
    public class AxeTests
    {
        private const int axeAttack = 10;
        private const int axeInitialDurability = 3;
        private const int dummyInitialHealth = 100;
        private const int dummyInitialExperience = 10;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            axe = new Axe(axeAttack, axeInitialDurability);
            dummy = new Dummy(dummyInitialHealth, dummyInitialExperience);
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            Assert.AreEqual(axeInitialDurability - 1, axe.DurabilityPoints, "Axe doesn't durability after attack");
        }

        [Test]
        public void AxeCantAttackIfBroken()
        {
            for (var i = 0; i < axeInitialDurability; i++)
            {
                axe.Attack(dummy);
            }

            var exception = Assert.Throws<InvalidOperationException>(
                () => axe.Attack(dummy),
                "Axe doesn't throw exception when trying to attack");

            Assert.AreEqual(
                "Axe is broken.",
                exception.Message,
                "Axe throws exception woth wrong message when trying to attack broken");
        }
    }
}