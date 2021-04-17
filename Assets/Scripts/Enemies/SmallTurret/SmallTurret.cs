using System;
using Enemies.Base;

namespace Enemies.SmallTurret
{
    public class SmallTurret : EnemyBase<SmallTurret>
    {
        public int bulletNumber = 10;
        public float cooldown = 5f;
        public String poolName;

        protected override void Start()
        {
            base.Start();
            State = SmallTurretShoot.Create(this);
        }
    }
}