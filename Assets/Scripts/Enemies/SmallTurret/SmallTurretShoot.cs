using Bullets.Spawners;
using Unity.Mathematics;
using UnityEngine;

namespace Enemies.SmallTurret
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Enemies.SmallTurret.SmallTurretState" />
    public class SmallTurretShoot : SmallTurretState
    {
        /// <summary>
        /// The cooldown left
        /// </summary>
        private float _cooldownLeft;

        /// <summary>
        /// Creates the specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public static SmallTurretShoot Create(SmallTurret target)
        {
            var state = SmallTurretState.Create<SmallTurretShoot>(target);
            return state;
        }

        /// <summary>
        /// States the start.
        /// </summary>
        public override void StateStart()
        {
            base.StateStart();
            _cooldownLeft = Target.cooldown;
            Target.spawner.active = true;
        }

        /// <summary>
        /// States the update.
        /// </summary>
        public override void StateUpdate()
        {
            _cooldownLeft -= Time.deltaTime;
            if (_cooldownLeft <= 0f)
            {
                Target.spawner.active = false;
                SetState(SmallTurretIdle.Create(Target));
            }
        }
    }
}