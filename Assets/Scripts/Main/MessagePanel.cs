using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : MonoBehaviour
{

    [SerializeField] Text messageText = default;

    private void Update()
    {
        
    }


    public void UpdateMessage(string message)
    {
        messageText.text = message;

    }
}
