using UnityEngine;

namespace Enemies.SmallTurret
{
    /// <summary>
    /// The turrets shooting state
    /// </summary>
    /// <seealso cref="Enemies.SmallTurret.SmallTurretState" />
    public class SmallTurretShoot : SmallTurretState
    {
        /// <summary>
        /// The cooldown left
        /// </summary>
        private float _cooldownLeft;

        /// <summary>
        /// Creates this state at the specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public static SmallTurretShoot Create(SmallTurret target)
        {
            var state = SmallTurretState.Create<SmallTurretShoot>(target);
            return state;
        }

        /// <summary>
        /// Starts the state
        /// </summary>
        public override void StateStart()
        {
            base.StateStart();
            _cooldownLeft = target.cooldown;
            //Activates the bullet spawner
            target.spawner.active = true;
        }

        /// <summary>
        /// Updates the state
        /// </summary>
        public override void StateUpdate()
        {
            _cooldownLeft -= Time.deltaTime;
            if (_cooldownLeft <= 0f)
            {
                //When it's been shooting for the cooldown period
                //It switches to idle mode
                target.spawner.active = false;
                SetState(SmallTurretIdle.Create(target));
            }
        }
    }
}