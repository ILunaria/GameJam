using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{

    #region CHECK PARAMETERS
    //Set all of these up in the inspector
    [Header("Checks")]

    [SerializeField] private Transform areaCheckPoint;
    [SerializeField] private Vector3 areaCheckSize;
    #endregion

    #region LAYERS & TAGS
    [Header("Layers & Tags")]
    [SerializeField] private LayerMask PlayerLayer;
    #endregion

    // Update is called once per frame
    void Update()
    {

        if (Physics.CheckBox(areaCheckPoint.position, areaCheckSize, Quaternion.identity ,PlayerLayer))
        {
            PlayerDeath.OnPlayerDeath();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(areaCheckPoint.position, areaCheckSize);
    }
}
