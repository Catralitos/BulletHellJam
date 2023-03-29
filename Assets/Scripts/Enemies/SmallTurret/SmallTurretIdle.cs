using UnityEngine;

namespace Enemies.SmallTurret
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Enemies.SmallTurret.SmallTurretState" />
    public class SmallTurretIdle : SmallTurretState
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
        public static SmallTurretIdle Create(SmallTurret target)
        {
            SmallTurretIdle state = SmallTurretState.Create<SmallTurretIdle>(target);
            return state;
        }

        /// <summary>
        /// States the start.
        /// </summary>
        public override void StateStart()
        {
            base.StateStart();
            _cooldownLeft = Target.cooldown;
        }

        /// <summary>
        /// States the update.
        /// </summary>
        public override void StateUpdate()
        {
            _cooldownLeft -= Time.deltaTime;
            if (_cooldownLeft <= 0f)
            {
                SetState(SmallTurretShoot.Create(Target));
            }
        }

    }
}