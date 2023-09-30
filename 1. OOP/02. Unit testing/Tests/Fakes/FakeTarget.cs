using Skeleton;

namespace Tests.Fakes
{
    public class FakeTarget : ITarget
    {
        public static readonly int Experience = 100;

        public int Health
            => 0;

        public int GiveExperience()
            => Experience;

        public bool IsDead()
            => true;

        public void TakeAttack(int attackPoints)
        { }
    }
}
