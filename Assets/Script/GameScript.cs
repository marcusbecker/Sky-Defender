using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameScript : MonoBehaviour
{

    private bool gamePlay = true;
    
    private static List<GameObject> tiles;

    public static bool gameOver = false;
    
    public GameObject[] items;

    public GameObject[] spawItems;

    public char[] spawItemsType;

    public GameObject tileParent;

    public int count = 10;

    public int maxTime = 10;

    public Text gameOverText;

    public Text winnerText;

    public AudioSource music;
    
    public AudioSource endGameMusic;

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
        gameOver = false;
        gamePlay = true;
        count = 10;
        maxTime = 10;
        music.Play(0);
        StartCoroutine(createItem());
        gameOverText.gameObject.SetActive(false);
        winnerText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameScript.gameOver)
        {
            endGame();
        }

        if(!gamePlay)
        {
            if (Input.GetButtonDown("Jump1") || Input.GetButtonDown("Jump2")) {
                SceneManager.LoadScene("IntroScene");
            }
        }
    }

    private void endGame()
    {
        if(gamePlay)
        {
            gamePlay = false;
            music.Stop();
            endGameMusic.Play(0);
            gameOverText.gameObject.SetActive(true);

            winnerText.text = ScoreScript.getWinner();
            winnerText.gameObject.SetActive(true);
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

            if(Random.Range(0, 5) > 3)
            {
                int spawId = Random.Range(0, spawItems.Length);
                // check if it will be spawed in horizontal or vertial
                if('h' == spawItemsType[spawId])
                {
                    bool left = Random.Range(0, 2) == 0;
                    GameObject spaw = Instantiate(spawItems[spawId], new Vector3(left ? -15 : 15, Random.Range(-4, 4), 0), left ? Quaternion.Euler(0, 180, 0) : Quaternion.identity);
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
