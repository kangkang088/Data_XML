using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class Item {
    public int id;
    public int num;
}
public class PlayerInfo {
    public string name;
    public int atk;
    public int def;
    public float moveSpeed;
    public float roundSpeed;
    public Item weapon;
    public List<int> listInt;
    public List<Item> itemList;
    public Dictionary<int, Item> itemDic;
    public void LoadData(string fileName) {
        string path = Application.persistentDataPath + "/" + fileName + ".xml";
        if (!File.Exists(path)) {
            path = Application.streamingAssetsPath + "/" + fileName + ".xml";
        }
        XmlDocument xml = new XmlDocument();
        xml.Load(Application.streamingAssetsPath + "/" + fileName + ".xml");
        XmlNode playerInfo = xml.SelectSingleNode("PlayerInfo");
        this.name = playerInfo.SelectSingleNode("name").InnerText;
        this.atk = int.Parse(playerInfo.SelectSingleNode("atk").InnerText);
        this.def = int.Parse(playerInfo.SelectSingleNode("def").InnerText);
        this.moveSpeed = float.Parse(playerInfo.SelectSingleNode("moveSpeed").InnerText);
        this.roundSpeed = float.Parse(playerInfo.SelectSingleNode("roundSpeed").InnerText);
        this.weapon = new Item();
        XmlNode weapon = playerInfo.SelectSingleNode("weapon");
        this.weapon.id = int.Parse(weapon.SelectSingleNode("id").InnerText);
        this.weapon.num = int.Parse(weapon.SelectSingleNode("num").InnerText);
        XmlNode listInt = playerInfo.SelectSingleNode("listInt");
        XmlNodeList intList = listInt.SelectNodes("int");
        this.listInt = new List<int>();
        foreach (XmlNode item in intList) {
            this.listInt.Add(int.Parse(item.InnerText));
        }
        XmlNode itemList = playerInfo.SelectSingleNode("itemList");
        XmlNodeList items = itemList.SelectNodes("Item");
        this.itemList = new List<Item>();
        foreach (XmlNode item in items) {
            Item item2 = new Item();
            item2.id = int.Parse(item.Attributes["id"].Value);
            item2.num = int.Parse(item.Attributes["num"].Value);
            this.itemList.Add(item2);
        }
        XmlNode itemDic = playerInfo.SelectSingleNode("itemDic");
        XmlNodeList keyInt = itemDic.SelectNodes("int");
        XmlNodeList valueItem = itemDic.SelectNodes("Item");
        this.itemDic = new Dictionary<int, Item>();
        for (int i = 0; i < keyInt.Count; i++) {
            int key = int.Parse(keyInt[i].InnerText);
            Item value = new Item();
            value.id = int.Parse(valueItem[i].Attributes["id"].Value);
            value.num = int.Parse(valueItem[i].Attributes["num"].Value);
            this.itemDic.Add(key, value);
        }
    }
    public void SaveData(string fileName) {
        string path = Application.persistentDataPath + "/" + fileName + ".xml";
        //five steps
        //1.create xmlObject
        XmlDocument xml = new XmlDocument();
        //2.add version and encoding
        XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
        xml.AppendChild(xmlDeclaration);
        //3.add rootElement
        XmlElement playeInfo = xml.CreateElement("PlayerInfo");
        xml.AppendChild(playeInfo);
        //4.add childElements
        XmlElement name = xml.CreateElement("name");
        name.InnerText = this.name;
        playeInfo.AppendChild(name);

        XmlElement atk = xml.CreateElement("atk");
        atk.InnerText = this.atk.ToString();
        playeInfo.AppendChild(atk);

        XmlElement def = xml.CreateElement("def");
        def.InnerText = this.def.ToString();
        playeInfo.AppendChild(def);

        XmlElement moveSpeed = xml.CreateElement("moveSpeed");
        moveSpeed.InnerText = this.moveSpeed.ToString();
        playeInfo.AppendChild(moveSpeed);

        XmlElement roundSpeed = xml.CreateElement("roundSpeed");
        roundSpeed.InnerText = this.roundSpeed.ToString();
        playeInfo.AppendChild(roundSpeed);

        XmlElement weapon = xml.CreateElement("weapon");
        XmlElement id = xml.CreateElement("id");
        id.InnerText = this.weapon.id.ToString();
        weapon.AppendChild(id);
        XmlElement num = xml.CreateElement("num");
        num.InnerText = this.weapon.num.ToString();
        weapon.AppendChild(num);
        playeInfo.AppendChild(weapon);

        XmlElement listInt = xml.CreateElement("listInt");
        for (int i = 0; i < this.listInt.Count; i++) {
            XmlElement intNode = xml.CreateElement("int");
            intNode.InnerText = this.listInt[i].ToString();
            listInt.AppendChild(intNode);
        }
        playeInfo.AppendChild(listInt);

        XmlElement itemList = xml.CreateElement("itemList");
        for (int i = 0; i < this.itemList.Count; i++) {
            XmlElement itemNode = xml.CreateElement("Item");
            itemNode.SetAttribute("id", this.itemList[i].id.ToString());
            itemNode.SetAttribute("num", this.itemList[i].num.ToString());
            itemList.AppendChild(itemNode);
        }
        playeInfo.AppendChild(itemList);

        XmlElement itemDic = xml.CreateElement("itemDic");
        foreach (int key in this.itemDic.Keys) {
            XmlElement intNode = xml.CreateElement("int");
            intNode.InnerText = key.ToString();
            itemDic.AppendChild(intNode);
            XmlElement itemNode = xml.CreateElement("Item");
            itemNode.SetAttribute("id", this.itemDic[key].id.ToString());
            itemNode.SetAttribute("num", this.itemDic[key].num.ToString());
            itemDic.AppendChild(itemNode);
        }
        playeInfo.AppendChild(itemDic);
        //5.save
        xml.Save(path);
    }
}
