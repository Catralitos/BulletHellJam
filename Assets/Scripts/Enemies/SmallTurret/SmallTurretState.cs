using Enemies.Base;

namespace Enemies.SmallTurret
{
    public abstract class SmallTurretState : EnemyState<SmallTurret>
    {
        protected new static T Create<T>(SmallTurret target) where T : SmallTurretState
        {
            var state = EnemyState<SmallTurret>.Create<T>(target);
            return state;
        }
    }
}