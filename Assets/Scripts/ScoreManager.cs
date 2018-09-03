using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
        isStop = false;
    }
    //=====================================================
    int  score;

    [HideInInspector] public bool isStop;
    //-----------------------------------------------------
    //  リセット
    //-----------------------------------------------------
    public void ResetScore() {
        score = 0;
        isStop = false;
    }
    //-----------------------------------------------------
    //  加算
    //-----------------------------------------------------
    public void AddScore(int point) {
        if (isStop) return;
        score += point;
    }
    //-----------------------------------------------------
    //  減点
    //-----------------------------------------------------
    public void DownScore(int point){
        if (isStop) return;
        score = Mathf.Max(score - point, 0);
    }
}
