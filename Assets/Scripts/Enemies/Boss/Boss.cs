using System;
using System.Collections.Generic;
using Bullets.Spawners;
using Enemies.Base;
using UnityEngine;

namespace Enemies.Boss
{
    public class Boss : EnemyBase<Boss>
    {
        public bool clockwise = true;
        public int numActivePools = 1;
        public float phaseCooldown = 10f;
        public float rotateSpeed = 10f;
        public List<Spawner> spawners;
        public List<String> bulletPools;
        protected override void Start()
        {
            base.Start();
            State = BossShoot.Create(this);
        }

        public void IncreaseActivePools()
        {
            if (numActivePools >= 5) return;
            numActivePools++;
        }
    }
}