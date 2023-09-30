using Skeleton;

namespace Tests.Fakes
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints
            => 1;

        public int DurabilityPoints
            => 1;

        public void Attack(ITarget target)
        { }
    }
}
