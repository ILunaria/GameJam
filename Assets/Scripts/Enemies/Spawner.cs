using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject holder;
    [Header("Enemys GO")]
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();

    [Header("Spawn Settings")]
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
        holder = GameObject.Find("EnemyHolder");
        StartCoroutine(SpawnRate());
        StartCoroutine(MoreEnemy());
    }
    private void Update()
    {
        if(holder.transform.childCount > 200)
        {
            for(int i = holder.transform.childCount - 1; i > 100; i--)
            {
                Destroy(holder.transform.GetChild(i).gameObject);
            }
        }
    }
    private void Spawn()
    {
        minEnemies = maxEnemies / 2;
        if (minEnemies < 1) minEnemies = 1;
        enemiesNumber = Random.Range(minEnemies, maxEnemies);

        for (int i = 0; i < enemiesNumber; i++)
        {
            int n = Random.Range(0, enemies.Count - 1);

            var position = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), enemyHeight, Random.Range(transform.position.z - range, transform.position.z + range));
            var instance = Instantiate(enemies[n], position, Quaternion.identity);
            instance.transform.parent = holder.transform;
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
        while (maxEnemies < 10)
        {
            yield return new WaitForSeconds(timeToMoreEnemies);
            maxEnemies++;
        }
    }
}
