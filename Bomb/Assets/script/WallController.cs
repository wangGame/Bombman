﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public GameObject superWallPre;
    public GameObject wallPrefab;
    /**
     * 行列
     */
    private int X;
    private int Y;

    private List<Vector2> vList = new List<Vector2>();

    private void Awake()
    {
        InitMap(8,9);
    }

    public void InitMap(int x,int y) {
        this.X = x;
        this.Y = y;
        CreateSuperWall();
        findAllEmpty();
    }

    /// <summary>
    /// 生成实体墙
    /// </summary>
    private void CreateSuperWall() {
        for (int i = -X+2; i < X-2; i += 2) {
            for (int j = -Y+2; j < Y; j += 2) {
                GameObject wall = Instantiate(superWallPre,transform);
                wall.transform.position = new Vector3(i+1,j);
            }
        }


        ///up
        ///
        for (int i = -X; i < X - 1; i ++) {
            createObject(i + 1, Y);
        }

        ///down
        ///
        for (int i = -X; i < X - 1; i++)
        {
            createObject(i + 1, -Y);
        }

        ///left
        ///
        for (int i = -Y+1; i < Y; i++)
        {
            createObject(-X + 1, i);
        }

        for (int i = -Y+1; i < Y; i++)
        {
            createObject(X-1, i);
        }
    }

    public void createObject(int x,int y) {
        GameObject wall = Instantiate(superWallPre, transform);
        wall.transform.position = new Vector3(x, y);
    }

    /// <summary>
    /// 找出所有空位置
    /// </summary>
    public void findAllEmpty() {
        for (int i = -X + 3; i < X - 1; i += 2)
        {
            for (int j = -Y + 1; j <= Y; j += 2)
            {
                vList.Add(new Vector2(i,j));
            }
        }

        for (int i = -X + 2; i < X - 1; i += 2)
        {
            for (int j = -Y + 1; j <= Y; j ++)
            {
                vList.Add(new Vector2(i, j));
            }
        }
    }

    public void createObject1(int x, int y)
    {
        GameObject wall = Instantiate(wallPrefab, transform);
        wall.transform.position = new Vector3(x, y);
    }
}
