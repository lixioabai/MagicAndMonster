using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public CharacterController target;
    public float rotationUpdateSpeed = 40.0f;
    private CameraMovement CM;
    private float MoveSpeed=40f;
    //private Animator animator;
    private const float gravity =60.0f;
    private Vector3 moveDirection=Vector3.zero;
    private PlayerMovement instance;
    public PlayerMovement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerMovement();
            }
            return instance;
        }
    }
    void Awake()
    {
        CM=GetComponent<CameraMovement>();
        if (target == null)
        {
            target = GetComponent<CharacterController>();
        }
        //if(animator==null)
        //{
        //    animator=GetComponent<Animator>();
        //}
        if (target == null)
        {
            enabled = false;
            return;
        }
    }
	void Start () {
        
	}
    public void Update () {
        //animator.SetFloat(hash.qianhouFloat, Input.GetAxis("Vertical"));
        //animator.SetFloat(hash.zuoyouFloat, Input.GetAxis("Horizontal"));
        moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection.y -= gravity * Time.deltaTime; 
        if(Input.GetAxis("Vertical") < 0)
        {
            MoveSpeed = 25f;
        }
        else
        {
            MoveSpeed = 50f;
        }
        target.Move(moveDirection*Time.deltaTime*MoveSpeed*0.1f);
        MouseClock();
	}
    void Rotating()
    {
        float rotationX;
        rotationX = Input.GetAxis("Mouse X") * rotationUpdateSpeed * Time.deltaTime;
        target.transform.Rotate(Vector3.up,rotationX);
  }
    void MouseClock()
    {
        if(Input.GetAxis("Vertical")!=0||Input.GetAxis("Horizontal")!=0)
        {
            CM.controlLock = true;
        }
        if (CM.controlLock)
        {
            Rotating();
        }
    }
}
