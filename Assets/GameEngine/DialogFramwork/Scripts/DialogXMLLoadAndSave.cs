using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class DialogXMLLoadAndSave : MonoBehaviour {

    public static string dialogpath = Application.dataPath + @"/StreamingAssets/dialog.xml";

    public static List<DialogNode> dialognodes = new List<DialogNode>();

    /// <summary>
    /// //对话结构
    /// </summary>
    public struct DialogNode
    {
        public DialogNode(string dialog, string guankaid, string picid, string next)
            : this()
        {
            this.dialog = dialog;
            this.next = next;
            this.guankaid = guankaid;
            this.picid = picid;
        }

        public string guankaid { get; set; }
        public string picid { get; set; }
        public string next { get; set; }
        public string dialog { get; set; }
    }


    public static DialogNode diag = new DialogNode();

    /// <summary>
    /// 读取加载XML
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static XmlDocument ReadAndLoadXml(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);

        return doc;
    }

    /// <summary>
    /// 加载对话系统文件
    /// </summary>
    /// <returns></returns>
    public static List<DialogNode> LoadDialogXmlFile()
    {
        dialognodes.Clear();

        if (File.Exists(dialogpath))
        {
            XmlDocument xmlDoc = ReadAndLoadXml(dialogpath);
            xmlDoc.Load(dialogpath);

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("GuanKa").ChildNodes;

            foreach (XmlElement scene in nodeList)
            {
                string scenename = scene.GetAttribute("name");

                foreach (XmlElement guan in scene.ChildNodes)
                {
                    string guanid = guan.GetAttribute("bianhao");

                    foreach (XmlElement duihua in guan.ChildNodes)
                    {
                        string wanjia = duihua.Attributes["dialog"].Value;
                        string id = duihua.Attributes["id"].Value;
                        string next = duihua.Attributes["next"].Value;

                        diag.guankaid = guanid;
                        diag.picid = id;
                        diag.dialog = wanjia;
                        diag.next = next;
                        dialognodes.Add(diag);
                    }
                }
            }
        }
        return dialognodes;
    }
}
