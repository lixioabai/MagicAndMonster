using UnityEngine;
using System.Collections;

public class EveryBuff : MonoBehaviour {
    public float Bufftimes;
    Dot buffinfo=new Dot();

	void Start () {
        try
        {
            buffinfo = BuffInfo._Buffinstance.GetBuffInfoByld(BuffInfo._Buffinstance.GetBuffInfo(this.name));
        }
        catch
        {
            buffinfo = null;
        }
        Bufftimes = buffinfo.keeptime;
        switch(buffinfo.dot)
        {
            case Buff.SuperArmor: ChangeSuperArmorEffect(true);
                break;
        }
	}

	void Update () {
        Bufftimes -= Time.deltaTime;
        if(Bufftimes<=0)
        {
            ChangeSuperArmorEffect(false);
            Destroy(this.gameObject);
        }
	}

    public void ChangeSuperArmorEffect(bool b)
    {
        this.transform.parent.GetComponent<Player>().SuperArmor=b;
    }
}
