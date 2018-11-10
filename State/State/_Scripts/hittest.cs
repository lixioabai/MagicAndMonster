using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class hittest : MonoBehaviour {
    RPGMotor enemymotor;
    public GameObject beijitexiao;
    GameObject texiao;
    GameObject[] allenemys;
    HashSet<GameObject> hitenemys = new HashSet<GameObject>();
    ArrayList suoyoudiren = new ArrayList();
    ArrayList suoyoudiren1 = new ArrayList();
    ArrayList beijidiren = new ArrayList();
    float chou = 1f;
    bool chou2 = false;
    int i = 0;
    //shuzhishengcheng sc;
    void Start()
    {
        allenemys = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject o in allenemys)
        {
            hitenemys.Add(o.gameObject);
            suoyoudiren.Add(o.gameObject);
            suoyoudiren1.Add(o.gameObject);
        }
    }
    void Update()
    {
        chou -= Time.deltaTime;
        if (chou <= 0)
        {
            suoyoudiren1.Clear();
            foreach (GameObject o in allenemys)
            {
                suoyoudiren1.Add(o.gameObject);
            }
            chou2 = true;
            chou = Random.Range(1f,5f);
        }
    }
    void OnTriggerStay(Collider other)
    {
        foreach (GameObject o in suoyoudiren)
        {
            if (other.gameObject == o.gameObject)
            {
                beijidiren.Add(o.gameObject);
            }
        }
        if (chou2)
        {
            foreach (GameObject o in suoyoudiren1)
            {
                if (other.gameObject == o.gameObject)
                {
                    MessageDispatcher.Instance.DispatchMessage(0, this.transform, other.transform, (int)MessagesType.Msg_BeingHurt, EntityManager.Instance.GetEntityFromTransform(this.transform), 10f, Buff.Burnt);
                    enemymotor = other.GetComponent<RPGMotor>();
                    texiao = (GameObject)Instantiate(beijitexiao, new Vector3(other.transform.position.x, other.transform.position.y + 1f, other.transform.position.z), other.transform.rotation);
                    Destroy(texiao, 1f);
                    suoyoudiren1.Remove(o.gameObject);
                    break;
                }
            }
        }
    }
}
