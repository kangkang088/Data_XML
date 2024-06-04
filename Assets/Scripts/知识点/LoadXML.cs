using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class LoadXML : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        XmlDocument xml = new XmlDocument();
        TextAsset asset = Resources.Load<TextAsset>("testXML");
        xml.LoadXml(asset.text);
        xml.Load(Application.streamingAssetsPath + "/testXML");
        XmlNode root = xml.SelectSingleNode("Root");
        XmlNode nodeName = root.SelectSingleNode("name");
        print(nodeName.InnerText);
    }

    // Update is called once per frame
    void Update() {

    }
}
