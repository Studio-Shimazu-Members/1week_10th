using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ReadyUI : MonoBehaviour
{
    [SerializeField] Text countText = default;
    public UnityAction StartAction = default;
    private void Start()
    {
        CountStart();
    }

    public void CountStart()
    {
        SoundManager.instance.StopBGM();
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        for (int i = 3; i > 0; i--)
        {
            countText.text = i.ToString();
            SoundManager.instance.PlaySE(SoundManager.SE.Pi);
            yield return new WaitForSeconds(1);
        }
        SoundManager.instance.PlaySE(SoundManager.SE.Pii);
        countText.text = "すたーと！";
        yield return new WaitForSeconds(1);
        StartAction.Invoke();
        gameObject.SetActive(false);
    }
}
