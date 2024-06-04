using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Lesson1Test {
    public int testPublic = 10;
    //    private int testPrivate = 11;
    protected int testProtected = 12;
    internal int testInternal = 13;
    public string testPublicStr = "123";
    public int testPro {
        get; set;
    }
    public Lesson1Test2 testClass = new Lesson1Test2();

    public int[] array = new int[3] { 5, 6, 7 };
    public List<int> list = new List<int> { 1, 2, 3, 4, 5 };
    public List<Lesson1Test2> listItem = new List<Lesson1Test2> { new Lesson1Test2(), new Lesson1Test2() };
}
public class Lesson1Test2 {
    public int test1 = 1;
    public float test2 = 1.1f;
    public bool test3 = true;
}
public class Lesson1 : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        Lesson1Test lt = new Lesson1Test();

        string path = Application.persistentDataPath + "/Lesson1Test.xml";

        using (StreamWriter sw = new StreamWriter(path)) {
            XmlSerializer s = new XmlSerializer(typeof(Lesson1Test));
            s.Serialize(sw, lt);
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
