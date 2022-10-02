using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float timeToMoreEnemies;
    [SerializeField] private float range;
    [SerializeField] private int maxEnemies;
    private int minEnemies;
    private int enemiesNumber;

    [SerializeField] private TimerSO TimerSO;

    private void Start()
    {
        StartCoroutine(SpawnRate());
        StartCoroutine(MoreEnemy());
    }
    private void Spawn()
    {
        minEnemies = maxEnemies / 2;
        if (minEnemies < 1) minEnemies = 1;
        enemiesNumber = Random.Range(minEnemies, maxEnemies);
        for(int i = 0; i < enemiesNumber;i++)
        {
            var position = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), transform.position.y, Random.Range(transform.position.z - range, transform.position.z + range));
            Instantiate(enemy, position, Quaternion.identity);
        }
    }
    IEnumerator SpawnRate()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }
    IEnumerator MoreEnemy()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(timeToMoreEnemies);
            maxEnemies++;
        }
    }
}
