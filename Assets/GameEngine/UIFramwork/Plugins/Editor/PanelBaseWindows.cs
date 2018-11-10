using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// PanelBase API 参数界面
/// </summary>
public class PanelBaseWindows : EditorWindow
{

    public static PanelBaseWindows _instance;

    private string Tittle = "概述";
    private string Intruduce = "介绍";
    private string Use = "使用方法";

    Vector2 _scrollPos;
    public static void ShowAPIWindwos()
    {
        _instance = EditorWindow.GetWindow<PanelBaseWindows>();
        _instance.titleContent = new GUIContent("PanelBase API");
    }

    void OnGUI()
    {
        _scrollPos = GUILayout.BeginScrollView(_scrollPos);

        GUILayout.Label("字段", EasyMVC_API.SetGUIStyle(Color.black, GUI.skin.label));
        GUILayout.BeginVertical("Box");

        if (GUILayout.Button("skinPath", EasyMVC_API.SetGUIStyle(Color.yellow, GUI.skin.button)))
        {
            Tittle = "皮肤的路径";
            Intruduce = "皮肤的路径，主要用于设置皮肤加载路径，可以为空";
            Use = "封装函数中实现为 ：Resource.Load(skinPath+皮肤名称) \n   因此可以理解为 skinPath 影响Panel 界面预制体的位置 \n 如果skinPath为 Panel \n 那么预制体界面需要放置在Resources文件夹目录下的Panel文件夹中\n才能被读取到";

            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("skin", EasyMVC_API.SetGUIStyle(Color.yellow, GUI.skin.button)))
        {
            Tittle = "皮肤的名称";
            Intruduce = "皮肤的名称，皮肤的名称,用于加载和读取皮肤预制体用的，也是一个键值";
            Use = "如果创建一个开始界面，创建一个StartPanel界面，那么skin就是这个StartPanel界面预制体的名称";

            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("layer", EasyMVC_API.SetGUIStyle(Color.yellow, GUI.skin.button)))
        {
            Tittle = "层级";
            Intruduce = "层级，用于区别显示层级的优先级，优先级高的界面会显示在最前面";
            Use = "layer 是一个枚举值，其功能暂时未完全实现。\n 或实现不是很完美，建议使用默认值\n layer=PanelLayer.Panel 表示为正常界面\n layer=PanelLayer.Tips 表示为提示界面，提示界面会覆盖在正常界面上方";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("args", EasyMVC_API.SetGUIStyle(Color.yellow, GUI.skin.button)))
        {
            Tittle = "界面参数";
            Intruduce = "界面与界面之间的参数传递 是一个Object[]的数据";
            Use = "args 代表的是object[] 因此传递数据时需要进行分割  \n例如传递参数 OpenPanel(打开面板名称，args(参数，字符串传递既可)) \n例如接收参数 在初始化的Init()方法中 args[0] 即代表这个字符串 ";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("HighLightBtn", EasyMVC_API.SetGUIStyle(Color.yellow, GUI.skin.button)))
        {
            Tittle = "高亮按钮";
            Intruduce = "按钮，为了电视机操控游戏而单独 开发的一个功能，用于获取焦点，\n并定位界面开始的焦点为哪一个，为可写参数";
            Use = "此参数无需赋值，\n在RigistBtnEvent()函数中 有一个参数为 isSelectOnStart 的布尔值类型，\n如果选择为True 则会自动将此值对应的按钮赋值给HighLightBtn \n特别注意的是如果多个按钮注册时都选择为True \n 则后面的会覆盖前面的 \n因为只允许有一个高亮";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        GUILayout.EndVertical();

        GUILayout.Space(20);
        GUILayout.Label("方法", EasyMVC_API.SetGUIStyle(Color.red, GUI.skin.label));
        GUILayout.BeginVertical("Box");

        if (GUILayout.Button("Init(params object[] args)", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "初始化界面函数";
            Intruduce = "初始化 界面的皮肤名称  界面的层级 ";
            Use = "  public override void Init(params object[] args) \n { \n  base.Init(args);layer = PanelLayer.Panel;\n  skinPath =\"TestPanel\"; \n }";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("OnShowing()", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "初始化界面显示函数";
            Intruduce = "初始化 界面的对应的UI等 包括 Image  Button Text 按钮的点击事件 委托的注册等 ";
            Use = " public override void OnShowing() {  \n   base.OnShowing();  \n  RigistButtonEvent(\"ButtonBtn\",OnButtonBtnClick); 等等  \n RigistButtonEvent 按钮注册将在后面详细介绍";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("OnShowed()", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
              Tittle = "界面显示函数";
              Intruduce = "在 OnShowing() 函数之后执行， \n 处理界面全都加载完毕 赋值完毕后 需要执行的操作 \n （一般用不到）";
              Use = "略";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);

        }


        if (GUILayout.Button("OnClosing()", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "界面销毁函数";
            Intruduce = "在 销毁 命令发起后 执行， \n 销毁界面 ";
            Use = " 在销毁界面前想要执行什么操作，在这里实现既可";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("OnClosed()", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "界面销毁函数";
            Intruduce = "在 OnClosing()后 执行， \n 处理销毁界面之后的事情 ";
            Use = " 在销毁界面后想要执行什么操作，在这里实现既可";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("OpenPanel<T>", EasyMVC_API.SetGUIStyle(Color.green, GUI.skin.button)))
        {
            Tittle = "打开界面(2个重载)";
            Intruduce = "打开一个预制体界面（实现制作好的） ";
            Use = " 这里有2个重载 \n  重载1：  OpenPanel<界面名称>  \n 重载2：OpenPanel<界面名称>(\"\",\"\") \n  上述 两个“”第一个代表界面的路径可为空 \n 第二个为传递参数，也可为空" ;
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("OpenAndHideAllOthers<T>", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "打开一个界面并且关闭其它所有界面";
            Intruduce = "将要打开的界面为显示状态，其余所有已经实例化的界面都将被隐藏（不销毁） ";
            Use = "OpenAndHideAllOthers<要打开的界面名称>()";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("OpenAndHideSelf<T>()", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "打开一个界面并且关闭自身界面";
            Intruduce = "将要打开的界面为显示状态，其余自己的界隐藏（不销毁） ";
            Use = "OpenAndHideSelf<要打开的界面>()";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("OpenOneAndHideOne<T>", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "打开一个界面并且关闭一个指定的界面";
            Intruduce = "将要打开的界面为显示状态，关闭一个指定的界面（隐藏，不销毁） ";
            Use = "OpenOneAndHideOne<要打开的界面>(要关闭的界面名称) \n 要关闭的界面可以不写  不写则等同于--->OpenPanel<T>()";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("HidePanel()", EasyMVC_API.SetGUIStyle(Color.green, GUI.skin.button)))
        {
            Tittle = "隐藏一个界面(3个重载)";
            Intruduce = "隐藏一个界面无参数默认为隐藏自身界面 ";
            Use = "重载1：无参数 隐藏自身 HidePanel() \n 重载2：隐藏一个界面 HidePanel(要隐藏的界面名称 string类型) \n 重载3：隐藏一个界面 HidePanel(要隐藏的界面 T类型)";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("GetScripts<T>(string ChildName)", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "获取子物体脚本";
            Intruduce = "获取当前界面中任何子物体身上挂载的脚本 \n（常用于获取子物体的系统组件 例如获取Image组件 获取Button组件）";
            Use = "例1：GetScripts<Button>(\"StartBtn\")   \n  例2：GetScripts<我写的脚本>(\"XX物体上\")";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }


        if (GUILayout.Button("GetScripts<T>(string ChildName)", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "获取子物体脚本";
            Intruduce = "获取当前界面中任何子物体身上挂载的脚本 \n（常用于获取子物体的系统组件 例如获取Image组件 获取Button组件）";
            Use = "例1：GetScripts<Button>(\"StartBtn\")   \n  例2：GetScripts<我写的脚本>(\"XX物体上\")";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("GetPanelScripts<T>()", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "获取一个Panel界面的脚本";
            Intruduce = "主要用于界面与界面之间的交互，传值等等 代替了之前的单例模式。让代码更简洁";
            Use = "StartPanel startPanel=GetPanelScripts<StartPanel>();  则可获取 startPanel内部的公开参数";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }


        if (GUILayout.Button("GetPanelScripts<T>()", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "获取一个Panel界面的脚本";
            Intruduce = "主要用于界面与界面之间的交互，传值等等 代替了之前的单例模式。让代码更简洁";
            Use = "StartPanel startPanel=GetPanelScripts<StartPanel>();  则可获取 startPanel内部的公开参数";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("FindTheChildNode(GameObject,string)", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "获取子物体节点";
            Intruduce = "通过递归实现 对当前Panel 界面下存在的任何子物体的节点进行查找";
            Use = "FindTheChildNode(查询的父物体（指tihs的Panel）,要查询的节点名称)";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }


        if (GUILayout.Button("GetChildScripts<T>(GameObject, string)", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "获取子物体节点上的脚本或组件";
            Intruduce = "通过递归实现 对当前Panel 界面下存在的任何子物体的节点进行查找，\n 找到子物体后 对子物体身上的叫本进行查找";
            Use = "GetChildScripts<T>(GameObject goParent, string ChildName) \n  T指代需要查询的脚本或者组件 \n goParent 代指 要查询的父物体  \n ChildName 代指要查询的子物体";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }


        if (GUILayout.Button("RigistButtonEvent(buttonName，Action，isSelectOnStart)", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "对按钮进行注册(重载+4)";
            Intruduce = "对按钮进行注册 并添加方法传递 附带按钮高亮参数\n ";
            Use = "buttonName 按钮名称  Action 无参函数  isSelectOnStart 是否高亮状态  \n  RigistButtonEvent(\"StartBtn\"，OnStartClick，true)";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("RigistButtonEvent(buttonName,Action,string,isSelectOnStart)", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "对按钮进行注册(重载+4)";
            Intruduce = "对按钮进行注册 并添加方法传递 附带按钮高亮参数\n ";
            Use = "buttonName 按钮名称  Action 无参函数  string 有参函数的参数,\n 该参数为String类型, isSelectOnStart 是否高亮状态  \n  RigistButtonEvent(\"StartBtn\",OnStartClick,btnName,true)";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("RigistButtonEvent(buttonName,Action<T>,string,isSelectOnStart)", EasyMVC_API.SetGUIStyle(Color.blue, GUI.skin.button)))
        {
            Tittle = "对按钮进行注册(重载+4)";
            Intruduce = "该函数住要是为了 方便与 OpenPanel<T> 和 HidePanel<T> 配合使用 \n ";
            Use = "buttonName 按钮名称  Action<T> 无参有泛型函数,\n  isSelectOnStart 是否高亮状态  \n  RigistButtonEvent(\"StartBtn\",OpenPanel<StartPanel>,true)";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }

        if (GUILayout.Button("RigistButtonEvent(buttonName,handle,isSelectOnStart)", EasyMVC_API.SetGUIStyle(Color.red, GUI.skin.button)))
        {
            Tittle = "对按钮进行注册(重载+4)";
            Intruduce = "该函数为万能函数 使用委托进行传值操作等 \n ";
            Use = "buttonName 按钮名称  handle 委托,\n  isSelectOnStart 是否高亮状态  \n  RigistButtonEvent(\"StartBtn\",p=>{ \n OpenPanel<T>(); \n Debug.Log(\"可写入多个参数 跟函数一样\"); } \n ,true)";
            APIArgsShowWindows.ShowAPIWindwos(Tittle, Intruduce, Use);
        }
       

        GUILayout.EndVertical();
        GUILayout.EndScrollView();

    }

}
