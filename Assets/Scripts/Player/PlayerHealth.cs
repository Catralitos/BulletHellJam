using System;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public LayerMask damagers;

        public int playerHits = 3;
        public int hitsLeft = 3;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (damagers.value != other.gameObject.layer) return;
            if (hitsLeft > 1) DoDamage();
            else Die();
        }

        private void DoDamage()
        {
            hitsLeft--;
            //tocar animaçoes etc
        }

        private void Die()
        {
            Destroy(gameObject);
            //tocar animaçoes etc
        }
    }
}