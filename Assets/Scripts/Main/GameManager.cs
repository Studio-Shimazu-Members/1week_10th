using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // staticを使う:どこからでも使えるもの
   
    

    
    // Start is called before the first frame update
    void Start()
    {
        

  
    }


    
   

   

    public void LoadScene()
    {
        SoundManager.instance.PlaySE(SoundManager.SE.Button);
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }

   

}
