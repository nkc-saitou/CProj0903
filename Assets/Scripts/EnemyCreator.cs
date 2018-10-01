using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public Transform target;
    public Enemy[] enemyPreList;

    int   createCount;
    float createTimer;
    float createInterval;

    //=====================================================
    void Start ()
    {
        createCount = 0;
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
        int num = Random.Range(0, 2);
        Enemy enemy = Instantiate(enemyPreList[num], createPos, enemyPreList[num].transform.rotation);
        enemy.SetMoveDirection(GetMoveDirection(createPos));

        AddCount();
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
    //-----------------------------------------------------
    //  移動方向の計算
    //-----------------------------------------------------
    Vector3 GetMoveDirection(Vector3 pos)
    {
        return Vector3.Scale((target.position - pos), new Vector3(1, 0, 1)).normalized;
    }
    //-----------------------------------------------------
    //  敵生成数のカウント
    //-----------------------------------------------------
    void AddCount()
    {
        createCount++;
        if (createCount % 5 == 0) createInterval = Mathf.Max(createInterval - 0.05f, 0.2f);
    }
}
