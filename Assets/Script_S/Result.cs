using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    public Sprite[] resultSp;

    public SpriteRenderer resultRenderer;

    public Text scoreText;

    public Text highScoreText;

    string scoreKey = "HIGH_SCORE";

    int score = 2;

	// Use this for initialization
	void Start () {
        SpriteSet();

        int highScore = PlayerPrefs.GetInt(scoreKey);

        scoreText.text = "スコア       :  " + score.ToString();

        highScoreText.text = "ハイスコア:  " + highScore.ToString();

        HighScore();
    }
	
	// Update is called once per frame
	void Update () {

    }

    void SpriteSet()
    {
        if (score <= 1) resultRenderer.sprite = resultSp[0];
        else resultRenderer.sprite = resultSp[1];
    }

    void HighScore()
    {
        int highScore = PlayerPrefs.GetInt(scoreKey);

        if(highScore < score) PlayerPrefs.SetInt(scoreKey, score);
    }
}
