using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceBGM;
    [SerializeField] AudioSource audioSourceSE;
    [SerializeField] AudioClip[] bgmList;
    [SerializeField] AudioClip[] seList;
    [SerializeField] Image speakerImage = default;
    [SerializeField] Sprite[] speakers = default;
    public enum SE
    {
        Correct,
        Wrong,
        Finish,
        Button,
        Pi,
        Pii,
    }

    public enum BGM
    {
        Title,
        Main

    }

    public static SoundManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(BGM bgm)
    {
        int index = (int)bgm;
        audioSourceBGM.clip = bgmList[index];
        audioSourceBGM.Play();
    }

    public void PlaySE(SE se)
    {
        int index = (int)se;
        audioSourceSE.PlayOneShot(seList[index]);
    }

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    bool mute = false;
    public void SpeakerMute()
    {
        mute = !mute;
        if (mute)
        {
            speakerImage.sprite = speakers[1];
            AudioListener.volume = 0;
        }
        else
        {
            speakerImage.sprite = speakers[0];
            AudioListener.volume = 1;
        }
    }
}
