using System.Collections.Generic;
using Enemies.Boss;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public LayerMask obstructions;
    public int wavesBeforeAddedBossPool = 10;
    public float enemyGrowthFactor = 2;
    public int maxNumberEnemies;
    public int minOrbiterRadius = 7;
    public int maxOrbiterRadius = 15;
    public float circleWidth = 0.01f;
    public float turretToOrbiterRatio = 0.75f;
    public List<GameObject> orbiterPrefabs;
    public List<GameObject> turretPrefabs;
    public List<Transform> turretPositions;

    private int _currentNumEnemies = 2;
    private int _currentWave = 1;
    private int _numOrbiters;
    private int _numOrbiterPositions;
    private int _numTurretPositions;
    private int _numTurrets;

    private void Start()
    {
        _numOrbiters = orbiterPrefabs.Count;
        _numOrbiterPositions = (maxOrbiterRadius - minOrbiterRadius) - 4;
        _numTurretPositions = turretPositions.Count;
        _numTurrets = turretPrefabs.Count;
    }

    public void SpawnNextWave()
    {
        var turretsToSpawn = Mathf.RoundToInt(turretToOrbiterRatio * _currentNumEnemies);
        var orbitersToSpawn = _currentNumEnemies - turretsToSpawn;

        for (var i = 0; i < turretsToSpawn; i++)
        {
            var toSpawn = turretPrefabs[Random.Range(0, _numTurrets)];
            var randomPoint = turretPositions[Random.Range(0, _numTurretPositions)];
            bool overlap = Physics2D.OverlapCircle(randomPoint.position, circleWidth, obstructions);
            var c = 0;
            while (overlap && c < _numTurretPositions)
            {
                randomPoint = turretPositions[Random.Range(0, _numTurretPositions)];
                overlap = Physics2D.OverlapCircle(randomPoint.position, circleWidth, obstructions);
                c++;
            }

            if (c < _numTurretPositions) Instantiate(toSpawn, randomPoint.position, Quaternion.identity);
        }

        for (var i = 0; i < orbitersToSpawn; i++)
        {
            var toSpawn = orbiterPrefabs[Random.Range(0, _numOrbiters)];
            var randomXRange = Random.Range(minOrbiterRadius, maxOrbiterRadius + 1);
            randomXRange = Random.Range(0, 2) == 1 ? randomXRange : -randomXRange;
            var spawn = Random.Range(0, 2) == 1 ? new Vector3(0, randomXRange, 0) : new Vector3(randomXRange, 0, 0);
            bool overlap = Physics2D.OverlapCircle(spawn, circleWidth, obstructions);
            var c = 0;
            while (overlap && c < _numOrbiterPositions)
            {
                randomXRange = Random.Range(minOrbiterRadius, maxOrbiterRadius + 1);
                randomXRange = Random.Range(0, 2) == 1 ? randomXRange : -randomXRange;
                spawn = Random.Range(0, 2) == 1 ? new Vector3(0, randomXRange, 0) : new Vector3(randomXRange, 0, 0);
                overlap = Physics2D.OverlapCircle(spawn, circleWidth, obstructions);
                c++;
            }

            if (c < _numOrbiterPositions) Instantiate(toSpawn, spawn, Quaternion.identity);
        }

        _currentWave++;
        var f = Mathf.Pow(_currentWave, 1.0f / enemyGrowthFactor);
        _currentNumEnemies = Mathf.RoundToInt(Mathf.Clamp(f, 1, maxNumberEnemies));
        if (_currentWave % wavesBeforeAddedBossPool == 0)
        {
            BossEntity.Instance.boss.IncreaseActivePools();
        }
    }
}