using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformBehav : MonoBehaviour
{
    public float dropSpeed = 0;
    public float sideSpeed = 0;
    public float time = 0;
    int oop = 0;

    // Start is called before the first frame update
    void Start()
    {
        dropSpeed = -0.001f;

        int randspeed = Random.Range(1, 5);
        int rand = Random.Range(0, 10);
        if(rand > 5)
        {
            sideSpeed = 0.005f * randspeed;
        }
        else
        {
            sideSpeed = -0.005f * randspeed;
        }
        


    // Random start x logic
    // start y above screen
}

    // Update is called once per frame
    void Update()
    {
        // Side swaping logic
        // Drop speed increasing logic
        // Once below screen reset
        if(transform.position.x > 1.8f || transform.position.x < -1.8f)
        {
            sideSpeed = -sideSpeed;
        }
        if (transform.position.y < -5.9)
        {
            float randX = Random.Range(-1.8f, 1.8f);
         
            transform.position = new Vector3(randX, 5.5f, 0);
            int rand = Random.Range(0, 2);
            if(rand == 0 && GameController.lastPlat == false)
            {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0,0,90);
                GameController.lastPlat = true;
            }
            else
            {
                transform.rotation = Quaternion.identity;
                GameController.lastPlat = false;
            }

        }

        time += Time.deltaTime;

        if (time > 5)
        {
            Debug.Log(++oop);
            time = 0;
            dropSpeed = dropSpeed - 0.0001f;
        }
        transform.position = transform.position + new Vector3(sideSpeed, dropSpeed, 0);
    }
}