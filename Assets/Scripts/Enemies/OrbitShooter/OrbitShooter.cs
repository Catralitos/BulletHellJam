using Bullets.Spawners;
using Enemies.Base;

namespace Enemies.OrbitShooter
{
    /// <summary>
    /// The Orbit Shooter class
    /// </summary>
    /// <seealso cref="Enemies.Base.EnemyBase&lt;Enemies.OrbitShooter.OrbitShooter&gt;" />
    public class OrbitShooter : EnemyBase<OrbitShooter>
    {
        /// <summary>
        /// The run speed
        /// </summary>
        public float runSpeed;
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
            //Set the state to walk and shoot
            state = OrbitShooterWalkAndShoot.Create(this);
        }
    }
}