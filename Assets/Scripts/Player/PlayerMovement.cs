using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status;
    [SerializeField] private Transform spr;
    private Rigidbody rb;
    private PlayerInputs inputs;
    private Vector2 moveDir;

    #region CHECK PARAMETERS
    //Set all of these up in the inspector
    [Header("Checks")]
    [SerializeField] private Transform _groundCheckPoint;
    //Size of groundCheck depends on the size of your character generally you want them slightly small than width (for ground) and height (for the wall check)
    [SerializeField] private Vector3 _groundCheckSize;
    #endregion

    #region LAYERS & TAGS
    [Header("Layers & Tags")]
    [SerializeField] private LayerMask _groundLayer;
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        inputs = new PlayerInputs();
        inputs.Player.Enable();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move(inputs.Player.Move.ReadValue<Vector2>());
    }

    private void Move(Vector2 input)
    {
        if(Physics.CheckBox(_groundCheckPoint.position,_groundCheckSize,Quaternion.identity,_groundLayer))
        {
            rb.velocity = new Vector3(input.x, 0f, input.y) * (_status.moveSpeed * 10) * Time.fixedDeltaTime;
        }
        else rb.velocity = new Vector3(input.x, Physics.gravity.y/5, input.y) * (_status.moveSpeed * 10) * Time.fixedDeltaTime;

        MoveRotation(input);
        //rb.AddForce(new Vector3(input.x, 0, input.y) * _status.moveSpeed, ForceMode.Force);
    }

    private void MoveRotation(Vector2 input)
    {
        if (input.x < 0)
        {
            var rotation = Quaternion.Euler(0, 180f, 0);
            spr.localRotation = Quaternion.Lerp(spr.localRotation,rotation,10f * Time.fixedDeltaTime);
        }
        else if (input.x > 0)
        {
            var rotation = Quaternion.Euler(0, 0f, 0);
            spr.localRotation = Quaternion.Lerp(spr.localRotation, rotation, 10f * Time.fixedDeltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(_groundCheckPoint.position, _groundCheckSize);
    }
}
