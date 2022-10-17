using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private SoundPitchChanger spawnControler;
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

    private void Start()
    {
        spawnControler = FindObjectOfType<SoundPitchChanger>().GetComponent<SoundPitchChanger>();
        holder = GameObject.Find("EnemyHolder");
        StartCoroutine(SpawnRate());
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
            if(spawnControler.hasBoss)
            {
                yield return null;
            }
            else
            {
                Spawn();
                if(maxEnemies < 10)
                {
                    maxEnemies += 1;
                }
                yield return new WaitForSecondsRealtime(spawnDelay);
            }
        }
    }
}
