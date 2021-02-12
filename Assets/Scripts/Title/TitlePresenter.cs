using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitlePresenter : MonoBehaviour
{
    [SerializeField] GameObject[] imageObjs = default;
    [SerializeField] GameObject[] InversImageObjs = default;
    [SerializeField] string nextScene = default;
    public void Start()
    {
        PlayAnim();
        SoundManager.instance.PlayBGM(SoundManager.BGM.Title);
    }

    public void OnNewGameButton()
    {
        SoundManager.instance.PlaySE(SoundManager.SE.Button);
        SceneManager.LoadScene(nextScene);
    }

    public void PlayAnim()
    {
        StartCoroutine(RotateAnim());
    }

    IEnumerator RotateAnim()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            foreach (GameObject image in imageObjs)
            {
                image.transform.localScale = new Vector3(-1, 1, 1);
            }
            foreach (GameObject image in InversImageObjs)
            {
                image.transform.localScale = new Vector3(-1, 1, 1);
            }
            yield return new WaitForSeconds(1f);
            foreach (GameObject image in imageObjs)
            {
                image.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
