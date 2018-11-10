using UnityEngine;
using System.Collections;

public class UIFollowTarget : MonoBehaviour {

    public RectTransform rectBloodPos;
    public int offsetx;
    public int offsety;


    void Update()
    {
        Vector2 vec2 = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);

        rectBloodPos.anchoredPosition = new Vector2(vec2.x - Screen.width / 2 + 0+ offsetx, vec2.y - Screen.height / 2 + 60+ offsety);//控制偏移量
    }

}
