using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityType<entityType>
{
    public entityType Target;
    public string Name;
}

/// <summary>
/// 该类用于管理目前游戏内存在的所有实例
/// </summary>
public class EntityManager
{
    private static EntityManager instance;
    private Dictionary<Transform, BaseGameEntity> mEntityMap
        = new Dictionary<Transform, BaseGameEntity>();

    /// <summary>
    /// 由Transform到游戏实体（其实就是对应脚本）的一个映射
    /// </summary>
    /// <param name="trans">需要查找的目标Transform</param>
    /// <returns>返回查找的结果</returns>
    public BaseGameEntity GetEntityFromTransform(Transform trans)
    {
        foreach (KeyValuePair<Transform, BaseGameEntity> val in mEntityMap)
        {
            if (val.Key == trans)
                return val.Value;
        }
        return null;
    }

    public void RemoveEntity(BaseGameEntity pEntity)
    {
        foreach (KeyValuePair<Transform, BaseGameEntity> val in mEntityMap)
        {
            if (val.Value == pEntity)
                mEntityMap.Remove(val.Key);
        }
    }

    /// <summary>
    /// 将某个实体添加到mEntityMap字典当中
    /// </summary>
    /// <param name="NewEntity">需要添加的实体</param>
    public void RegisterEntity(BaseGameEntity NewEntity)
    {
        mEntityMap.Add(NewEntity.myTransform, NewEntity);
    }

    /// <summary>
    /// 该类在游戏过程中只会有一个实例
    /// </summary>
    public static EntityManager Instance
    {
        get
        {
            if (instance == null)
                instance = new EntityManager();
            return instance;
        }
    }
}