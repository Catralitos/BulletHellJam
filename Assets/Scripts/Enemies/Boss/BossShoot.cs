using System;
using System.Collections.Generic;
using Audio;
using Bullets.Spawners;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Boss
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Enemies.Boss.BossState" />
    public class BossShoot : BossState
    {
        /// <summary>
        /// The cooldown left
        /// </summary>
        private float _cooldownLeft;
        /// <summary>
        /// The current poo list
        /// </summary>
        private List<String> _currentPooList = new List<string>();

        /// <summary>
        /// Creates the specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public static BossShoot Create(Boss target)
        {
            var state = BossState.Create<BossShoot>(target);
            return state;
        }

        /// <summary>
        /// States the start.
        /// </summary>
        public override void StateStart()
        {
            base.StateStart();
            _cooldownLeft = Target.phaseCooldown;
            //SetActivePools();
            //Kill();
        }

        /// <summary>
        /// States the update.
        /// </summary>
        public override void StateUpdate()
        {
            /*if (TimeManager.Instance.timeLeft <= 0f)
            {
                //_cooldownLeft = Target.phaseCooldown;
                Target.clockwise = !Target.clockwise;
                SetActivePools();
                Kill();
            }*/

            var sign = Target.clockwise ? -1 : 1;
            transform.Rotate(sign * Target.rotateSpeed * Time.deltaTime * Vector3.forward);
            _cooldownLeft -= Time.deltaTime;
        }

        /// <summary>
        /// Bosses the switch.
        /// </summary>
        public void BossSwitch()
        {
            Target.clockwise = !Target.clockwise;
            SetActivePools();
            Kill();
        }

        /// <summary>
        /// Sets the active pools.
        /// </summary>
        private void SetActivePools()
        {
            _currentPooList.Clear();
            int[] poolNumbers = new int[Target.bulletPools.Count];

            for (var i = 0; i < poolNumbers.Length; i++)
            {
                poolNumbers[i] = i;
            }

            Reshuffle(poolNumbers);
            for (var i = 0; i < Target.numActivePools; i++)
            {
                _currentPooList.Add(Target.bulletPools[poolNumbers[i]]);
            }
        }

        /// <summary>
        /// Kills this instance.
        /// </summary>
        private void Kill()
        {
            AudioManager.Instance.Play("EvilLaugh");
            List<String> pools = Target.bulletPools;
            List<Spawner> spawners = Target.spawners;
            for (var i = 0; i < Target.bulletPools.Count; i++)
            {
                if (_currentPooList.Contains(pools[i]))
                {
                    switch (i)
                    {
                        //isto nao e necessario mas se calhar mais a frente queremos modificar outros parametros
                        //tal como fazemos no clock
                        case 0:
                            ClusterSpawner clusterSpawner = (ClusterSpawner) spawners[i];
                            clusterSpawner.active = true;
                            break;
                        case 1:
                            RingPatternSpawner2 ringSpawner = (RingPatternSpawner2) spawners[i];
                            ringSpawner.active = true;
                            break;
                        case 2:
                            ShockwaveRingSpawner shockSpawner = (ShockwaveRingSpawner) spawners[i];
                            shockSpawner.active = true;
                            break;
                        case 3:
                            ClockPatternSpawner clockSpawner = (ClockPatternSpawner) spawners[i];
                            clockSpawner.directions = Random.Range(1, 5);
                            clockSpawner.active = true;
                            break;
                        case 4:
                            PiramidalPatternSpawner pyramidSpawner = (PiramidalPatternSpawner) spawners[i];
                            pyramidSpawner.active = true;
                            break;
                    }
                }
                else
                {
                    var spawner = spawners[i];
                    spawner.active = false;
                }
            }
        }


        /// <summary>
        /// Reshuffles the specified texts.
        /// </summary>
        /// <param name="texts">The texts.</param>
        private void Reshuffle(int[] texts)
        {
            // Knuth shuffle algorithm :: courtesy of Wikipedia :)
            for (int t = 0; t < texts.Length; t++)
            {
                int tmp = texts[t];
                int r = Random.Range(t, texts.Length);
                texts[t] = texts[r];
                texts[r] = tmp;
            }
        }
    }
}