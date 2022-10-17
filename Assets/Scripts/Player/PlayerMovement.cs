using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

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
    [SerializeField] private LayerMask _voidLayer;
    #endregion
    private PauseUI pause;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("PlayerAwake");
        pause = FindObjectOfType<PauseUI>().GetComponent<PauseUI>();
        SoundManager.Initialize();
        inputs = new PlayerInputs();
        inputs.Player.Enable();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Physics.CheckBox(_groundCheckPoint.position, _groundCheckSize, Quaternion.identity, _voidLayer))
        {
            _status.currentHp = 0;
            return;
        }
    }
    private void FixedUpdate()
    {
        if (pause.isPaused) return;
        Move(inputs.Player.Move.ReadValue<Vector2>());
        if (inputs.Player.Move.IsPressed())
        {
            SoundManager.PlaySound(SoundManager.Sound.PlayerMove01, transform.position);
            SoundManager.PlaySound(SoundManager.Sound.PlayerMove02, transform.position);
            SoundManager.PlaySound(SoundManager.Sound.PlayerMove03, transform.position);
            SoundManager.PlaySound(SoundManager.Sound.PlayerMove04, transform.position);
        }
    }

    private void Move(Vector2 input)
    {
        
        if(Physics.CheckBox(_groundCheckPoint.position,_groundCheckSize,Quaternion.identity,_groundLayer))
        {
            rb.velocity = new Vector3(input.x, 0, input.y) * (_status.moveSpeed * 10) * Time.fixedDeltaTime;
        }
        else rb.velocity = new Vector3(input.x, Physics.gravity.y/5, input.y) * (_status.moveSpeed * 10) * Time.fixedDeltaTime;

        MoveRotation(input);
        //rb.AddForce(new Vector3(input.x, 0, input.y) * _status.moveSpeed, ForceMode.Force);
    }

    private void MoveRotation(Vector2 input)
    {
        if (input.x < 0)
        {
            var rotation = Quaternion.Euler(0, 180f, 0f);
            spr.localRotation = Quaternion.Lerp(spr.localRotation,rotation, 20f * Time.fixedDeltaTime);
        }
        else if (input.x > 0)
        {
            var rotation = Quaternion.Euler(0, 0, 0);
            spr.localRotation = Quaternion.Lerp(spr.localRotation, rotation, 20f * Time.fixedDeltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(_groundCheckPoint.position, _groundCheckSize);
    }

    public Vector3 GetPosition()
    {
        Vector3 position = transform.position;
        return position;
    }
}
