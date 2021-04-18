using System;
using System.Collections.Generic;
using Enemies.Base;

namespace Enemies.Boss
{
    public class Boss : EnemyBase<Boss>
    {
        public bool clockwise = true;
        public float phaseCooldown = 10f;
        public float rotateSpeed = 10f;
        public List<String> bulletPools;
        
        protected override void Start()
        {
            base.Start();
            State = BossShoot.Create(this);
        }
    }
}