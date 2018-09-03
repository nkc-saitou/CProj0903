using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champion : MonoBehaviour
{
    public GameController gameController;

    //-----------------------------------------------------
    //  当たり判定
    //-----------------------------------------------------
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Enemy")
        {
            gameController.FinishGame();
            Destroy(coll.gameObject);
        }
    }
}
