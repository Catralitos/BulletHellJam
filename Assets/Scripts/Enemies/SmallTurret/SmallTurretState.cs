using Enemies.Base;

namespace Enemies.SmallTurret
{
    /// <summary>
    /// The turret's state
    /// </summary>
    /// <seealso cref="Enemies.Base.EnemyState&lt;Enemies.SmallTurret.SmallTurret&gt;" />
    public abstract class SmallTurretState : EnemyState<SmallTurret>
    {
        /// <summary>
        /// Creates the specified state at the target turret.
        /// </summary>
        /// <typeparam name="T">The state</typeparam>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        protected new static T Create<T>(SmallTurret target) where T : SmallTurretState
        {
            var state = EnemyState<SmallTurret>.Create<T>(target);
            return state;
        }
    }
}