using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class SaveXML : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        string path = Application.persistentDataPath + "/PlayerInfo2.xml";
        print(Application.persistentDataPath);
        XmlDocument xml = new XmlDocument();

        XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
        xml.AppendChild(xmlDeclaration);

        XmlElement root = xml.CreateElement("Root");
        xml.AppendChild(root);

        XmlElement name = xml.CreateElement("name");
        name.InnerText = "kangkang";
        root.AppendChild(name);
        XmlElement atk = xml.CreateElement("atk");
        atk.InnerText = "10";
        root.AppendChild(atk);

        XmlElement listInt = xml.CreateElement("listInt");
        for (int i = 0; i < 3; i++) {
            XmlElement childNode = xml.CreateElement("int");
            childNode.InnerText = (i + 1).ToString();
            listInt.AppendChild(childNode);
        }
        root.AppendChild(listInt);

        XmlElement itemList = xml.CreateElement("itemList");
        for (int i = 0; i < 3; i++) {
            XmlElement childNode = xml.CreateElement("Item");
            childNode.SetAttribute("id", (i + 1).ToString());
            childNode.SetAttribute("num", (i * 1).ToString());
            itemList.AppendChild(childNode);
        }
        root.AppendChild(itemList);

        xml.Save(path);
    }

    // Update is called once per frame
    void Update() {

    }
}
