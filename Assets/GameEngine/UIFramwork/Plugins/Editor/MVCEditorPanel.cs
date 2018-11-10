
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Text;

/// <summary>
/// 可视化编辑面板生成代码工具
/// </summary>
public class MVCEditorPanel : EditorWindow
{

    public GameObject root = null;

    public GameObject gos=null;

    Vector2 pos;

    List<GameObject> AddList = new List<GameObject>(); //按钮集合

    List<GameObject> ChildList = new List<GameObject>();

    int SuitBtn = 0;

    int SuitText = 0;

    int SuitImage = 0;
    public bool Once=true;

    [MenuItem("MVCTools/OutOutModel")]
    static void Open()
    {
        GetWindow<MVCEditorPanel>();
    }


    void OnGUI()
    {

        var options = new[] { GUILayout.Width(100), GUILayout.Height(20) };

        GUILayout.Label("EditorPanel可视化编辑器");
        EditorGUILayout.Space();
        EditorGUILayout.BeginVertical();

        GUI.skin.label.fontSize = 15;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUILayout.Label("以下操作只可执行一次，失误请从新打开面板 防止代码写入重复");
       
        GUILayout.Label("按钮请包含--> Btn <--字符");
        GUILayout.Space(5);
        GUILayout.Label("符合的按钮数量为" + SuitBtn.ToString());

        GUILayout.Label("文本请包含--> Lab <--字符");
        GUILayout.Space(5);
        GUILayout.Label("符合的文本数量为" + SuitText.ToString());
        GUILayout.Space(5);
        GUILayout.Label("图片请包含--> Sprite <--字符");
        GUILayout.Space(5);
        GUILayout.Label("符合的图片数量为" + SuitImage.ToString());

        root = EditorGUILayout.ObjectField("--> 根物体 <--", root, typeof(GameObject), true) as GameObject;
         GUILayout.Space(10);
       

        pos = EditorGUILayout.BeginScrollView(pos, GUILayout.Width(400), GUILayout.Height(200));


       
            for (int i = 0; i < ChildList.Count; i++)
            {
                GameObject[] show = new GameObject[ChildList.Count];
                show[i] = EditorGUILayout.ObjectField(ChildList[i].name, ChildList[i], typeof(GameObject), true) as GameObject;
            }


           
      

        EditorGUILayout.EndScrollView();

        GUILayout.Space(10);
      

        if (GUILayout.Button("--> 获取模板所需组件 <--"))
        {
            Debug.Log("<Color=red>" + "递归查询中..." + "</Color>");
            FindChild(root.transform);

            Class += "public class " + root.name + " : PanelBase {" + "\n";
            InitPath += "   skinPath =\""+ root.name +"\";} \n";
            Debug.Log("<Color=yellow>" + "查询结束..." + "</Color>");
           
        }


        EditorGUILayout.EndVertical();

        GUILayout.Space(10);

        if (GUILayout.Button("--> 创建模板并写入 <--"))
        {
               Create();
           
        }
    }

    public string Tittle = "//脚本为模板自动生成。 生成时间为：" + System.DateTime.Now.ToString() + "\n" + "\n" + "\n" + "\n";
    public string Head = "using UnityEngine;" + "\n" + "using UnityEngine.UI;" + "\n" + "using System.Collections;" + "\n" + "using EasyMVC;" + "\n" + "\n" + "\n" + "\n";
    public string Class = "";
    public string GetCom = "";
    public string Init = "  public override void Init(params object[] args) {" + "\n" + "   base.Init(args);" + "layer = PanelLayer.Panel;" + "\n";
    public string InitPath = "";
    public string OnShowing = "   public override void OnShowing() {" + "\n" + "   base.OnShowing();" + "\n" + "   Transform skinTrans = skin.transform;" + "\n";
    public string GetPath = "";
    public string AdListen = "";
    public string EndShow = "  }" + "\n";
    public string Click = "";
    public string EndAll = "}";


    void GetComs()
    {
        for (int i = 0; i < ChildList.Count; i++)
        {
            string pathStr = string.Empty;
            if (ChildList[i].name.Contains("Lab"))
            {
                //GetComPath(ChildList[i].transform, ref pathStr);
                GetCom += "     public Text " + ChildList[i].name + ";\n" + "\n";
                //GetPath += ChildList[i].name + "=skinTrans.FindChild(\""+pathStr+"\").GetComponent<Text>();" + "\n" + "\n";
                 GetPath +="    "+ ChildList[i].name + "=GetScripts<Text>(\"" + ChildList[i].name + "\");" + "\n" + "\n";
            }
            if (ChildList[i].name.Contains("Btn"))
            {
              //  GetComPath(ChildList[i].transform, ref pathStr);
              //  GetCom += " public Button " + ChildList[i].name + ";\n";
                AdListen += "    RigistButtonEvent(\"" + ChildList[i].name + "\"" + ",On" + ChildList[i].name + "Click);" + "\n" + "\n";
              //  GetPath += ChildList[i].name + "=skinTrans.FindChild(\"" + pathStr + "\").GetComponent<Button>();" + "\n" + "\n";
             //   AdListen += ChildList[i].name + ".onClick.AddListener(" + "On" + ChildList[i].name + "Click);" + "\n";
                Click += "   public void  On" + ChildList[i].name + "Click(){ }" + "\n" + "\n";
            }

            if (ChildList[i].name.Contains("Sprite"))
            {
               // GetComPath(ChildList[i].transform, ref pathStr);
                GetCom += "     public Image " + ChildList[i].name + ";\n";
               // GetPath += ChildList[i].name + "=skinTrans.FindChild(\"" + pathStr + "\").GetComponent<Image>();" + "\n" + "\n";
                GetPath +="    "+ ChildList[i].name + "=GetScripts<Image>(\"" + ChildList[i].name + "\");" + "\n" + "\n";
            }


        }
    }

    /// <summary>
    /// 获取路径
    /// </summary>
    /// <param name="tr"></param>
    /// <param name="str"></param>
    /// <returns></returns>
    static string GetComPath(Transform tr, ref string str)
    {

        if (tr != null && tr.name != "Canvas" && tr.parent.name != "Canvas")
        {
            str = tr.name + str;
            tr = tr.parent;
            if (tr != null && tr.name != "Canvas" && tr.parent.name != "Canvas")
            {
                str = "/" + str;
            }
            GetComPath(tr, ref str);
        }
        else
        {
            return str;
        }
        return str;
    }



    /// <summary>
    /// 创建文本
    /// </summary>
    void  Create()
    {
        GetComs();
        Debug.Log("<Color=red>" +"文本正在创建中..."+ "</Color>");

        string path = Application.dataPath + "//"+root.name+".txt";
       
        DirectoryInfo myDirectoryInfo = new DirectoryInfo(path);
        if (myDirectoryInfo.Exists)       // 文件存在则直接写入。不能存在则创建一个
        {

            Debug.Log("this file already exists!");

            addFile(path, "this file content");
        }
        
        else 
        {
            //创建文件
            File.Create(path).Close();

            addFile(path,Tittle+ Head + Class + GetCom + Init + InitPath + OnShowing + GetPath + AdListen + EndShow + Click + EndAll);
           
        
            
            
        }
        Debug.Log("<Color=yellow>" + "文本创建结束..." + "</Color>");
    }

    /// <summary>
    /// 文件写入
    /// </summary>
    /// <param name="path"></param>
    /// <param name="fileName"></param>
    void addFile(string path, string fileName)
    {

        Debug.Log("<Color=red>" + "代码写入中..." + "</Color>");
        File.AppendAllText(path, fileName);
        Debug.Log("<Color=yellow>" + "代码写入完毕..." + "</Color>");
       

        Debug.Log("<Color=red>" + "格式修改中..." + "</Color>");
        //修改文件后缀
        fileName = path;
        string dfileName = System.IO.Path.ChangeExtension(fileName, ".cs");
        File.Move(fileName, dfileName);
        
        Debug.Log("<Color=yellow>" + "格式修改结束..." + "</Color>");

        //刷新面板
        Debug.Log("<Color=yellow>" + "刷新面板完毕..." + "</Color>");
        AssetDatabase.Refresh();
    }



    /// <summary>
    /// 递归查询子物体
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public void FindChild(Transform t)
    {
        Transform[] trans = new Transform[t.childCount];

        if (t.childCount > 0)
        {
            for (int i = 0; i < t.childCount; i++)
            {
               
                trans[i] = t.GetChild(i);
                if (!ChildList.Contains(trans[i].gameObject))
                {
                    if (trans[i].name.Contains("Btn"))
                    {
                        ChildList.Add(trans[i].gameObject);
                        SuitBtn++;
                    }

                    if ( trans[i].name.Contains("Lab"))
                    {
                        ChildList.Add(trans[i].gameObject);
                        SuitText++;
                    }

                    if (trans[i].name.Contains("Sprite"))
                    {
                        ChildList.Add(trans[i].gameObject);
                        SuitImage++;
                    }
                }
                FindChild(trans[i]);
            }

            
        }
       
        
            
    }
}


public class CreatRootPanel : EditorWindow
{
    public static string RootName;

    [MenuItem("MVCTools/CreatRoots")]
    static void Open()
    {
        GetWindow<CreatRootPanel>();
    }


   


    void OnGUI()
    {

        RootName = EditorGUILayout.TextField("输入脚本名称<StartRoot>:", RootName);

        if (GUILayout.Button("Create C#"))
        {
            if (string.IsNullOrEmpty(RootName))
                return;
            Class += "public class " + RootName + " :MonoBehaviour {" + "\n";
            Create();
        }
    }

    public string Tittle = "//脚本为模板自动生成。 生成时间为：" + System.DateTime.Now.ToString() + "\n" + "\n";
    public string Head = "using UnityEngine;" + "\n" + "using UnityEngine.UI;" + "\n" + "using System.Collections;" + "\n" + "using EasyMVC;" + "\n" + "\n" + "\n" + "\n";
    public string Class = "";
    public string Init = "  public  void Awake() {" + "\n" +"//PanelMgr.instance.OpenPanel<>(\",\")"+ "\n";
    public string EndShow = "  }" + "\n";
    public string EndAll = "}";

    /// <summary>
    /// 创建文本
    /// </summary>
    void Create()
    {
       
        Debug.Log("<Color=red>" + "文本正在创建中..." + "</Color>");

        string path = Application.dataPath + "//" + RootName + ".txt";

        DirectoryInfo myDirectoryInfo = new DirectoryInfo(path);
        if (myDirectoryInfo.Exists)       // 文件存在则直接写入。不能存在则创建一个
        {

            Debug.Log("this file already exists!");

            addFile(path, "this file content");
        }

        else
        {
            //创建文件
            File.Create(path).Close();

            addFile(path, Tittle + Head + Class  + Init  + EndShow  + EndAll);




        }
        Debug.Log("<Color=yellow>" + "文本创建结束..." + "</Color>");
    }

    /// <summary>
    /// 文件写入
    /// </summary>
    /// <param name="path"></param>
    /// <param name="fileName"></param>
    void addFile(string path, string fileName)
    {

        Debug.Log("<Color=red>" + "代码写入中..." + "</Color>");
        File.AppendAllText(path, fileName);
        Debug.Log("<Color=yellow>" + "代码写入完毕..." + "</Color>");


        Debug.Log("<Color=red>" + "格式修改中..." + "</Color>");
        //修改文件后缀
        fileName = path;
        string dfileName = System.IO.Path.ChangeExtension(fileName, ".cs");
        File.Move(fileName, dfileName);

        Debug.Log("<Color=yellow>" + "格式修改结束..." + "</Color>");

        //刷新面板
        Debug.Log("<Color=yellow>" + "刷新面板完毕..." + "</Color>");
        AssetDatabase.Refresh();
    }
}
