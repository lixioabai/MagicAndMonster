using UnityEngine;
using System.Collections;

/// <summary>
/// Boss血条
/// </summary>

public class BossBlood : MonoBehaviour
{
    private Transform bloodFirstLayer;
    private Transform bloodSecondLayer;
    private Transform bloodThirdLayer;
    private Transform bloodFourthLayer;
    private Transform bloodFiveLayer;

    private Transform bloodFirstProgressBar;
    private Transform bloodSccondProgressBar;
    private Transform bloodThirdProgressBar;
    private Transform bloodFourthProgressBar;
    private Transform bloodFiveProgressBar;
    private Transform bossInfo;

    void Start()
    {
        bloodFirstLayer = transform.FindChild("Win/Blood/firstlayer/Label");
        bloodSecondLayer = transform.FindChild("Win/Blood/secondlayer/Label");
        bloodThirdLayer = transform.FindChild("Win/Blood/thirdlayer/Label");
        bloodFourthLayer = transform.FindChild("Win/Blood/fourthlayer/Label");
        bloodFiveLayer = transform.FindChild("Win/Blood/fifthlayer/Label");

        bloodFirstProgressBar = transform.FindChild("Win/Blood/firstlayer");
        bloodSccondProgressBar = transform.FindChild("Win/Blood/secondlayer");
        bloodThirdProgressBar = transform.FindChild("Win/Blood/thirdlayer");
        bloodFourthProgressBar = transform.FindChild("Win/Blood/fourthlayer");
        bloodFiveProgressBar = transform.FindChild("Win/Blood/fifthlayer");
        bossInfo = transform.FindChild("Win/BossInfo/Label");
    }

    void Update()
    {
        GetFriendInformation();
    }

    public void GetFriendInformation()
    {
        if (bloodFiveProgressBar.GetComponent<UIProgressBar>().value == 0.0f)
        {
            bloodFiveProgressBar.gameObject.SetActive(false);
            bloodFourthLayer.GetComponent<UILabel>().depth = 8;

            if (bloodFourthProgressBar.GetComponent<UIProgressBar>().value == 0.0f)
            {
                bloodFourthProgressBar.gameObject.SetActive(false);
                bloodThirdLayer.GetComponent<UILabel>().depth = 6;

                if (bloodThirdProgressBar.GetComponent<UIProgressBar>().value == 0.0f)
                {
                    bloodThirdProgressBar.gameObject.SetActive(false);
                    bloodSecondLayer.GetComponent<UILabel>().depth = 4;

                    if (bloodSccondProgressBar.GetComponent<UIProgressBar>().value == 0.0f)
                    {
                        bloodSccondProgressBar.gameObject.SetActive(false);
                        bloodFirstLayer.GetComponent<UILabel>().depth = 2;

                        if (bloodFirstProgressBar.GetComponent<UIProgressBar>().value == 0.0f)
                        {
                            bloodFirstProgressBar.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
        //blood.GetComponent<UILabel>().text = "500/1000";
        //bloodProgressBar.GetComponent<UIProgressBar>().value = 500f / 1000f;
        //bloodFiveProgressBar.GetComponent<UIProgressBar>().value = 1f;
        bossInfo.GetComponent<UILabel>().text = "Lv." + "100" + " " + "这里是个大BOSS";
    }

}
