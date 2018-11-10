using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillInfo : MonoBehaviour {
	int i =0;
	public static SkillInfo _Skillinstance;
	private IDictionary<int,Skills> skillInfoDict = new Dictionary<int,Skills>();
	void Awake()
	{
		_Skillinstance = this;
	}
    void Start()
    {
    }
	void Update () {
		if(i==0)
		{
			try
			{
				IntSkillInfoDict();
				i=1;
			}
            catch { }
		}
	}
	void IntSkillInfoDict()						//获取文本中的技能信息
	{
        CSV.GetInstance().loadFile(Application.dataPath + "/_Scripts/Skills", "Skills.csv");   //打开csv文件
        foreach (string skillinfoStr in CSV.GetInstance().m_ArrayData)
		{
            try
            {
                string[] pa = skillinfoStr.Split(',');
                Skills info = new Skills();
                info.ID = int.Parse(pa[0]);
                info.iconname = pa[1];
                info.name = pa[2];
                info.Key = pa[3];
                info.Times = float.Parse(pa[4]);
                info.hitnum = float.Parse(pa[5]);
                string str_dots = pa[6];
                switch (str_dots)
                {
                    case "Drug": info.buff = Buff.Drug;
                        break;
                    case "Frostbite": info.buff = Buff.Frostbite;
                        break;
                    case "Burnt": info.buff = Buff.Burnt;
                        break;
                    case "Shield": info.buff = Buff.Shield;
                        break;
                    case "Null": info.buff = Buff.Null;
                        break;
                }
                string str_applypro = pa[7];
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
                info.fly = int.Parse(pa[8]);
                info.weight = int.Parse(pa[9]);
                info.playername=pa[10];
                skillInfoDict.Add(info.ID, info);
            }
            catch { }
		}
	}
	public Skills GetSkillInfoByld(int id)		//通过技能id获得相应的技能信息
	{
		Skills info = null;
		skillInfoDict.TryGetValue(id, out info);
		return info;
	}
	public int GetSkillInfo(Sprite icon)			//通过按键反回技能id
	{
		int RetirnId = 0;
		foreach(KeyValuePair<int,Skills> d in skillInfoDict)
		{
			if (d.Value.iconname == icon.name)
			{
				RetirnId = d.Key;
				break;
			}
		}
		return RetirnId;
	}
}
