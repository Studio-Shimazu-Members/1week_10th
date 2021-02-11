using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
   
    [SerializeField] Text resultscoreText = default;

    public void ResultsScore()
    {
        resultscoreText.text = scoreManager.Score+"点でしたー！！" ;
    }
}
