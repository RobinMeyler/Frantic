using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BladeBehaviour : MonoBehaviour
{
    private GameObject platform;
    public GameObject gameController;
    GameObject[] platforms;
    private float degrees = 0f;
    private int index = 2;
    private float offset = 0f;
    private bool movingDir = true; //true == right, false == left

    // Start is called before the first frame update
    void Start()
    {
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        if (SceneManager.GetActiveScene().name != "Tutorial")
        {
            while (index == 2)
            {
                index = Random.Range(0, platforms.Length);
            }
        }
        this.transform.position = platforms[index].transform.position;
        this.transform.parent = platforms[index].transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingDir)
        {
            offset = offset + 0.01f;
        }
        else
        {
            offset = offset - 0.01f;
        }
        if (offset > 0.5)
        {
            movingDir = false;
        }
        if (offset < -0.5)
        {
            movingDir = true;
        }
        this.transform.position = new Vector3(platforms[index].transform.position.x + offset, this.transform.position.y, this.transform.position.z);


        degrees += 3;
        this.transform.eulerAngles = Vector3.forward * degrees;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && SceneManager.GetActiveScene().name != "Tutorial")
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-2.43f, -2.16f, 0);
        }
    }

    public void setIndex(int t_ind)
    {
        index = t_ind; 
    }
}
