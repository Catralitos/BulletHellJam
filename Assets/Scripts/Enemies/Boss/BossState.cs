using Enemies.Base;
using UnityEngine;

namespace Enemies.Boss
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Enemies.Base.EnemyState&lt;Enemies.Boss.Boss&gt;" />
    public class BossState : EnemyState<Boss>
    {
        /// <summary>
        /// Creates the specified target.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        protected new static T Create<T>(Boss target) where T : BossState
        {
            var state = EnemyState<Boss>.Create<T>(target);
            return state;
        }
    }
}