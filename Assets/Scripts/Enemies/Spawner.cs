using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float timer;
    private float timeToSpawn;
    [SerializeField] private int number;

    private void Start()
    {
        timeToSpawn = timer;
    }
    private void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if(timeToSpawn <= 0)
        {
            Spawn();
            timeToSpawn = timer;
        }
    }
    private void Spawn()
    {
        for(int i = 0; i < 1;i++)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
