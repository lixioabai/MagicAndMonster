using UnityEngine;
using System.Collections;


public class MMORPG_PC_Controller : MonoBehaviour {

    CharacterController cc;

    public float turnSmoothing = 15f;   // 玩家平滑转向的速度
    public float speedDampTime = 0.1f;  // 速度缓冲时间
    public float moveSpeed = 1f;
    void Start ()
    {
        cc = GetComponent<CharacterController>();
	}


    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if(h!=0||v!=0)
        {
            MovementManagement(h, v);
            cc.SimpleMove(transform.forward*moveSpeed);
        }
    }

    void MovementManagement(float horizontal, float vertical)
    {
        // 如果横向或纵向按键被按下 也就是说角色处于移动中
        if (horizontal != 0f || vertical != 0f)
        {
            // 设置玩家的旋转 并把速度设为5.5
            Rotating(horizontal, vertical);
           
        }
     
    }


    void Rotating(float horizontal, float vertical)
    {
        // 创建角色目标方向的向量
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

        // 创建目标旋转值 
        //对应参数分别是 1.四元数看向的目标 2.需要沿着旋转的轴
        Quaternion targetRotation = Quaternion.LookRotation(-targetDirection, Vector3.up);

        // 创建新旋转值 并根据转向速度平滑转至目标旋转值
        Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);

        // 更新旋转值为 新旋转值
        transform.rotation = newRotation;
        
    }

}
