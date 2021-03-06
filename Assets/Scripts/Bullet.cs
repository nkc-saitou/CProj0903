﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CProj;

public class Bullet : MonoBehaviour
{
    const float MOVE_SPEED = 12.0f;

    public Material[]  bulletMaterials;
    public ScandalType Type { get; private set; }

    Transform transformCache;
    Vector3   moveDir = Vector3.zero;

    //=====================================================
	void Start ()
    {
        transformCache = transform;
        Destroy(this.gameObject, 1.0f);
	}
	void Update ()
    {
        Move();
	}
    //-----------------------------------------------------
    //  球のタイプ変更
    //-----------------------------------------------------
    public void SelectType(ScandalType type)
    {
        Type = type;
        GetComponent<MeshRenderer>().material = bulletMaterials[(int)type];
    }
    //-----------------------------------------------------
    //  球の進む方向
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
}
