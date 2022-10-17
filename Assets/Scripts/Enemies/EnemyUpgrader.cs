using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpgrader : MonoBehaviour
{
    [Header("EnemyStatus")]
    [SerializeField] private List<EnemySO> m_EnemySOs = new List<EnemySO>();
    [SerializeField] private float timeToUpgrade;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyStatusUp());
    }
    IEnumerator EnemyStatusUp()
    {
        int times = 0;
        while (times < 100)
        {
            yield return new WaitForSeconds(timeToUpgrade);
            for (int i = 0; i < m_EnemySOs.Count; i++)
            {
                m_EnemySOs[i].maxHp += 4;
                m_EnemySOs[i].moveSpeed += 5;
                m_EnemySOs[i].fireRate += 5;
                m_EnemySOs[i].level += 1;
                times++;
            }
        }
    }
}
