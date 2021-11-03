using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    
    public GameObject[] items;

    public GameObject tileParent;

    private List<GameObject> tiles;

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

    IEnumerator createItem()
    {
        while(gamePlay)
        {
            GameObject tile = tiles[Random.Range(0, tiles.Count)];
            Vector3 temp = tile.transform.position;
            Instantiate(items[Random.Range(0, items.Length)], new Vector3(temp.x, temp.y + 0.98f, 0), Quaternion.identity);            
            //Debug.Log(tile.name);
            yield return new WaitForSeconds(Random.Range(3, 10));
        }
    }
}
