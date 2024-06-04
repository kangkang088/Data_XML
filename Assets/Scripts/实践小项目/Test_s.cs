using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem99 {
    public int id = 1;
    public int num = 10;
}
public class TestClass99 {
    public int test1;
    public string test2;
    public TestItem99 item;
    public TestItem99[] array;
    public List<TestItem99> list;
    public SerializerDictionary<int, TestItem99> dic;
}
public class Test_s : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        TestClass99 t99 = XmlDataMgr.Instance.LoadData(typeof(TestClass99), "Test99") as TestClass99;
        //TestClass99 t99 = new TestClass99();
        //t99.test1 = 99;
        //t99.test2 = "kangkang";
        //t99.item = new TestItem99();
        //t99.array = new TestItem99[] { new TestItem99(), new TestItem99() };
        //t99.list = new List<TestItem99> { new TestItem99() };
        //t99.dic = new SerializerDictionary<int, TestItem99> { { 1, new TestItem99() }, { 2, new TestItem99() } };

        //XmlDataMgr.Instance.SaveData(t99, "Test99");
    }

    // Update is called once per frame
    void Update() {

    }
}
