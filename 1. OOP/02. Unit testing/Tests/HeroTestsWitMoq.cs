using Moq;
using Skeleton;

namespace Tests
{
    public class HeroTestsWitMoq
    {
        private Mock<IWeapon> weaponMock;
        private Mock<ITarget> targetMock;
        private Hero hero;

        [SetUp]
        public void Setup()
        {
            weaponMock = new Mock<IWeapon>();
            targetMock = new Mock<ITarget>();

            hero = new Hero("Pesho", weaponMock.Object);
        }

        [Test]
        public void HeroGainsExperienceWhenTargetDies()
        {
            targetMock
                .Setup(target => target.IsDead())
                .Returns(true);

            const int targetExperience = 10;
            targetMock
                .Setup(target => target.GiveExperience())
                .Returns(targetExperience);

            hero.Attack(targetMock.Object);

            Assert.AreEqual(
                targetExperience,
                hero.Experience,
                "Hero experience was different than expected");

            targetMock.Verify(
                target => target.GiveExperience(),
                Times.Once
            );
        }

        [Test]
        public void HeroDoesntGainExperienceWhenTargetIsAlive()
        {
            targetMock
                .Setup(target => target.IsDead())
                .Returns(false);

            hero.Attack(targetMock.Object);

            Assert.AreEqual(
                hero.Experience,
                0,
                "Hero experiance was different than expected");

            targetMock.Verify(
                target => target.GiveExperience(),
                Times.Never);
        }

        [Test]
        public void HeroThrowsAnExceptionWhenAttackingWithBrokenWeapon()
        {
            weaponMock
                .Setup(weapon => weapon.Attack(It.IsAny<ITarget>()))
                .Throws<InvalidOperationException>();

            Assert.Throws<InvalidOperationException>(
                () => hero.Attack(targetMock.Object),
                "Hero was expected to throw when attacking with broken weapon but didn't");
        }
    }
}
