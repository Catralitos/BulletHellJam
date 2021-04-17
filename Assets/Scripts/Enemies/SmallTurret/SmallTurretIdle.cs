using UnityEngine;

namespace Enemies.SmallTurret
{
    public class SmallTurretIdle : SmallTurretState
    {
        private float _cooldownLeft;

        public static SmallTurretIdle Create(SmallTurret target)
        {
            SmallTurretIdle state = SmallTurretState.Create<SmallTurretIdle>(target);
            return state;
        }

        public override void StateStart()
        {
            base.StateStart();
            _cooldownLeft = Target.cooldown;
        }

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