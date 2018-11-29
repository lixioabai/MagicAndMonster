using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 对象池
/// </summary>
public class ObjectPoor:MonoBehaviour{

    private static Queue<GameObject> pool;

    private static Dictionary<string, Queue<GameObject>> PooLList;

    private static ObjectPoor _instance;

    public static ObjectPoor Instance()
    {
        if (_instance == null)
        {
            _instance = new GameObject("ObjectPoor").AddComponent<ObjectPoor>();
           
            PooLList = new Dictionary<string, Queue<GameObject>>();
        }
        return _instance;
    }




    public void Create(GameObject _prefab, Vector3 pos, Quaternion qua,GameObject target=null)
    {
       
        GameObject go = null;
        GameObject parent = GameObject.Find(_prefab.name + "_parent");
        if (parent == null)
        {
            parent = new GameObject(_prefab.name + "_parent");
        }

        if (!PooLList.ContainsKey(_prefab.name))
        {
            pool = new Queue<GameObject>();
            PooLList.Add(_prefab.name, pool);


            if (pool.Count > 0)
            {
                go = pool.Dequeue();
                go.gameObject.SetActive(true);
                go.transform.position = pos;
                go.transform.rotation = qua;
                if (target != null)
                {
                    go.GetComponent<MMORPG_PlayerNormalAttack_Arrow>().target = target;
                }

            }
            else
            {
                go = GameObject.Instantiate(_prefab, pos, qua) as GameObject;
                go.transform.SetParent(parent.transform);
                if (target != null)
                {
                   
                    go.GetComponent<MMORPG_PlayerNormalAttack_Arrow>().target= target;
                   
                }
            }
        }
        else
        {
            if (PooLList[_prefab.name].Count > 0)
            {
                go = PooLList[_prefab.name].Dequeue();
                go.gameObject.SetActive(true);
                go.transform.position = pos;
                go.transform.rotation = qua;
                if (target != null)
                {
                    go.GetComponent<MMORPG_PlayerNormalAttack_Arrow>().target = target;
                }
            }
            else
            {
                go = GameObject.Instantiate(_prefab, pos, qua) as GameObject;
                go.transform.SetParent(parent.transform);
                if (target != null)
                {
                    go.GetComponent<MMORPG_PlayerNormalAttack_Arrow>().target = target;
                }
            }
        }
    }


        /// <summary>
        /// 移除特效并加入队列
        /// </summary>
        /// <param name="_object"></param>
        /// <param name="_resourcesPos"></param>
        /// <param name="qua"></param>
        public  void Delete(GameObject _object, Vector3 _resourcesPos, Quaternion qua)
    {
        Debug.Log(_object.name.Length);

         string name = _object.name.Remove(_object.name.Length-7,7);
         Debug.Log(name);
        _object.gameObject.SetActive(false);
        _object.transform.position = _resourcesPos;
        _object.transform.localRotation = qua;
        PooLList[name].Enqueue(_object);
        _object.GetComponent<MMORPG_PlayerNormalAttack_Arrow>().target = null;
    }

}
