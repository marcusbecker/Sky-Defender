using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    
    public GameObject[] items;

    public GameObject tileParent;

    private static List<GameObject> tiles;

    private bool gamePlay = true;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void destroyTile(GameObject tile)
    {
        tiles.Remove(tile);
        DestroyImmediate(tile.GetComponent("BoxCollider2D"));
        Rigidbody2D rigid = tile.AddComponent<Rigidbody2D>();
        rigid.mass = 5;
        //Destroy(tile);
    }

    IEnumerator createItem()
    {
        while(gamePlay)
        {
            GameObject tile = tiles[Random.Range(0, tiles.Count)];
            Vector3 temp = tile.transform.position;
            GameObject item = Instantiate(items[Random.Range(0, items.Length)], new Vector3(temp.x, temp.y + 0.98f, 0), Quaternion.identity);
            if(item.name.Contains("Bomb"))
            {
                item.GetComponent<BombScript>().tile = tile;
            }

            yield return new WaitForSeconds(Random.Range(3, 10));
        }
    }
}
