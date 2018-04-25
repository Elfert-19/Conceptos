using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject boss;
    public GameObject[] enemys;
    public int smallToSpawn;
    int smallSpawned;
    public int mediumToSpawn;
    int mediumSpawned;
    public int bigToSpawn;
    int bigSpawned;
    public int timeIntervalBetweenSpawn;
    public int maxEnemyInSector;
    int enemysSpawned;
    public MapController mapController;
    int totalToSpawn;
    int spawned;

    private void Awake()
    {
        totalToSpawn = smallToSpawn + mediumToSpawn + bigToSpawn;
        Invoke("Spawn", timeIntervalBetweenSpawn);
    }


    public void Spawn()
    {
        if (spawned < totalToSpawn)
        {
            int area = Random.Range(0, mapController.areasAvalides.Count);
            int sector = Random.Range(0, mapController.areasAvalides[area].sectors.Count);
            int spawnPoint = Random.Range(0, mapController.areasAvalides[area].areaWaypointsAmount);
            int enemyToSpawn = Random.Range(0, enemys.Length);
            if (enemyToSpawn == 1)
            {
                if (smallSpawned < smallToSpawn)
                {
                    if (mapController.areasAvalides[area].IsDangerZone(mapController.areasAvalides[area].sectors[sector]) == false)
                    {
                        if (mapController.areasAvalides[area].sectors[sector].enemysDetected.Count < maxEnemyInSector)
                        {
                            Instantiate(enemys[enemyToSpawn], mapController.areasAvalides[area].sectors[sector].waypoints[spawnPoint].position, mapController.areasAvalides[area].sectors[sector].waypoints[spawnPoint].rotation);
                            smallSpawned += 1;
                            spawned += 1;
                            Invoke("Spawn", timeIntervalBetweenSpawn);
                        }
                        else
                        {
                            Spawn();
                        }
                    }
                    else
                    {
                        Spawn();
                    }
                }
                else
                {
                    Spawn();
                }
            }
            else if (enemyToSpawn == 2)
            {
                if (mediumSpawned < mediumToSpawn)
                {
                    if (mapController.areasAvalides[area].IsDangerZone(mapController.areasAvalides[area].sectors[sector]) == false)
                    {
                        if (mapController.areasAvalides[area].sectors[sector].enemysDetected.Count < maxEnemyInSector)
                        {
                            Instantiate(enemys[enemyToSpawn], mapController.areasAvalides[area].sectors[sector].waypoints[spawnPoint].position, mapController.areasAvalides[area].sectors[sector].waypoints[spawnPoint].rotation);
                            mediumSpawned += 1;
                            spawned += 1;
                            Invoke("Spawn", timeIntervalBetweenSpawn);
                        }
                        else
                        {
                            Spawn();
                        }
                    }
                    else
                    {
                        Spawn();
                    }
                }
                else
                {
                    Spawn();
                }
            }
            else if (enemyToSpawn == 3)
            {
                if (bigSpawned < bigToSpawn)
                {
                    if (mapController.areasAvalides[area].IsDangerZone(mapController.areasAvalides[area].sectors[sector]) == false)
                    {
                        if (mapController.areasAvalides[area].sectors[sector].enemysDetected.Count < maxEnemyInSector)
                        {
                            Instantiate(enemys[enemyToSpawn], mapController.areasAvalides[area].sectors[sector].waypoints[spawnPoint].position, mapController.areasAvalides[area].sectors[sector].waypoints[spawnPoint].rotation);
                            bigSpawned += 1;
                            spawned += 1;
                            Invoke("Spawn", timeIntervalBetweenSpawn);
                        }
                        else
                        {
                            Spawn();
                        }
                    }
                    else
                    {
                        Spawn();
                    }
                }
                else
                {
                    Spawn();
                }
            }
        }
        else
        {
            SpawnBoss();
        }
    }

    public void SpawnBoss()
    {
        int area = Random.Range(0, mapController.areasAvalides.Count);
        int sector = Random.Range(0, mapController.areasAvalides[area].sectors.Count);
        int spawnPoint = Random.Range(0, mapController.areasAvalides[area].areaWaypointsAmount);
        if (mapController.areasAvalides[area].IsDangerZone(mapController.areasAvalides[area].sectors[sector]) == false)
        {
            Instantiate(boss, mapController.areasAvalides[area].sectors[sector].waypoints[spawnPoint].position, mapController.areasAvalides[area].sectors[sector].waypoints[spawnPoint].rotation);
        }
        else
        {
            SpawnBoss();
        }
    }
}
