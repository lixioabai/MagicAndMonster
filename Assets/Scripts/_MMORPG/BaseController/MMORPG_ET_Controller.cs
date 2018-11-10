using UnityEngine;
using System.Collections;

public class MMORPG_ET_Controller : MonoBehaviour {

    MMORPG_BaseObject_Player Owner;
    CharacterController cc;
    private void Start()
    {
        Owner = GetComponent<MMORPG_BaseObject_Player>();
        cc = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        EasyJoystick.On_JoystickMove += JoystickMove;
        EasyJoystick.On_JoystickMoveEnd += JoystickMoveEnd;
    }

    void JoystickMove(MovingJoystick move)
    {
        if (move.joystickName == "MoveJoystick")
        {
           

            //获取摇杆中心偏移的坐标  
            float joyPositionX = -move.joystickAxis.x;
            float joyPositionY = -move.joystickAxis.y;

            if (joyPositionY != 0 || joyPositionX != 0)
            {
                Owner.isET = true;
                Owner.GetFSM().ChangeState(MMORPG_BaseObject_Player_State_Move.Instance);
                //设置角色的朝向（朝向当前坐标+摇杆偏移量）  
                transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));
                //移动玩家的位置（按朝向位置移动）  
                cc.SimpleMove(transform.forward);
               // transform.Translate(Vector3.forward * Time.deltaTime * 5);
                //播放奔跑动画  


            }
        }
    }

   void JoystickMoveEnd(MovingJoystick move)
    {
        if (move.joystickName == "MoveJoystick")
        {
            Owner.isET = false;
            Owner.GetFSM().ChangeState(MMORPG_BaseObject_Player_State_Idle.Instance);
        }

    }


}
