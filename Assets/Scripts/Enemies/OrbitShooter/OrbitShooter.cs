using System;
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
        public GameObject spawner;
        
        protected override void Start()
        {
            base.Start();
            State = OrbitShooterWalkAndShoot.Create(this);
        }
    }
}