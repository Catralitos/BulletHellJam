using Enemies.Boss;
using UnityEngine;

namespace Enemies.OrbitShooter
{
    /// <summary>
    /// The Orbit Shooter's Walking and Shooting state
    /// </summary>
    /// <seealso cref="Enemies.OrbitShooter.OrbitShooterState" />
    public class OrbitShooterWalkAndShoot : OrbitShooterState
    {

        /// <summary>
        /// The boss it rotates around
        /// </summary>
        private Transform _boss;

        /// <summary>
        /// Creates this state in the target Orbit Shooter.
        /// </summary>
        /// <param name="target">The target Orbit Shooter.</param>
        /// <returns></returns>
        public static OrbitShooterWalkAndShoot Create(OrbitShooter target)
        {
            var state = OrbitShooterState.Create<OrbitShooterWalkAndShoot>(target);
            return state;
        }

        /// <summary>
        /// Starts the state
        /// </summary>
        public override void StateStart()
        {
            base.StateStart();
            _boss = BossEntity.Instance.gameObject.transform;
            target.spawner.active = true;
        }

        /// <summary>
        /// Updates the state
        /// </summary>
        public override void StateUpdate()
        {
            if (_boss == null) return;
            var bPosition = _boss.position;
            var oTransform = transform;
            oTransform.RotateAround(bPosition, Vector3.forward, target.runSpeed * Time.deltaTime);
            var offset = bPosition - oTransform.position;
            oTransform.rotation = Quaternion.LookRotation(Vector3.forward, offset);
        }
    }
}