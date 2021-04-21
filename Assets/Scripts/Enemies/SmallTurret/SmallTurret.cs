using System;
using Bullets.Spawners;
using Enemies.Base;
using UnityEngine;

namespace Enemies.SmallTurret
{
    public class SmallTurret : EnemyBase<SmallTurret>
    {
        
        public float cooldown = 5f;
        public float fireTime = 5f;
        public String poolName;
        public Spawner spawner;
        
        protected override void Start()
        {
            base.Start();
            State = SmallTurretIdle.Create(this);
        }
    }
}