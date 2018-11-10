using UnityEngine;
using System.Collections;

public class MMORPG_BaseObject_AI_State_Die : State<MMORPG_BaseObject_AI>
{

    private static MMORPG_BaseObject_AI_State_Die instance;
    public static MMORPG_BaseObject_AI_State_Die Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MMORPG_BaseObject_AI_State_Die();
            }
            return instance;
        }
    }
}
