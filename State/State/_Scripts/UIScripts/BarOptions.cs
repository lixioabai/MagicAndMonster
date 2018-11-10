using UnityEngine;
using System.Collections;

public class BarOptions : MonoBehaviour
{

    public GameObject target;

    void Start()
    {

    }

    void OnHover(bool isOver)
    {
        if (isOver)
        {
            Singleton.keyControl.Show_Tooltip(target);
            Singleton.inventory.showTooltip = true;
        }
        else
        {
            Singleton.inventory.showTooltip = false;
        }
    }

}
