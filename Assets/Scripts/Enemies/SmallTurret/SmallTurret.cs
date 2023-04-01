using System;
using Bullets.Spawners;
using Enemies.Base;

namespace Enemies.SmallTurret
{
    /// <summary>
    /// The small turret class
    /// </summary>
    /// <seealso cref="Enemies.Base.EnemyBase&lt;Enemies.SmallTurret.SmallTurret&gt;" />
    public class SmallTurret : EnemyBase<SmallTurret>
    {
        /// <summary>
        /// The cooldown between shooting
        /// </summary>
        public float cooldown = 5f;
        /// <summary>
        /// The bullet spawner
        /// </summary>
        public Spawner spawner;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        protected override void Start()
        {
            base.Start();
            //Sets the initial state to Idle
            state = SmallTurretIdle.Create(this);
        }
    }
}