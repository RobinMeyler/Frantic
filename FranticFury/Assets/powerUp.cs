using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    Vector3 position;
    Vector3 startPosition;
    float direction = 0.0000001f;
    GameObject[] platforms;

    // Start is called before the first frame update
    void Start()
    {
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        int randomPlat = Random.Range(0, platforms.Length);
        position = platforms[randomPlat].transform.position + new Vector3(0, 0.5f, 0);
        startPosition = position;
        transform.parent = platforms[randomPlat].transform;
        transform.position = position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ////startPosition = 
        ////position = transform.parent.position + new Vector3(0, 0.5f + direction, 0);


        ////if ((position.y > (startPosition.y + 5f)) || (position.y > (startPosition.y - 5f)))
        ////{
        ////    direction = -direction;
        ////}

        //transform.position = position;
    }
}
