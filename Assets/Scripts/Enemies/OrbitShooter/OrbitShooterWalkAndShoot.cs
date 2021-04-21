using Bullets.Spawners;
using Enemies.Boss;
using UnityEngine;

namespace Enemies.OrbitShooter
{
    public class OrbitShooterWalkAndShoot : OrbitShooterState
    {
        private float _cooldownLeft;

        private Transform _boss;

        public static OrbitShooterWalkAndShoot Create(OrbitShooter target)
        {
            var state = OrbitShooterState.Create<OrbitShooterWalkAndShoot>(target);
            return state;
        }

        public override void StateStart()
        {
            base.StateStart();
            _boss = BossEntity.Instance.gameObject.transform;
            _cooldownLeft = Target.fireRate;
            //TODO animations
        }

        public override void StateUpdate()
        {
            transform.RotateAround(_boss.position, Vector3.forward, Target.runSpeed * Time.deltaTime);
            if (_cooldownLeft > 0) _cooldownLeft -= Time.deltaTime;
            else
            {
                for (var i = 0; i < Target.numBullets; i++)
                {
                    BulletPooler.Instance.SpawnFromPool(Target.poolName, transform.position, Quaternion.identity);
                }

                _cooldownLeft = Target.fireRate;
            }
        }
    }
}