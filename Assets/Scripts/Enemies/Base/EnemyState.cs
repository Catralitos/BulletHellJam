using UnityEngine;

namespace Enemies.Base
{
    public abstract class EnemyState : MonoBehaviour
    {
        public bool Initialized { get; protected set; }
        public virtual void StateStart()
        {
            Initialized = true;
        }
        public abstract void StateUpdate();

        public virtual void StateFixedUpdate() { }

        public virtual void OnGetHit() { }
        
    }

    public abstract class EnemyState<TEnemyType> : EnemyState where TEnemyType : EnemyBase<TEnemyType>
    {
        protected TEnemyType Target;

        protected static T Create<T>(TEnemyType target) where T : EnemyState<TEnemyType>
        {
            T state = target.gameObject.AddComponent<T>();
            state.Target = target;
            return state;
        }

        protected void SetState(EnemyState<TEnemyType> state)
        {
            Target.SetState(state);
            Destroy(this);
        }

    }
}