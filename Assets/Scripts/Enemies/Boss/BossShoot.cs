using System;
using Enemies.Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Boss
{
    public class BossShoot : EnemyState<Boss>
    {
        private float _cooldownLeft;
        private String _currentPool;
        public static BossShoot Create(Boss target)
        {
            var state = BossState.Create<BossShoot>(target);
            return state;
        }

        public override void StateStart()
        {
            base.StateStart();
            _cooldownLeft = Target.phaseCooldown;
            _currentPool = Target.bulletPools[Random.Range(0, Target.bulletPools.Count)];
        }

        public override void StateUpdate()
        {
            if (_cooldownLeft <= 0f)
            {
                _cooldownLeft = Target.phaseCooldown;
                Target.clockwise = !Target.clockwise;
                _currentPool = Target.bulletPools[Random.Range(0, Target.bulletPools.Count)];
            }

            var sign = Target.clockwise ? -1 : 1;
            transform.Rotate(sign * Target.rotateSpeed * Time.deltaTime * Vector3.forward);

            //Kill();
        }

        private void Kill()
        {
            //todo acabar isto
            switch (_currentPool)
            {
                case "Pyramid":
                    break;
            }
        }
    }
}