using Enemies.Base;

namespace Enemies.Boss
{
    /// <summary>
    /// The BossState class
    /// </summary>
    /// <seealso cref="Enemies.Base.EnemyState&lt;Enemies.Boss.Boss&gt;" />
    public class BossState : EnemyState<Boss>
    {
        /// <summary>
        /// Creates the specified state in the boss.
        /// </summary>
        /// <typeparam name="T">The state</typeparam>
        /// <param name="target">The target enemy.</param>
        /// <returns></returns>
        protected new static T Create<T>(Boss target) where T : BossState
        {
            var state = EnemyState<Boss>.Create<T>(target);
            return state;
        }
    }
}