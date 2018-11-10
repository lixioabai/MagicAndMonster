using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuffInfo : MonoBehaviour {
    int i = 0;
    public static BuffInfo _Buffinstance;
    private IDictionary<int, Dot> buffInfoDict = new Dictionary<int, Dot>();
    void Awake()
    {
        _Buffinstance = this;
    }
	void Start () {
	
	}
	void Update () {
        if (i == 0)
        {
            try
            {
                IntBuffInfoDict();
                i = 1;
            }
            catch { }
        }
	}
    void IntBuffInfoDict()
    {
        CSV.GetInstance().loadFile(Application.dataPath + "/_Scripts/Skills/BuffBase", "Buffs.csv");
        foreach(string buffinfoStr in CSV.GetInstance().m_ArrayData)
        {
            try
            {
                string[] pa = buffinfoStr.Split(',');
                Dot info = new Dot();
                info.ID = int.Parse(pa[0]);
                string str_buff = pa[1];
                switch(str_buff)
                {
                    case "Drug": info.dot = Buff.Drug;
                        break;
                    case "Frostbite": info.dot = Buff.Frostbite;
                        break;
                    case "Burnt": info.dot = Buff.Burnt;
                        break;
                    case "Shield": info.dot = Buff.Shield;
                        break;
                    case "SuperArmor": info.dot = Buff.SuperArmor;
                        break;
                    case "Null": info.dot = Buff.Null;
                        break;
                }
                info.name = pa[2];
                info.keeptime = int.Parse(pa[3]);
                info.xgz=int.Parse(pa[4]);
                string str_applypro = pa[5];
                switch (str_applypro)
                {
                    case "MoveSpeed":
                        info.applyProperty = SkillProperty.MoveSpeed;
                        break;
                    case "DEF":
                        info.applyProperty = SkillProperty.DEF;
                        break;
                    case "Attack":
                        info.applyProperty = SkillProperty.Attack;
                        break;
                    case "Field":
                        info.applyProperty = SkillProperty.Field;
                        break;
                    case "HP":
                        info.applyProperty = SkillProperty.HP;
                        break;
                    case "HPre":
                        info.applyProperty = SkillProperty.HPre;
                        break;
                }
                buffInfoDict.Add(info.ID, info);
            }
            catch { }
        }
    }

    public Dot GetBuffInfoByld(int id)
    {
        Dot info = null;
        buffInfoDict.TryGetValue(id, out info);
        return info;
    }

    public int GetBuffInfo(string name)
    {
        Buff buff=Buff.Null;
        switch(name)
        {
            case "SuperArmor": buff = Buff.SuperArmor;
                break;
        }
        int RetirnId = 0;
        foreach (KeyValuePair<int, Dot> d in buffInfoDict)
        {
            if (d.Value.dot == buff)
            {
                RetirnId = d.Key;
                break;
            }
        }
        return RetirnId;
    }
}
