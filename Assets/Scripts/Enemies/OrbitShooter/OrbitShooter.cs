using System;
using Bullets.Spawners;
using Enemies.Base;
using UnityEngine;

namespace Enemies.OrbitShooter
{
    public class OrbitShooter : EnemyBase<OrbitShooter>
    {
       // public int numBullets;
        //public float fireRate;
        public float runSpeed;
        public String poolName;
        public Spawner spawner;
        
        protected override void Start()
        {
            base.Start();
            State = OrbitShooterWalkAndShoot.Create(this);
        }
    }
}