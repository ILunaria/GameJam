using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float timeToMoreEnemies;
    [SerializeField] private float range;
    [SerializeField] private int maxEnemies;
    [SerializeField] private float enemyHeight;
    private int minEnemies;
    private int enemiesNumber;

    [SerializeField] private TimerSO TimerSO;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(-20, 20), enemyHeight, Random.Range(-20, 20));
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
            var position = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), enemyHeight, Random.Range(transform.position.z - range, transform.position.z + range));
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
