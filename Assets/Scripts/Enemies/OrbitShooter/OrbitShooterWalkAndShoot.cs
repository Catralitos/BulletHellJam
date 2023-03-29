using Bullets.Spawners;
using Enemies.Boss;
using UnityEngine;

namespace Enemies.OrbitShooter
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Enemies.OrbitShooter.OrbitShooterState" />
    public class OrbitShooterWalkAndShoot : OrbitShooterState
    {
        //private float _cooldownLeft;

        /// <summary>
        /// The boss
        /// </summary>
        private Transform _boss;

        /// <summary>
        /// Creates the specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public static OrbitShooterWalkAndShoot Create(OrbitShooter target)
        {
            var state = OrbitShooterState.Create<OrbitShooterWalkAndShoot>(target);
            return state;
        }

        /// <summary>
        /// States the start.
        /// </summary>
        public override void StateStart()
        {
            base.StateStart();
            _boss = BossEntity.Instance.gameObject.transform;
            Target.spawner.active = true;
            //_cooldownLeft = 1 / Target.fireRate;
            //TODO animations
        }

        /// <summary>
        /// States the update.
        /// </summary>
        public override void StateUpdate()
        {
            if (_boss == null) return;
            var bPosition = _boss.position;
            var oTransform = transform;
            oTransform.RotateAround(bPosition, Vector3.forward, Target.runSpeed * Time.deltaTime);
            var offset = bPosition - oTransform.position;
            oTransform.rotation = Quaternion.LookRotation(Vector3.forward, offset);
            /*if (_cooldownLeft > 0) _cooldownLeft -= Time.deltaTime;
            else
            {
                for (var i = 0; i < Target.numBullets; i++)
                {

                    BulletPooler.Instance.SpawnFromPool(Target.poolName, transform.position, Quaternion.identity);
                }
                Target.spawner.GetComponent<ClockPatternSpawner>().active = true;

                _cooldownLeft = 1 / Target.fireRate;
            }*/
        }
    }
}