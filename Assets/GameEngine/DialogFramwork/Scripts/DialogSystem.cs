using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// 对话系统
/// </summary>
public class DialogSystem : MonoBehaviour {

    /// <summary>
    /// 读取对话节点及所有对话信息
    /// </summary>
    public List<DialogXMLLoadAndSave.DialogNode> DialogInfor = new List<DialogXMLLoadAndSave.DialogNode>();
    public string[] Headshots;//中日文
    public Image uiSprite;  //对话图片
    public Text uiLabel;    //对话内容
    public int Index = -1;     //对话节点
    private int Stage = 0; //对话阶段
    public delegate void dialog(int _Stage);
    public event dialog DialogEnd; //结束标识
    public event dialog DialogStart;//开始标识
    public bool BPause = true;//是否暂停
    private bool _BContinue = true; 
    private bool BContinue
    {
        get { return _BContinue; }
        set
        {
            if (value == true)
            {
                Stage++;
                if (DialogStart != null)
                DialogStart(Stage);
            }
            else
            {
                if(DialogEnd!=null)
                DialogEnd(Stage);
            }
            _BContinue = value;
        }
    }

    void Start()
    {
        foreach (DialogXMLLoadAndSave.DialogNode dialog in DialogXMLLoadAndSave.LoadDialogXmlFile())
        {
            if (Globals.GuankaId.ToString().Equals(dialog.guankaid)) //判断关卡ID 是否等于当前对话ID
            {
                DialogInfor.Add(dialog);
               
            }
        }
        if (DialogInfor.Count > 0)
            NextLine();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            CheckLine();
            NextLine();

            if (!BContinue)
                gameObject.SetActive(false);

        }
    }

    void OnEnable()
    {
        if (BPause)
        {
             Globals.Paused = true;
        }
        if (Index > DialogInfor.Count - 1)
        {
           // Destroy(gameObject);
        }
        else if (!BContinue)
            BContinue = true;
    }

    void OnDisable()
    {
        if (BPause)
        {
            Globals.Paused = false;
        }
    }

    /// <summary>
    /// 读取下一条对话
    /// </summary>
    void NextLine()
    {
        Index++;
        if (Index > DialogInfor.Count - 1)
        {
            Destroy(gameObject);
            return;
        }
        string CharactId = (DialogInfor[Index].picid);
        Debug.Log(DialogInfor[Index].picid);
        Debug.Log(Resources.Load<Sprite>(CharactId.ToString()).name);
        uiSprite.sprite = Resources.Load<Sprite>(CharactId.ToString());
        uiLabel.text = DialogInfor[Index].dialog;

    }

    /// <summary>
    /// 检查对话是否结束
    /// </summary>
    void CheckLine()
    {
        if (DialogInfor[Index].next == "0")
        {
            BContinue = false;
        }
    }

    /// <summary>
    /// 是否重复
    /// </summary>
    /// <param name="count"></param>
    public void Repeat(int count)
    {
        Index = Mathf.Clamp(Index - count, 0, Index);
        NextLine();
        gameObject.SetActive(true);
    }
}
