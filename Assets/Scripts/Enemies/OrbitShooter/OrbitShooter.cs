using System;
using Bullets.Spawners;
using Enemies.Base;
using UnityEngine;

namespace Enemies.OrbitShooter
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Enemies.Base.EnemyBase&lt;Enemies.OrbitShooter.OrbitShooter&gt;" />
    public class OrbitShooter : EnemyBase<OrbitShooter>
    {
        // public int numBullets;
        //public float fireRate;
        /// <summary>
        /// The run speed
        /// </summary>
        public float runSpeed;
        /// <summary>
        /// The pool name
        /// </summary>
        public String poolName;
        /// <summary>
        /// The spawner
        /// </summary>
        public Spawner spawner;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        protected override void Start()
        {
            base.Start();
            State = OrbitShooterWalkAndShoot.Create(this);
        }
    }
}