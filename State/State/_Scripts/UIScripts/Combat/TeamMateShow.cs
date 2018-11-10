using UnityEngine;
using System.Collections;

public class TeamMateShow : MonoBehaviour
{

    public GameObject blood;//血条
    public GameObject mast;//遮罩
    public long seconds;//死亡倒计时时间

    //public bool dead = false;//当前是否死亡

    void Start()
    {
        Instantiate();
        blood.GetComponent<UIProgressBar>().value = 0;
        InvokeRepeating("CountDown", 0, 1);
    }

    void Update()
    {
        //         if (seconds == 0)
        //         {
        //             teammate.GetComponentInChildren<UILabel>().text = "";
        //             mast.SetActive(false);
        //             blood.GetComponent<UIProgressBar>().value = 1.0f;
        //         }
        //         if (blood.GetComponent<UIProgressBar>().value != 0)
        //         {
        //             teammate.GetComponentInChildren<UILabel>().text = "";
        //             mast.SetActive(false);
        //             CancelInvoke();
        //         }

    }

    void Instantiate()
    {
        mast.SetActive(false);
        this.GetComponentInChildren<UILabel>().text = "";
    }

    void CountDown()
    {
        if (seconds != 0)
        {
            if (seconds > 3600)
            {
                seconds = 3600;
            }
            seconds -= 1;
            mast.SetActive(true);
            this.GetComponentInChildren<UILabel>().text = ((seconds / 60) % 60).ToString("D2") + ":" + (seconds % 60).ToString("D2");
        }
        else
        {
            Instantiate();
            blood.GetComponent<UIProgressBar>().value = 1;
        }
    }

}
