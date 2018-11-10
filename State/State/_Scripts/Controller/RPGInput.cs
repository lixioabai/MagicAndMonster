using UnityEngine;

[RequireComponent(typeof(RPGMotor))]
public class RPGInput : MonoBehaviour
{
    public float movespeed = 1f;
    bool islock;
    public enum MouseButton
    {
        Left,
        Right,
        Middle,
        Mouse4,
        Mouse5
    }

    bool autorun;
    RPGMotor motor;

    [SerializeField]
    float forwardRunSpeed = 10f;

    [SerializeField]
    float forwardWalkSpeed = 2f;

    [SerializeField]
    float backwardRunSpeed = 1f;

    [SerializeField]
    float backwardWalkSpeed = 1f;

    [SerializeField]
    float keyTurnSpeed = 25f;

    [SerializeField]
    float mouseTurnSpeed = 4f;

    [SerializeField]
    KeyCode forwardKey = KeyCode.W;

    [SerializeField]
    KeyCode backwardKey = KeyCode.S;

    [SerializeField]
    KeyCode leftKey = KeyCode.A;

    [SerializeField]
    KeyCode rightKey = KeyCode.D;

    [SerializeField]
    KeyCode jumpKey = KeyCode.Space;

    //[SerializeField]
    //KeyCode walkToggle = KeyCode.LeftShift;

    [SerializeField]
    MouseButton mouseLookButton = MouseButton.Right;

    [SerializeField]
    MouseButton mouseRunAndLookButton = MouseButton.Left;

    [SerializeField]
    MouseButton autorunToggleButton = MouseButton.Mouse4;

    [SerializeField]
    bool cameraRotateBehindOnMove = true;

    [SerializeField]
    bool cameraLockBehindOnMouseLook = true;

    [SerializeField]
    bool enableMouseLook = true;

    [SerializeField]
    bool enableRunAndLook = true;

    public bool IsRunning { get; private set; }
    public bool MouseLook { get; private set; }

    void Start()
    {
        motor = GetComponent<RPGMotor>();
    }

    void Update()
    {
        forwardRunSpeed = 1f*movespeed;
        backwardRunSpeed = 1f * movespeed;
        islock = GetComponent<CameraMovement>().controlLock;
        motor.MovementInput = Vector3.zero;

        if (islock)
        {
            motor.Yaw(Input.GetAxisRaw("Mouse X") * Time.smoothDeltaTime * mouseTurnSpeed);
        }

        bool forwardKeyDown = Input.GetKey(forwardKey);
        bool backwardKeyDown = Input.GetKey(backwardKey);
        bool leftKeyDown = Input.GetKey(leftKey);
        bool rightKeyDown = Input.GetKey(rightKey);
        bool jumpKeyPressed = Input.GetKeyDown(jumpKey);
        //bool walkKeyDown = Input.GetKey(walkToggle);
        bool mouseLookDown = Input.GetMouseButton((int)mouseLookButton) && enableMouseLook;
        bool mouseLookPressed = Input.GetMouseButtonDown((int)mouseLookButton) && enableMouseLook;
        bool bothMiceDown = Input.GetMouseButton((int)mouseRunAndLookButton) && mouseLookDown && enableRunAndLook;
        bool autorunPressed = Input.GetMouseButtonDown((int)autorunToggleButton);

        //IsRunning = !walkKeyDown;
        MouseLook = mouseLookDown;

        //motor.MovementInput.z += Input.GetAxis("Vertical");
        //motor.MovementInput.x += Input.GetAxis("Horizontal");


        if (autorunPressed)
        {
            autorun = !autorun;
        }

        if (autorun || forwardKeyDown || bothMiceDown)
        {
            motor.MovementInput.z += 1f;
        }

        if (backwardKeyDown)
        {
            motor.MovementInput.z -= 1f;
        }

        if (leftKeyDown)
        {
            motor.MovementInput.x -= 1f;
        }

        if (rightKeyDown)
        {
            motor.MovementInput.x += 1f;
        }

        // Set movement speed
        //if (motor.MovementInput.z < 0)
        //{
        //    motor.MovementSpeed = walkKeyDown ? backwardWalkSpeed : backwardRunSpeed;
        //}
        //else
        //{
        //    motor.MovementSpeed = walkKeyDown ? forwardWalkSpeed : forwardRunSpeed;
        //}

        // Jump
        if (jumpKeyPressed)
        {
            motor.Jump();
        }

        // Clear autorun
        if ((mouseLookDown && (leftKeyDown || rightKeyDown)) || forwardKeyDown || backwardKeyDown || bothMiceDown)
        {
            autorun = false;
        }

        // If we're moving, rotate camera behind us
        //if (motor.MovementInput != Vector3.zero)
        //{
        //    RPGCamera.Instance.RotateCameraBehindTarget = cameraRotateBehindOnMove;
        //}

        // If we're holding down mouse look, lock camera
        //if (mouseLookDown)
        //{
            //RPGCamera.Instance.LockCameraBehindTarget = cameraLockBehindOnMouseLook;
        
        //}

        // If we pressed mouse look, set rotation
        //if (mouseLookPressed)
        //{
        //    //Camera cam = RPGCamera.Instance.Camera;
        //    motor.SetYaw(RPGInputUtils.SignedAngle(Vector3.forward, cam.transform.forward, Vector3.up));
        //}
    }
}