using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField]
    private GameObject superWallPre;
    [SerializeField]
    private GameObject wallPrefab;
    /**
     * 行列
     */
    private int mapRow;
    private int mapCol;

    private List<Vector2> vList = new List<Vector2>();

    private void Awake()
    {
        InitMap(8,9,10);
    }

    public void InitMap(int x,int y,int wallNum) {
        this.mapCol = x;
        this.mapRow = y;
        CreateSuperWall();
        findAllEmpty();
        createWall(wallNum);
    }

    /// <summary>
    /// 生成实体墙
    /// </summary>
    private void CreateSuperWall() {
        for (int i = - mapCol+2; i < mapCol-2; i += 2) {
            for (int j = -mapRow+2; j < mapRow; j += 2) {
                GameObject wall = Instantiate(superWallPre,transform);
                wall.transform.position = new Vector3(i+1,j);
            }
        }


        ///up
        ///
        for (int i = -mapCol; i < mapCol - 1; i ++) {
            createObject(i + 1, mapRow);
        }

        ///down
        ///
        for (int i = -mapCol; i < mapCol - 1; i++)
        {
            createObject(i + 1, -mapRow);
        }

        ///left
        ///
        for (int i = -mapRow + 1; i < mapRow; i++)
        {
            createObject(-mapCol + 1, i);
        }

        for (int i = -mapRow+1; i < mapRow; i++)
        {
            createObject(mapCol - 1, i);
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
        for (int i = -mapCol + 3; i < mapCol - 1; i += 2)
        {
            for (int j = -mapRow + 1; j <= mapRow; j += 2)
            {
                vList.Add(new Vector2(i,j));
                //createObject1(i,j);
            }
        }

        for (int i = -mapCol + 2; i < mapCol - 1; i += 2)
        {
            for (int j = -mapRow + 1; j < mapRow; j ++)
            {
                vList.Add(new Vector2(i, j));
                //createObject1(i, j);
            }
        }
    }

    /// <summary>
    /// 生成固定数量的墙        
    /// </summary>
    /// <param name="count"></param>
    public void createWall(int count) {
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, vList.Count);
            Vector2 pos = vList[index];
            vList.RemoveAt(index);
            GameObject gameObject = Instantiate(wallPrefab,transform);
            gameObject.transform.position = pos;
        }
    }

    public void createObject1(int x, int y)
    {
        GameObject wall = Instantiate(wallPrefab, transform);
        wall.transform.position = new Vector3(x, y);
    }
}
