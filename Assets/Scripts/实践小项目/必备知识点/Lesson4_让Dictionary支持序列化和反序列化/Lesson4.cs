using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class TestLesson4 {
    public int test1;
    public SerializerDictionary<int, string> dic;
}
public class Lesson4 : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        TestLesson4 testLesson4 = new TestLesson4();
        testLesson4.dic = new SerializerDictionary<int, string>();
        testLesson4.dic.Add(1, "123");
        testLesson4.dic.Add(2, "234");
        testLesson4.dic.Add(3, "345");
        string path = Application.persistentDataPath + "/TestLesson4.xml";
        using (StreamWriter writer = new StreamWriter(path)) {
            XmlSerializer s = new XmlSerializer(typeof(TestLesson4));
            s.Serialize(writer, testLesson4);
        }
        using (StreamReader reader = new StreamReader(path)) {
            XmlSerializer s = new XmlSerializer(typeof(TestLesson4));
            testLesson4 = s.Deserialize(reader) as TestLesson4;
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
