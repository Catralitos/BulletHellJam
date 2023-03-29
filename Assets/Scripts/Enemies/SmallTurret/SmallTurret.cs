using System;
using Bullets.Spawners;
using Enemies.Base;
using UnityEngine;

namespace Enemies.SmallTurret
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Enemies.Base.EnemyBase&lt;Enemies.SmallTurret.SmallTurret&gt;" />
    public class SmallTurret : EnemyBase<SmallTurret>
    {
        /// <summary>
        /// The cooldown
        /// </summary>
        public float cooldown = 5f;
        /// <summary>
        /// The fire time
        /// </summary>
        public float fireTime = 5f;
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
            State = SmallTurretIdle.Create(this);
        }
    }
}