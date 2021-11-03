using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<10; ++i)
        {
            Instantiate(items[1], new Vector3(i * 2, i * 2, 0), Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
