using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 物品数据
/// </summary>
public class ItemDatebase : MonoBehaviour
{
    public List<item> items = new List<item>();

    void Start()
    {
        items.Add(new item("redPotion01", 0, "血药", "增加100生命值", 99, item.ItemType.Potion, 1000));
        items.Add(new item("bluePotion01", 1, "蓝药", "增加100魔法值", 99, item.ItemType.Potion, 1000));
        items.Add(new item("boot01", 2, "鞋子", "增加50移动速度", 1, item.ItemType.Shoes, 1000));
        items.Add(new item("cloth01", 3, "衣服", "增加50防御力", 1, item.ItemType.Clothing, 1000));
        items.Add(new item("hat01", 4, "头盔", "增加50力量", 1, item.ItemType.Casque, 1000));
        items.Add(new item("trousers01", 5, "裤子", "增加50敏捷", 1, item.ItemType.Trousers, 1000));
        items.Add(new item("weapon01", 6, "副武器", "增加100攻击力", 1, item.ItemType.OffHandWeapon, 1000));
        items.Add(new item("boot02", 7, "鞋子2", "增加100移动速度", 1, item.ItemType.Shoes, 1000));
        items.Add(new item("weapon02", 8, "主武器", "增加200攻击力", 1, item.ItemType.MainHandWeapon, 2000));
        items.Add(new item("Necklace", 9, "项链", "增加100魔法", 1, item.ItemType.Necklace, 1000));
        items.Add(new item("Erring", 10, "耳环", "增加100魔法", 1, item.ItemType.Erring, 1000));
        items.Add(new item("Ring", 11, "戒指", "增加100力量", 1, item.ItemType.Ring, 1000));
        items.Add(new item("Wrister", 12, "护手", "增加200力量", 1, item.ItemType.Wrister, 1000));
    }
}
