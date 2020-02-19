using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static float dropSpeed;
    public static float endTime = 0;
    public static float gameTime = 0;
    public static float playerSpeed = 0.5f;
    public GameObject platform;
    public GameObject[] platforms;
    public static bool lastPlat = false;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        endTime = 0;
        platforms = new GameObject[7];
        dropSpeed = 0.001f;
        for (int i = 0; i < 7; i++)
        {
            Quaternion spawnRotation = Quaternion.identity;
            float randX = Random.Range(-1.8f, 1.8f);
            Vector3 spawnPosition = new Vector3(randX,5 -(i*1.6f), 0);
            Instantiate(platform, spawnPosition, spawnRotation);
            platforms[i] = platform;
        }
        timeText.text = "Time: " + gameTime;
        Debug.Log(platforms.Length);
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        timeText.text = "Time: " + (int)gameTime;
        if (endTime > 10)
        {
            endTime -= Time.deltaTime;
        }

        if(endTime < 12 && endTime > 11)
        {
            gameTime = 0;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }

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
