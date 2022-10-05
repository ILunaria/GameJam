using UnityEngine;

public class GroundFall : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void StartFall()
    {
        anim.SetBool("toPlay", true);
    }
    public void EndFall()
    {
        Destroy(gameObject);
    }
}
