using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


[Serializable] //序列化
public class GameObjectManager  {

    [SerializeField]
    public string name; //池子的名字，根据这个名字获取对象
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private int maxAmound;


    [NonSerialized]
    private List<GameObject> goList = new List<GameObject>();



    /// <summary>
    /// 从资源池中获取一个实例
    /// </summary>
    public GameObject GetInst()
    {
        /*这里考虑到跨场景后销毁实例的情况，对实例从新实例化一次即可*/
        for (int i = 0; i < goList.Count; i++) 
        {
            if (goList[i].gameObject == null)
            {
                GameObject tempNull = GameObject.Instantiate(prefab) as GameObject;
                goList[i] = tempNull;
                goList[i].SetActive(false);
            }
            else
            {
                if (goList[i].activeInHierarchy == false)
                {
                    goList[i].SetActive(true);
                    return goList[i];
                }
            }
            if (goList[i].activeInHierarchy == false)
            {
                goList[i].SetActive(true);
                return goList[i];
            }
        }


        if (goList.Count >= maxAmound)
        {
            //删除一个旧的 实例化一个新的
            GameObject.Destroy(goList[0]);
            goList.RemoveAt(0);
        }

        GameObject temp = GameObject.Instantiate(prefab) as GameObject;
        goList.Add(temp);

        return temp;
    }

	
}
