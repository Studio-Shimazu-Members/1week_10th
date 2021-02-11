using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelCore : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image image;

    Panel panelData;
    [SerializeField] GameObject cursorImage = default;
    public bool isHide;
    public Panel PanelData
    {
        get => panelData;
    }

    public UnityAction<PanelCore> ClickAction;

    private void Awake()
    {
        image = GetComponent<Image>();
        cursorImage.SetActive(false);
    }

    public void SetPanel(Panel panel)
    {
        panelData = panel;
        image.sprite = panel.sprite;
    }

    public void OnClick()
    {
        if (isHide)
        {
            SoundManager.instance.PlaySE(SoundManager.SE.Wrong);
            return;
        }
        ClickAction.Invoke(this);
    }

    public void HidePanel(Sprite sprite)
    {
        isHide = true;
        image.sprite = sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isHide)
        {
            return;
        }
        cursorImage.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cursorImage.SetActive(false);
    }
}