using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> envObjects = new List<GameObject>();
    [SerializeField] private int maxObjs;
    [SerializeField] private float range;
    void Start()
    {
        for (int i = 0; i < maxObjs; i++)
        {
            int n = Random.Range(0, envObjects.Count - 1);
            Vector3 postion = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), 0, Random.Range(transform.position.z - range, transform.position.z + range));
            GameObject instance = Instantiate(envObjects[n], postion,Quaternion.identity);
            instance.transform.parent = gameObject.transform;
        }
    }
}
