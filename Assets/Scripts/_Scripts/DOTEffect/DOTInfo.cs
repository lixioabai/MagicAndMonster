using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DOTInfo : MonoBehaviour {
	public static DOTInfo _dotinstance;
	public TextAsset DotInfotext;
	private IDictionary<Buff,Dot> dotInfoDict = new Dictionary<Buff,Dot>();
	void Awake()
	{
		_dotinstance = this;
		IntDotInfoDict();
	}
	void Start () {
	}
	void Update () {
	}
	void IntDotInfoDict()					//从文本中读取buff效果信息
	{
		string text = DotInfotext.text;
		string[] dotinfoArray = text.Split('\n');
		foreach (string skillinfoStr in dotinfoArray)
		{
			string[] pa = skillinfoStr.Split(',');
			Dot info = new Dot();
			string str_applypro1 = pa[0];
			switch (str_applypro1)
			{
			case"Drug":	info.dot=Buff.Drug;
				break;
			case"Frostbite":info.dot=Buff.Frostbite;
				break;
			case"Burnt":info.dot=Buff.Burnt;
				break;
			case"Shield":info.dot=Buff.Shield;
				break;
			}
			info.name = pa[1];
			info.keeptime =float.Parse(pa[2]);
			info.xgz =float.Parse(pa[3]);
			string str_applypro = pa[4];
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
			case "HP":
				info.applyProperty = SkillProperty.HP;
				break;
			}
			dotInfoDict.Add(info.dot,info);
		}
	}
	public Dot GetSkillInfoByld(Buff dot)				//通过buff类来返回相应的buff信息
	{
		Dot info = null;
		dotInfoDict.TryGetValue(dot, out info);
		return info;
	}
}