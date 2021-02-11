using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    public ScoreManager scoreManager;
   
    public Text resultscoreText = default;

    private void Awake()
    {
     //   resultscoreText  = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
      //  ResultsScore();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResultsScore()
    {
        resultscoreText.text = scoreManager.Score+"点でしたー！！" ;
        Debug.Log("ResultScore");

    }
}
