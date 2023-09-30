using Skeleton;
using Tests.Fakes;

namespace Tests
{
    public class HeroTests
    {
        private IWeapon weapon;
        private ITarget target;
        private Hero hero;

        [SetUp]
        public void SetUp()
        {
            weapon = new FakeWeapon();
            target = new FakeTarget();

            hero = new Hero("Ivan", weapon);
        }

        [Test]
        public void HeroGainsExperienceWhenTargetDies()
        {
            hero.Attack(target);

            Assert.AreEqual(
                FakeTarget.Experience,
                hero.Experience,
                "Hero experience was different than expected");
        }
    }
}
