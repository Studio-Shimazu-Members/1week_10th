using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : MonoBehaviour
{

    [SerializeField] Text messageText = default;

    


    public void UpdateMessage(string message)
    {
        messageText.text = message;

    }
}
