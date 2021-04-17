using Enemies.Base;

namespace Enemies.OrbitShooter
{
    public abstract class OrbitShooterState : EnemyState<OrbitShooter>
    {
        protected new static T Create<T>(OrbitShooter target) where T : OrbitShooterState
        {
            var state = EnemyState<OrbitShooter>.Create<T>(target);
            return state;
        }
    }
}