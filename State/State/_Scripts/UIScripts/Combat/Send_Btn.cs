using UnityEngine;
using System.Collections;

public class Send_Btn : MonoBehaviour
{

    public UITextList textList;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.OnClick();
        }
    }

    void OnClick()
    {
        GameObject input_Label = GameObject.Find("Input_Label");
        string text_str = "[FF0000FF]玩家：[-]" + input_Label.GetComponent<UILabel>().text;
        textList.Add(text_str);
        input_Label.GetComponent<UILabel>().text = "";
    }

}
