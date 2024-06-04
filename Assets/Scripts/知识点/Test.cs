using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo p = new PlayerInfo();
        p.LoadData("PlayerInfo");

        p.name = "修改后的内容";
        p.listInt.Add(99);
        Item i = new Item();
        i.id = 99;
        i.num = 10;
        p.itemList.Add(i);
        p.itemDic.Add(99, i);
        p.SaveData("PlayerInfo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
