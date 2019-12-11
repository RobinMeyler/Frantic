using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightMove : MonoBehaviour
{
    public Button thisButton;
    public GameObject player;
    public Rigidbody2D rb;
    void Start()
    {
        Button btn = thisButton.GetComponent<Button>();
        rb = player.GetComponent<Rigidbody2D>();
        //GameObject uiClick = GameObject.FindGameObjectWithTag("ClickFX");
        //clickObj = uiClick.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GetComponent<touch>().is_Touched == true)
        {
            //player.transform.position = player.transform.position + new Vector3(0.1f, 0, 0);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(5, rb.velocity.y);

        }
        else if (rb.velocity.x > 0)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x - 0.5f, rb.velocity.y);
        }
    }
}
