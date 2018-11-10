﻿using UnityEngine;
using System.Collections;

public class MMORPG_Buff_Dark : MMORPG_BaseBuff
{

    public override void OnInit(EnumDefine.BuffType type, float time, MMORPG_BaseObject owner, float value)
    {
        base.OnInit(type, time, owner, value);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Debug.Log("暗属性增益buff 正在生效");
    }

    public override void OnDestory()
    {
        base.OnDestory();
        Debug.Log("暗属性增益buff 已移除");
    }

    

}
