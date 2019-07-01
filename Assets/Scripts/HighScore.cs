using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    int highScore;
    string highScoreKey = "HighScore";
    public Text HiScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        HiScoreText.text = highScore + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
