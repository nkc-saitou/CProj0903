﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    Transform transformCache;

    public Bullet bulletPre;

    //=====================================================
	void Start ()
    {
        transformCache = transform;
	}
	void Update ()
    {
        if (Input.GetMouseButtonDown(0)) BulletShot(Bullet.BulletType.Woman);
        else if (Input.GetMouseButtonDown(1)) BulletShot(Bullet.BulletType.Money);
	}
    //-----------------------------------------------------
    //  球を飛ばす
    //-----------------------------------------------------
    void BulletShot(Bullet.BulletType type)
    {
        // 球のタイプ
        Bullet bullet = Instantiate(bulletPre, transformCache.position, Quaternion.identity);
        bullet.SelectType(type);
        // 飛ばす方向
        Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = clickPos - transformCache.position;
        dir.y = 0;
        bullet.SetMoveDirection(dir.normalized);
    }
}
