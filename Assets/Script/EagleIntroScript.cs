using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleIntroScript : MonoBehaviour
{
    
    private bool left = false;

    public float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(left)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
        }
        else
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
        }

        if(transform.position.x < -20 || transform.position.x > 20)
        {
            left = !left;
            /*Vector3 flip = transform.localScale;
            flip.x *= -1;
            gameObject.transform.localScale = flip;*/
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
