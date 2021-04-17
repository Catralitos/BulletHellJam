using System;
using Enemies.Base;

namespace Enemies.OrbitShooter
{
    public class OrbitShooter : EnemyBase<OrbitShooter>
    {
        public int numBullets;
        public float distanceFromBoss;
        public float fireRate;
        public float runSpeed;
        public String poolName;

        protected override void Start()
        {
            base.Start();
            State = OrbitShooterWalkAndShoot.Create(this);
        }
    }
}