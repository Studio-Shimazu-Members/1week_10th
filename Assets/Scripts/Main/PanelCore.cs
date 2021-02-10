using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCore : MonoBehaviour
{
    Image image;


    Panel panelData;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetPanel(Panel panel)
    {
        panelData = panel;
        image.sprite = panel.sprite;
    }
}