using Bullets.Spawners;
using Unity.Mathematics;
using UnityEngine;

namespace Enemies.SmallTurret
{
    public class SmallTurretShoot : SmallTurretState
    {
        private float _cooldownLeft;
   
        public static SmallTurretShoot Create(SmallTurret target)
        {
            var state = SmallTurretState.Create<SmallTurretShoot>(target);
            return state;
        }

        public override void StateStart()
        {
            base.StateStart();
            _cooldownLeft = Target.cooldown;
            Target.spawner.active = true;
        }
        
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