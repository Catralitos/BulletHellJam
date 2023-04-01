using Enemies.Base;

namespace Enemies.OrbitShooter
{
    /// <summary>
    /// The Orbit Shooter states
    /// </summary>
    /// <seealso cref="Enemies.Base.EnemyState&lt;Enemies.OrbitShooter.OrbitShooter&gt;" />
    public abstract class OrbitShooterState : EnemyState<OrbitShooter>
    {
        /// <summary>
        /// Creates the specified state at the target Orbit Shooter.
        /// </summary>
        /// <typeparam name="T">The state</typeparam>
        /// <param name="target">The target Orbit Shooter.</param>
        /// <returns></returns>
        protected new static T Create<T>(OrbitShooter target) where T : OrbitShooterState
        {
            var state = EnemyState<OrbitShooter>.Create<T>(target);
            return state;
        }
    }
}