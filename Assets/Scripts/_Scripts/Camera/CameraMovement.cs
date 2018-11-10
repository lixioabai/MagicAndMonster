using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public GameObject target;                                                     //目标
    public GameObject _target;
    public Camera camera;
    public LayerMask obstacleLayers = -1;                           //指定函数FixedUpdate中球形探测的碰撞层
    public LayerMask GroundLayers = -1;                            //指定函数FixedUpdate中确定摄像机是否着地的线性探测的碰撞体
    public float groundedCheckOffset = 0.7f;
    public float rotationUpdateSpeed = 60.0f;
    public float lookUpSpeed = 20.0f;
    public float distanceUpdateSpeed = 10.0f;
    public float followUpdateSpeed = 10.0f;
    public float maxForwardAngle = 80.0f;
    public const float minDistance = 2f;
    public const float maxDistance = 5f;
    public float zoomSpeed = 1.0f;
    public bool requireLock = true;
    public bool controlLock = true;
    private const float movementThreshold = 0.1f;
    private const float rotationThreshold = 0.1f;
    private const float groundedDistance = 0.5f;
    private Vector3 lastStationaryPosition;                         //target上次停驻的地方
    private float optimalDistance;
    private float targetDistance;
    private bool grounded = false;
	void Start () {
        target=this.gameObject;
        foreach (Transform o in GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Transform>())
        {
            if (o.tag == "zhujueweizhi")
            {
                _target = o.gameObject;
            }
        }
        
        if(camera==null)
        {
            camera = Camera.main;
        }
        if(target==null)
        {
            enabled = false;
            return;
        }
        if(camera==null)
        {
            enabled = false;
            return;
        }
        lastStationaryPosition = _target.transform.position;
        targetDistance=optimalDistance=(camera.transform.position-_target.transform.position).magnitude;
	}
	void Update () {
        optimalDistance = Mathf.Clamp(optimalDistance + Input.GetAxis("Mouse ScrollWheel")*100.0f * -zoomSpeed * Time.deltaTime, 3f, 3f);
	}
    float ViewRadius
    {
        get
        {
            float fieldOfViewRadius = (optimalDistance * Mathf.Tan(camera.fieldOfView / 2.0f) * Mathf.Deg2Rad);//视角半径
            float doubleCharacterRadius = Mathf.Max(1, 1) * 2.0f;
            return Mathf.Min(doubleCharacterRadius,fieldOfViewRadius);
        }
    }
    Vector3 SnappedCameraForward
    {
        get
        {
            Vector3 f = camera.transform.forward;
            Vector2 planeForward = new Vector2(f.x,f.z);
            planeForward = new Vector2(target.transform.forward.x,target.transform.forward.z).normalized*planeForward.magnitude;
            return new Vector3(planeForward.x,f.y,planeForward.y);
        }
    }
    void FixedUpdate()
    {
        grounded = Physics.Raycast(camera.transform.position+target.transform.up*-groundedCheckOffset,target.transform.up*-1,groundedDistance,GroundLayers);
        Vector3 inverseLineOfSight = camera.transform.position - target.transform.position;
        RaycastHit hit;
        if (Physics.SphereCast(_target.transform.position, ViewRadius, inverseLineOfSight, out hit, optimalDistance, obstacleLayers))
        {
            targetDistance = Mathf.Min((hit.point - _target.transform.position).magnitude, optimalDistance);
        }
        else
        {
            targetDistance = optimalDistance;
        }
    }
    void FollowUpdate()
    {
        Vector3 cameraForward = _target.transform.position - camera.transform.position;                                  //摄像机到目标对象的矢量
        cameraForward = new Vector3(cameraForward.x,0.0f,cameraForward.z);
        float rotationAmout = Vector3.Angle(cameraForward,_target.transform.forward);
        if(rotationAmout<rotationThreshold)
        {
            lastStationaryPosition = _target.transform.position;
        }
        rotationAmout *= followUpdateSpeed * Time.deltaTime;
        if(Vector3.Angle(cameraForward,_target.transform.right)<Vector3.Angle(cameraForward,_target.transform.right*-1.0f))
        {
            rotationAmout *= -1.0f;
        }
        camera.transform.RotateAround(_target.transform.position, Vector3.up, rotationAmout);
    }
    void FreeUpdate()
    {
        float rotationH;
        FollowUpdate();
        rotationH = Input.GetAxis("Mouse Y") * rotationUpdateSpeed * Time.deltaTime;
        if(camera.transform.position.y-_target.transform.position.y>2f)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, _target.transform.position.y+ 2f, camera.transform.position.z);
            if(rotationH<0)
            {
                rotationH = 0;
            }
        }
        if (camera.transform.position.y - _target.transform.position.y < -1.5f)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, _target.transform.position.y - 1.5f, camera.transform.position.z);
            if(rotationH>0)
            {
                rotationH = 0;
            }
        }
        camera.transform.RotateAround(_target.transform.position, camera.transform.right, -1.0f*rotationH);
        bool lookFromBelow = Vector3.Angle(camera.transform.forward, target.transform.up * -1) > Vector3.Angle(camera.transform.forward, target.transform.up);
        camera.transform.LookAt(_target.transform.position);
        float forwardAngle = Vector3.Angle(target.transform.forward, SnappedCameraForward);
        //if (forwardAngle > maxForwardAngle)
        //{
        //    camera.transform.RotateAround(new Vector3(target.transform.position.x, target.transform.position.y + 1.5f, target.transform.position.z), camera.transform.right, lookFromBelow ? forwardAngle - maxForwardAngle : maxForwardAngle - forwardAngle);
        //}
    }
    void DistanceUpdate()
    {
        Vector3 dir = (camera.transform.position -_target.transform.position).normalized;        //target对象到摄像机的方向
        Vector3 targetPosition = _target.transform.position + dir * targetDistance;
        camera.transform.position = Vector3.Lerp(camera.transform.position, targetPosition, Time.deltaTime * distanceUpdateSpeed);
    }
    void LateUpdate()
    {
        if (Input.GetButton("Lock"))
        {
            controlLock = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isskilling = true;
        }
        else if (Input.GetButtonUp("Lock"))
        {
            controlLock = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isskilling = false;
        }
        if (controlLock)
        {
            //shifang.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            FreeUpdate();                                                                                                           //锁定光标
        }
        else
        {
            //shifang.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (Input.GetMouseButton(1))
            {
                float rotationH;
                rotationH = Input.GetAxis("Mouse Y") * rotationUpdateSpeed * Time.deltaTime;
                float rotationS;
                rotationS = Input.GetAxis("Mouse X") * rotationUpdateSpeed * Time.deltaTime;
                camera.transform.RotateAround(new Vector3(target.transform.position.x, _target.transform.position.y, target.transform.position.z), camera.transform.right, -1.0f * rotationH);
                camera.transform.RotateAround(new Vector3(target.transform.position.x, _target.transform.position.y, target.transform.position.z), camera.transform.up, rotationS);
                camera.transform.LookAt(_target.transform.position);
            }
        }
        lastStationaryPosition = _target.transform.position;
        DistanceUpdate();
    }
}
