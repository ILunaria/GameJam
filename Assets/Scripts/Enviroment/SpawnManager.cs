using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Game Objects to spawn")]
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject boss;

    [Header("Time in seconds")]
    [SerializeField] private float BossSpawn;
    [SerializeField] private float NewSpawnPoint;

    [Header("Spawn Point Settings")]
    [SerializeField] private int SpawnPoints;
    [SerializeField] private float range;
    void Start()
    {
        for (int i = 0; i < SpawnPoints; i++)
        {
            Vector3 postion = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), 0, Random.Range(transform.position.z - range, transform.position.z + range));
            GameObject instance = Instantiate(spawnPoint, postion, Quaternion.identity);
            instance.transform.parent = gameObject.transform;
        }
        StartCoroutine(SpawnBoss());
    }
    IEnumerator SpawnBoss()
    {
        while(true)
        {
            yield return new WaitForSeconds(BossSpawn);
            Vector3 postion = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), 0, Random.Range(transform.position.z - range, transform.position.z + range));
            Instantiate(boss, postion, Quaternion.identity);
        }
    }
}
