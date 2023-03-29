using Enemies.Base;

namespace Enemies.OrbitShooter
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Enemies.Base.EnemyState&lt;Enemies.OrbitShooter.OrbitShooter&gt;" />
    public abstract class OrbitShooterState : EnemyState<OrbitShooter>
    {
        /// <summary>
        /// Creates the specified target.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        protected new static T Create<T>(OrbitShooter target) where T : OrbitShooterState
        {
            var state = EnemyState<OrbitShooter>.Create<T>(target);
            return state;
        }
    }
}