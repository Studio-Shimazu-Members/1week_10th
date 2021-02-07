using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float countTime = 60;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        countTime -= Time.deltaTime; //スタートしてからの秒数を格納
        GetComponent<Text>().text = "制限時間　残り"+countTime.ToString("F2")+"秒"; //小数2桁にして表示
    }
}
