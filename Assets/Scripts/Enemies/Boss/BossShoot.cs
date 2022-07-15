using System;
using System.Collections.Generic;
using Audio;
using Bullets.Spawners;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies.Boss
{
    public class BossShoot : BossState
    {
        private float _cooldownLeft;
        private List<String> _currentPooList = new List<string>();

        public static BossShoot Create(Boss target)
        {
            var state = BossState.Create<BossShoot>(target);
            return state;
        }

        public override void StateStart()
        {
            base.StateStart();
            _cooldownLeft = Target.phaseCooldown;
            //SetActivePools();
            //Kill();
        }

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

        public void BossSwitch()
        {
            Target.clockwise = !Target.clockwise;
            SetActivePools();
            Kill();
        }
        
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