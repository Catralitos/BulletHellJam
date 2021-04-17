using Bullets.Spawners;
using Unity.Mathematics;

namespace Enemies.SmallTurret
{
    public class SmallTurretShoot : SmallTurretState
    {
        public static SmallTurretShoot Create(SmallTurret target)
        {
            var state = SmallTurretState.Create<SmallTurretShoot>(target);
            return state;
        }

        public override void StateStart()
        {
            base.StateStart();
            for (var i = 0; i < Target.bulletNumber; i++)
            {
                BulletPooler.Instance.SpawnFromPool(Target.poolName, transform.position, quaternion.identity);
            }
            SetState(SmallTurretIdle.Create(Target));
        }

        public override void StateUpdate()
        {
            //do nothing
        }
    }
}