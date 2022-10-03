using UnityEngine;

public class FallGround : MonoBehaviour
{
   
    public void StartFall()
    {
        Debug.Log(gameObject.name + " está caindo");
        Destroy(gameObject,3f);
    }
}
