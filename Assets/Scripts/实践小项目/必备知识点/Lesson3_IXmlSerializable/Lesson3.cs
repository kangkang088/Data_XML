using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

public class TestLesson3 : IXmlSerializable {
    public int test1;
    public string test2 = "123";

    public XmlSchema GetSchema() {
        return null;
    }

    public void ReadXml(XmlReader reader) {
        //this.test1 = int.Parse(reader["test1"]);
        //this.test2 = reader["test2"];

        //reader.Read();
        //reader.Read();
        //this.test1 = int.Parse(reader.Value);
        //reader.Read();
        //reader.Read();
        //reader.Read();
        //this.test2 = reader.Value;

        //while (reader.Read()) {
        //    if (reader.NodeType == XmlNodeType.Element) {
        //        switch (reader.Name) {
        //            case "test1":
        //                reader.Read();
        //                this.test1 = int.Parse(reader.Value);
        //                break;
        //            case "test2":
        //                reader.Read();
        //                this.test2 = reader.Value;
        //                break;
        //        }
        //    }
        //}

        XmlSerializer s1 = new XmlSerializer(typeof(int));

        XmlSerializer s2 = new XmlSerializer(typeof(string));

        reader.Read();
        reader.ReadStartElement("test1");
        this.test1 = (int)s1.Deserialize(reader);
        reader.ReadEndElement();
        reader.ReadStartElement("test2");
        this.test2 = s2.Deserialize(reader).ToString();
        reader.ReadEndElement();

    }

    public void WriteXml(XmlWriter writer) {
        //writer.WriteAttributeString("test1", test1.ToString());
        //writer.WriteAttributeString("test2", test2.ToString());
        
        //writer.WriteElementString("test1", this.test1.ToString());
        //writer.WriteElementString("test2", this.test2.ToString());

        XmlSerializer s1 = new XmlSerializer(typeof(int));
        writer.WriteStartElement("test1");
        s1.Serialize(writer, test1);
        writer.WriteEndElement();
        
        XmlSerializer s2 = new XmlSerializer(typeof(string));
        writer.WriteStartElement("test2");
        s2.Serialize(writer, test2);
        writer.WriteEndElement();
    }
}
public class Lesson3 : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        TestLesson3 testLesson3 = new TestLesson3();
        testLesson3.test1 = 1;
        string path = Application.persistentDataPath + "/TestLesson3.xml";
        using (StreamWriter writer = new StreamWriter(path)) {
            XmlSerializer s = new XmlSerializer(typeof(TestLesson3));
            s.Serialize(writer, testLesson3);
        }

        using (StreamReader reader = new StreamReader(path)) {
            XmlSerializer s = new XmlSerializer(typeof(TestLesson3));
            TestLesson3 tl = s.Deserialize(reader) as TestLesson3;
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
