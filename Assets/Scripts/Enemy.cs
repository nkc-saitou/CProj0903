using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CProj;

public class Enemy : MonoBehaviour
{
    const float MOVE_SPEED = 2.0f;

    public ScandalType type;

    Transform transformCache;
    Vector3 moveDir = Vector3.zero;

    //=====================================================
	void Start ()
    {
        transformCache = transform;
	}
	void Update ()
    {
        Move();
	}
    //-----------------------------------------------------
    //  進む方向
    //-----------------------------------------------------
    public void SetMoveDirection(Vector3 dir)
    {
        moveDir = dir;
    }
    //-----------------------------------------------------
    //  移動
    //-----------------------------------------------------
    void Move()
    {
        transformCache.position += moveDir * MOVE_SPEED * Time.deltaTime;
    }
    //-----------------------------------------------------
    //  当たり判定
    //-----------------------------------------------------
    void OnTriggerEnter(Collider coll)
    {
        if( coll.tag == "Bullet" && 
            coll.GetComponent<Bullet>().Type == type)
        {
            ScoreManager.instance.AddScore(1);
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
