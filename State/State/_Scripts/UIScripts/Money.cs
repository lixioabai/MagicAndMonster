using UnityEngine;
using System.Collections;

public class Money : MonoBehaviour
{

    public int goldcoin;// 当前金币
    public int sivercoin;// 当前银币
    public int coppercoin;// 当前铜币

    public GameObject goldlabel;// 金币标签
    public GameObject siverlabel;// 银币标签
    public GameObject copperlabel;// 铜币标签

    void Start()
    {
        //初始化金币
        Set_Money(goldcoin, sivercoin, coppercoin);
    }

    //更新金币
    public void Set_Money(int num1, int num2, int num3)
    {
        //铜币转换
        if (num3 >= 100)
        {
            num2 = num2 + num3 / 100;
            num3 = num3 % 100;
            coppercoin = num3;
            copperlabel.GetComponent<UILabel>().text = coppercoin.ToString("#0");
        }
        else
        {
            coppercoin = num3;
            copperlabel.GetComponent<UILabel>().text = coppercoin.ToString("#0");
        }

        //银币转换
        if (num2 >= 100)
        {
            num1 = num1 + num2 / 100;
            num2 = num2 % 100;
            sivercoin = num2;
            siverlabel.GetComponent<UILabel>().text = sivercoin.ToString("#0");
        }
        else
        {
            sivercoin = num2;
            siverlabel.GetComponent<UILabel>().text = sivercoin.ToString("#0");
        }

        goldcoin = num1;
        goldlabel.GetComponent<UILabel>().text = goldcoin.ToString("#, ##0");
    }

    //保存金钱
    public void SaveMoney()
    {
        PlayerPrefs.SetInt("goldcoin", goldcoin);
        PlayerPrefs.SetInt("sivercoin", sivercoin);
        PlayerPrefs.SetInt("coppercoin", coppercoin);
    }

    //加载金钱
    public void LoadMoney()
    {
        Set_Money(PlayerPrefs.GetInt("goldCoin"), PlayerPrefs.GetInt("sivercoin"), PlayerPrefs.GetInt("coppercoin"));
    }
}
