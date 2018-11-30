using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 在实体之间传递的消息
/// </summary>
public class Telegram
{
    public Transform SenderTrans;       // 发送者
    public Transform ReceiverTrans;     // 接受者
    public int Msg;                     // 消息类型（一个枚举值）
    public float hurt;                  //伤害值
    public EnumDefine.DeBuffType debufftype;  //debuff
    public EnumDefine.BuffType bufftype;     //buff
    public float buffvalue;                  //buff值
    public float bufftime;                   //buff作用时间
    public float DispatchTime;          // 延迟时间
    public MonoBehaviour _Behaviour;    // 绑在游戏对象上的脚本里的继承自BaseGameEntity的类
    public Telegram(float time, Transform senderTrans, Transform receiverTrans, int msg, MonoBehaviour mb,float hurt1,EnumDefine.BuffType buff,float bfvalue,float bftime)
    {
        DispatchTime = time;
        SenderTrans = senderTrans;
        ReceiverTrans = receiverTrans;
        Msg = msg;
        _Behaviour = mb;
        hurt = hurt1;
        bufftype = buff;
        buffvalue = bfvalue;
        bufftime = bftime;
        debufftype = EnumDefine.DeBuffType.None;
    }

    public Telegram(float time, Transform senderTrans, Transform receiverTrans, int msg, MonoBehaviour mb, float hurt1, EnumDefine.DeBuffType debuff, float bfvalue, float bftime)
    {
        DispatchTime = time;
        SenderTrans = senderTrans;
        ReceiverTrans = receiverTrans;
        Msg = msg;
        _Behaviour = mb;
        hurt = hurt1;
        debufftype = debuff;
        buffvalue = bfvalue;
        bufftime = bftime;
        bufftype = EnumDefine.BuffType.None;
    }

    public Telegram(float time, Transform senderTrans, Transform receiverTrans, int msg, MonoBehaviour mb, float hurt1)
    {
        DispatchTime = time;
        SenderTrans = senderTrans;
        ReceiverTrans = receiverTrans;
        Msg = msg;
        _Behaviour = mb;
        hurt = hurt1;
        debufftype = EnumDefine.DeBuffType.None;
        bufftype = EnumDefine.BuffType.None;
    }


}
/// <summary>
/// 该类负责实体之间消息的传递
/// </summary>
public class MessageDispatcher
{
    public float SEND_MSG_IMMEDIATELY = 0.0f;   // 立刻执行消息
    public int NO_ADDITIONAL_INFO = 0;
    public int SENDER_ID_IRRELEVANT = -1;
    private static MessageDispatcher instance;  // 该类的实例只会有一个，而且存储在该静态变量当中
    private IList<Telegram> PriorityQ = new List<Telegram>();   // 延迟消息队列

    private void Discharge(BaseGameEntity receiver, Telegram telegram)
    {
        if (!receiver.HandleMessage(telegram))
        {
            //Debug.LogError("无法解析的消息");
        }
    }

    /// <summary>
    /// 在实体之间传递消息
    /// </summary>
    /// <param name="delay">该消息延迟执行的时间</param>
    /// <param name="senderTrans">消息发送者</param>
    /// <param name="receiverTrans">消息接受者</param>
    /// <param name="msg">消息的类型，由一个枚举值转化而来</param>
    /// <param name="_mb">当前游戏实体（就是挂在目标游戏物体上的相应脚本）</param>
    public void DispatchMessage(float delay, Transform senderTrans, Transform receiverTrans, int msg, MonoBehaviour _mb,float hurt1,EnumDefine.BuffType buff,float bfvalue,float bftime)
    {
        // 由接受者的Transform获取它的实体（其实就是对应脚本）
        BaseGameEntity receiver = EntityManager.Instance.GetEntityFromTransform(receiverTrans);
        Telegram telegram = new Telegram(delay, senderTrans, receiverTrans, msg, _mb,hurt1, buff,bfvalue,bftime);

        if (delay <= 0.0f)
        {
            //Debug.Log("No Delay");
            Discharge(receiver, telegram);
        }
        else
        {
            //Debug.Log("In Delay");
            // 目前经过的时间，从游戏开始之后计算
            float currentTime = Time.realtimeSinceStartup;
            telegram.DispatchTime = currentTime + delay;

            // 查找重复的消息，重复的话就直接return
            foreach (Telegram val in PriorityQ)
            {
                if (val.SenderTrans == senderTrans && val.ReceiverTrans == receiverTrans && val.Msg == msg)
                {
                    return;
                }
            }

            // 一个延时执行的消息队列
            PriorityQ.Add(telegram);
        }
    }

    /// <summary>
    /// 在实体之间传递消息
    /// </summary>
    /// <param name="delay">该消息延迟执行的时间</param>
    /// <param name="senderTrans">消息发送者</param>
    /// <param name="receiverTrans">消息接受者</param>
    /// <param name="msg">消息的类型，由一个枚举值转化而来</param>
    /// <param name="_mb">当前游戏实体（就是挂在目标游戏物体上的相应脚本）</param>
    public void DispatchMessage(float delay, Transform senderTrans, Transform receiverTrans, int msg, MonoBehaviour _mb, float hurt1, EnumDefine.DeBuffType debuff,float bfvalue,float bftime)
    {
        // 由接受者的Transform获取它的实体（其实就是对应脚本）
        BaseGameEntity receiver = EntityManager.Instance.GetEntityFromTransform(receiverTrans);
        Telegram telegram = new Telegram(delay, senderTrans, receiverTrans, msg, _mb, hurt1, debuff,bfvalue,bftime);

        if (delay <= 0.0f)
        {
            //Debug.Log("No Delay");
            Discharge(receiver, telegram);
        }
        else
        {
            //Debug.Log("In Delay");
            // 目前经过的时间，从游戏开始之后计算
            float currentTime = Time.realtimeSinceStartup;
            telegram.DispatchTime = currentTime + delay;

            // 查找重复的消息，重复的话就直接return
            foreach (Telegram val in PriorityQ)
            {
                if (val.SenderTrans == senderTrans && val.ReceiverTrans == receiverTrans && val.Msg == msg)
                {
                    return;
                }
            }

            // 一个延时执行的消息队列
            PriorityQ.Add(telegram);
        }
    }


    /// <summary>
    /// 在实体之间传递消息
    /// </summary>
    /// <param name="delay">该消息延迟执行的时间</param>
    /// <param name="senderTrans">消息发送者</param>
    /// <param name="receiverTrans">消息接受者</param>
    /// <param name="msg">消息的类型，由一个枚举值转化而来</param>
    /// <param name="_mb">当前游戏实体（就是挂在目标游戏物体上的相应脚本）</param>
    public void DispatchMessage(float delay, Transform senderTrans, Transform receiverTrans, int msg, MonoBehaviour _mb, float hurt1)
    {
        // 由接受者的Transform获取它的实体（其实就是对应脚本）
        BaseGameEntity receiver = EntityManager.Instance.GetEntityFromTransform(receiverTrans);
        Telegram telegram = new Telegram(delay, senderTrans, receiverTrans, msg, _mb, hurt1);

        if (delay <= 0.0f)
        {
            //Debug.Log("No Delay");
            Discharge(receiver, telegram);
        }
        else
        {
            //Debug.Log("In Delay");
            // 目前经过的时间，从游戏开始之后计算
            float currentTime = Time.realtimeSinceStartup;
            telegram.DispatchTime = currentTime + delay;

            // 查找重复的消息，重复的话就直接return
            foreach (Telegram val in PriorityQ)
            {
                if (val.SenderTrans == senderTrans && val.ReceiverTrans == receiverTrans && val.Msg == msg)
                {
                    return;
                }
            }

            // 一个延时执行的消息队列
            PriorityQ.Add(telegram);
        }
    }



    /// <summary>
    /// 延时消息队列的检测和执行
    /// </summary>
    public void DispatchDelayedMessage()
    {
        float currentTime = Time.realtimeSinceStartup;
        for (int i = 0; i < PriorityQ.Count; ++i)
        {
            Telegram val = PriorityQ[i];
            if (val.DispatchTime < currentTime && val.DispatchTime > 0.0f)
            {
                BaseGameEntity receiver = EntityManager.Instance.GetEntityFromTransform(val.ReceiverTrans);
                Discharge(receiver, val);
                PriorityQ.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// 该类在游戏过程中只会有一个实例
    /// </summary>
    public static MessageDispatcher Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MessageDispatcher();
            }
            return instance;
        }
    }
}