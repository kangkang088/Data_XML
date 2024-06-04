using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Lesson2 : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        string path = Application.persistentDataPath + "/Lesson1Test.xml";
        if (File.Exists(path)) {
            using (StreamReader sr = new StreamReader(path)) {
                XmlSerializer reader = new XmlSerializer(typeof(Lesson1Test));
                Lesson1Test lt = reader.Deserialize(sr) as Lesson1Test;
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
