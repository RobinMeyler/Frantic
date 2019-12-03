using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static float dropSpeed;
    public GameObject platform;
    public List<GameObject> platforms = new List<GameObject>();
 

    // Start is called before the first frame update
    void Start()
    {
        dropSpeed = 0.001f;
        for (int i = 0; i < 7; i++)
        {
            Quaternion spawnRotation = Quaternion.identity;
            float randX = Random.Range(-2.34f, 2.34f);
            Vector3 spawnPosition = new Vector3(randX,5 -(i*1.6f), 0);
            Instantiate(platform, spawnPosition, spawnRotation);
            platforms.Add(platform);
        }

        Debug.Log(platforms.Count);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(platforms.Count);
        //foreach (GameObject G in platforms)
        //{
        //    if (G.transform.position.y < -5.5) 
        //    {
        //        Destroy(G);
        //        platforms.Remove(G);
        //        Quaternion spawnRotation = Quaternion.identity;
        //        float randX = Random.Range(-2.34f, 2.34f);
        //        Vector3 spawnPosition = new Vector3(randX, 5.5f, 0);
        //        Instantiate(platform, spawnPosition, spawnRotation);
        //        platforms.Add(platform);
        //    }
        //}
    }
}
