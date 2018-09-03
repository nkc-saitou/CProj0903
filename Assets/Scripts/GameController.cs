using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    bool isFinish = false;

    //=====================================================
	void Awake ()
    {
        ScoreManager.instance.ResetScore();
	}
    //-----------------------------------------------------
    //  ゲーム終了
    //-----------------------------------------------------
    public void FinishGame()
    {
        if (isFinish) return;

        isFinish = true;
        ScoreManager.instance.isStop = true;
    }
}
