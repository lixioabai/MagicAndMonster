using UnityEngine;
using System.Collections;

public class CountDownTime : MonoBehaviour
{

    public GameObject countDown;

    public long seconds;

    void Start()
    {
        InvokeRepeating("CountDown", 0, 1);
    }

    void Update()
    {

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
            countDown.GetComponent<UILabel>().text = ((seconds / 60) % 60).ToString("D2") + ":" + (seconds % 60).ToString("D2");  
        }
    }

}
