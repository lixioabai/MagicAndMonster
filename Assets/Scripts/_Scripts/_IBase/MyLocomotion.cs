using UnityEngine;
using System.Collections;

public class MyLocomotion{
    private Animator m_Animator = null;                             //Animator组件对象
    private int m_SpeedId = 0;                                              //动画参数speed对应的Hash ID，该ID由Animator.StringToHash依动画参数名称生成
    private int m_AgularSpeedId = 0;                                   //同上
    private int m_DirectionId = 0;
    public float m_SpeedDampTime = 0.1f;                            //设置动画参数speed时的插值时间
    public float m_AnguarSpeedDampTime = 0.25f;             //设置动画参数AnguarSpeed是的插值时间
    public float m_DirectionResponseTime = 0.2f;                    //表示Teddy对象旋转一定方向时消耗的时间，用于计算Teddy对象运动时的角度

    public MyLocomotion(Animator animator)
    {
        m_Animator = animator;
        m_SpeedId = Animator.StringToHash("Speed");
        m_AgularSpeedId = Animator.StringToHash("AngularSpeed");
        m_DirectionId = Animator.StringToHash("Direction");
    }
    public void Do(float speed,float direction)
    {
        AnimatorStateInfo state = m_Animator.GetCurrentAnimatorStateInfo(0);                    //保存当前动画状态
        bool inTransition=m_Animator.IsInTransition(0);                                                                 //检测是否正处于两个动画状态间的过渡状态上
        bool inIdle=state.IsName("Locomotion.Idle");                                                                        //检测是否处于动画“idle”上
        bool inTurn = state.IsName("Locomotion.TurnOnSpot");
        bool inWalkRun = state.IsName("Locomotion.WalkRun");
        float speedDampTime = inIdle ? 0 : m_SpeedDampTime;
        float angularSpeedDampTime = inWalkRun || inTransition ? m_AnguarSpeedDampTime : 0;  //表示根据当前Teddy对象的动画状态设定对应动画参数的插值时间
        float directionDampTime = inTurn || inTransition ? 1000000 : 0;
        float angularSpeed = direction / m_DirectionResponseTime;                                                   //表示根据旋转角度direction和时间计算出的角速度
        m_Animator.SetFloat(m_SpeedId,speed,speedDampTime,Time.deltaTime);
        m_Animator.SetFloat(m_AgularSpeedId,angularSpeed,angularSpeedDampTime,Time.deltaTime);
        m_Animator.SetFloat(m_DirectionId,direction,directionDampTime,Time.deltaTime);
    }
}
