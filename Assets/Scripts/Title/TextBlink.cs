using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour
{
    Text image;
    Color color;

    void Start()
    {
        image = GetComponent<Text>();
        color = image.color;
    }
    private void Update()
    {
        image.color = new Color(color.a, color.g, color.b, 0.3f+Mathf.PingPong(Time.time, 0.7f));
    }

}
