using Enemies.Base;
using UnityEngine;

namespace Enemies.Boss
{
    public class BossState : EnemyState<Boss>
    {
        protected new static T Create<T>(Boss target) where T : BossState
        {
            var state = EnemyState<Boss>.Create<T>(target);
            return state;
        }
    }
}