using UnityEngine;
using System.Collections;
using System.Collections.Generic;


    /// <summary>
    /// 消息传递中心
    /// 负责UI框架中所有UI窗体之间的数据传值
    /// </summary>
    public class MessageCenter
    {
        //定义一个委托：消息传递
        public delegate void DelMessageDelivery(KeyValueUpdate kvU);

        /// <summary>
        /// 消息中心缓存集合
        /// string:所要监听的类型（数据大的分类）
        /// DelMessageDelivery  数据执行委托
        /// </summary>
        public static Dictionary<string, DelMessageDelivery> _dicMessages = new Dictionary<string, DelMessageDelivery>();


        /// <summary>
        /// 添加消息的监听
        /// </summary>
        /// <param name="messageType">消息分类</param>
        /// <param name="handler">消息的委托</param>
        public static void AddMsgListener(string messageType, DelMessageDelivery handler)
        {
            if (!_dicMessages.ContainsKey(messageType))
            {
                _dicMessages.Add(messageType, null);
            }
            _dicMessages[messageType] += handler;
        }

        /// <summary>
        /// 移除消息监听
        /// </summary>
        /// <param name="messageType">消息分类</param>
        /// <param name="handler">消息的委托</param>
        public static void RemoveMsgListener(string messageType, DelMessageDelivery handler)
        {
            if (_dicMessages.ContainsKey(messageType))
            {

                _dicMessages[messageType] -= handler;
            }
        }


        /// <summary>
        /// 取消所有指定消息的监听
        /// </summary>
        public static void ClearAllMsgKistener()
        {
            if (_dicMessages != null)
            {
                _dicMessages.Clear();
            }
        }


        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="messageType">消息的分类</param>
        /// <param name="kvU">键值对对象</param>
        public static void SendMessage(string messageType, KeyValueUpdate kvU)
        {
            DelMessageDelivery del;  //委托
            if (_dicMessages.TryGetValue(messageType, out del))
            {
                if (del != null)
                {
                    del(kvU);
                }
            }
        }

    }


    /// <summary>
    /// 键值更新对
    /// 功能：配合委托实现委托数据传递
    /// </summary>
    public class KeyValueUpdate
    {
        private string _Keys;

        public string Keys
        {
            get { return _Keys; }
        }

        private object _Values;

        public object Values
        {
            get { return _Values; }
        }

        public KeyValueUpdate(string Key, object ValueObj)
        {
            _Keys = Key;
            _Values = ValueObj;
        }
    }

