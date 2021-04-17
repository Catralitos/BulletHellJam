using System;
using Extensions;
using Player;
using UnityEngine;

namespace Bullets
{
    public class BulletDodge : MonoBehaviour
    {
        //isto pode implicar comparar a vida inicial com a final e 
        //nao congelar o tempo se ele recebeu um hit.
        //vou assumir por agora que só tens um hit
        public LayerMask bulletsMask;

        public float freezeMultiplier = 3.5f;

        private float _timeFreeze;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (bulletsMask.HasLayer(other.gameObject.layer)) Debug.Log("Trigger enter");        
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (bulletsMask.HasLayer(other.gameObject.layer)) _timeFreeze += Time.deltaTime;;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!bulletsMask.HasLayer(other.gameObject.layer)) return;
            Debug.Log("Trigger exited " + _timeFreeze * freezeMultiplier);
            TimeManager.Instance.FreezeTime(_timeFreeze * freezeMultiplier);
            _timeFreeze = 0f;
        }
    }
}