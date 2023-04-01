using UnityEngine;

namespace Enemies.SmallTurret
{
    /// <summary>
    /// The turret's idle state
    /// </summary>
    /// <seealso cref="Enemies.SmallTurret.SmallTurretState" />
    public class SmallTurretIdle : SmallTurretState
    {
        /// <summary>
        /// The cooldown left
        /// </summary>
        private float _cooldownLeft;

        /// <summary>
        /// Creates this state at the target turret.
        /// </summary>
        /// <param name="target">The target turret.</param>
        /// <returns></returns>
        public static SmallTurretIdle Create(SmallTurret target)
        {
            SmallTurretIdle state = SmallTurretState.Create<SmallTurretIdle>(target);
            return state;
        }

        /// <summary>
        /// Starts the state.
        /// </summary>
        public override void StateStart()
        {
            base.StateStart();
            _cooldownLeft = target.cooldown;
        }

        /// <summary>
        /// Updates the state.
        /// </summary>
        public override void StateUpdate()
        {
            _cooldownLeft -= Time.deltaTime;
            //When it's been idle for the cooldown period
            //It switches to shoot mode
            if (_cooldownLeft <= 0f)
            {
                SetState(SmallTurretShoot.Create(target));
            }
        }

    }
}