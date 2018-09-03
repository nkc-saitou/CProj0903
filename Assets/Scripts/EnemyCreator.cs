using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public Transform target;
    public Enemy[] enemyPreList;

    float createTimer;
    float createInterval;

    //=====================================================
    void Start ()
    {
        createTimer = 0;
        createInterval = 1.0f;
    }
	void Update ()
    {
        createTimer += Time.deltaTime;
        if (createInterval < createTimer)
        {
            CreateEnemy();
            createTimer = 0;
        }
	}
    //-----------------------------------------------------
    //  敵生成
    //-----------------------------------------------------
    void CreateEnemy()
    {
        Vector3 createPos = RandomPosition();
        Vector3 moveDir = target.position - createPos;
        moveDir.y = 0;

        Enemy enemy = Instantiate(enemyPreList[Random.Range(0, 2)], createPos, Quaternion.identity);
        enemy.SetMoveDirection(moveDir.normalized);
    }
    //-----------------------------------------------------
    //  生成位置の決定
    //-----------------------------------------------------
    Vector3 RandomPosition()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        // 上
        if(Random.Range(0, 2) == 0) {
            pos.x = Random.Range(-10.0f, 10.0f);
            pos.z = 6.0f;
        }
        // 左右
        else {
            pos.x = (Random.Range(0, 2) == 0) ? -10.0f : 10.0f;
            pos.z = Random.Range(target.position.z, 5.0f);
        }
        return pos;
    }
}
