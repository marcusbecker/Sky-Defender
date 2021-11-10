﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameScript : MonoBehaviour
{
    
    public GameObject player;
    public GameObject[] items;

    public GameObject tileParent;

    private static List<GameObject> tiles;

    private bool gamePlay = true;

    public int count = 10;
    public int maxTime = 10;

    public Text gameOverText;

    void Awake()
    {
        int tileCount = tileParent.transform.childCount;
        tiles = new List<GameObject>(tileCount);

        for (int i=0; i<tileCount; ++i)
        {
            tiles.Add(tileParent.transform.GetChild(i).gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(createItem());
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -30)
        {
            gamePlay = false;
            gameOverText.gameObject.SetActive(true);
        }

        if(!gamePlay)
        {
            if (Input.GetButtonDown("Jump")) {
                SceneManager.LoadScene("IntroScene");
            }
        }
    }

    public static void destroyTile(GameObject tile)
    {
        tiles.Remove(tile);
        DestroyImmediate(tile.GetComponent("BoxCollider2D"));
        Rigidbody2D rigid = tile.AddComponent<Rigidbody2D>();
        rigid.mass = 5;
    }

    IEnumerator createItem()
    {
        while(gamePlay)
        {
            if(maxTime > 2)
            {
                --count;
                if(count < 1)
                {
                    count = 10;
                    --maxTime;
                }
            }

            GameObject tile = tiles[Random.Range(0, tiles.Count)];
            Vector3 temp = tile.transform.position;
            GameObject item = Instantiate(items[Random.Range(0, items.Length)], new Vector3(temp.x, temp.y + 0.98f, 0), Quaternion.identity);
            if(item.name.Contains("Bomb"))
            {
                item.GetComponent<BombScript>().tile = tile;
            }

            yield return new WaitForSeconds(Random.Range(2, maxTime));
        }
    }
}
