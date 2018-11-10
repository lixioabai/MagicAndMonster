using UnityEngine;
using System.Collections;
/// <summary>
/// 选择角色
/// </summary>
public class SelectPlayerFBX : MonoBehaviour {


    public Animation Ani;
    /// <summary>
    /// 移动至目标点
    /// </summary>
    public Transform MoveToPos;
    /// <summary>
    /// 出生点
    /// </summary>
    public Vector3 BirthPos;

    private Camera m_camera;

    public CapsuleCollider cc;

    private float moveSpeed=0.1f;

    public bool isShow = false;

    private bool isAttackOnce = false;

	void Start ()
    {
        Ani = GetComponent<Animation>();
        m_camera = Camera.main;
        cc = GetComponent<CapsuleCollider>();
        BirthPos = transform.position;
       
    }

    public void ShowPlayer()
    {

        //看向目标点
        //跑过来
        //看向相机
        //表演
        //待机
        float distance = Vector3.Distance(transform.position, MoveToPos.position);

      
            if (distance <= 1f)
            {
                LookPos(m_camera.transform);
                if (!isAttackOnce)
                {
                    Ani.CrossFade("attack01");
                   if(Ani["attack01"].normalizedTime>=0.9f)
                    {
                        isAttackOnce = true;
                        
                    }
                   
                }
                else
                {
                   Ani.CrossFade("Idle");
                }
                
               
            }
            else
            {
                LookPos(m_camera.transform);
                transform.position = Vector3.Lerp(transform.position, MoveToPos.position, moveSpeed);
                Ani.CrossFade("run");
            }
        
       
    }


    public void HidePlayer()
    {
        //看向目标点
        //跑回去
        //看向相机
        //待机
        float distance = Vector3.Distance(transform.position, BirthPos);

        if (distance <= 1f)
        {
            LookPos(m_camera.transform);
            Ani.CrossFade("Idle");
            

        }
        else
        {
            isAttackOnce = false;
            Ani.CrossFade("run");
            transform.position = Vector3.Lerp(transform.position, BirthPos, moveSpeed);
            LookPos(BirthPos);
        }

    }

    public void LookPos(Transform pos)
    {
        transform.LookAt(new Vector3(pos.position.x,0, pos.position.z));
    }

    public void LookPos(Vector3 pos)
    {
        transform.LookAt(new Vector3(pos.x,pos.y,pos.z));
    }


    private void FixedUpdate()
    {
        if (isShow)
        {
            ShowPlayer();
        }
        else
        {
           
            HidePlayer();
        }
       
    }

}
