using UnityEngine;

public class FallGround : MonoBehaviour
{
   
    public void StartFall()
    {
        Debug.Log(gameObject.name + " est� caindo");
        Destroy(gameObject,3f);
    }
}
