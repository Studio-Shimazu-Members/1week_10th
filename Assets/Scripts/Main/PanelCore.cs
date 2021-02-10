using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PanelCore : MonoBehaviour
{
    Image image;

    Panel panelData;

    public UnityAction<Panel> ClickAction;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetPanel(Panel panel)
    {
        panelData = panel;
        image.sprite = panel.sprite;
    }

    public void OnClick()
    {
        ClickAction.Invoke(panelData);
    }
}