using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jump : MonoBehaviour
{
    public Button thisButton;
    public GameObject player;
    public Rigidbody2D rb;
    bool oop = false;
    void Start()
    {
        Button btn = thisButton.GetComponent<Button>();
        // btn.onClick.AddListener(TaskOnClick);
        rb = player.GetComponent<Rigidbody2D>();
        

        //GameObject uiClick = GameObject.FindGameObjectWithTag("ClickFX");
        //clickObj = uiClick.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GetComponent<touch>().is_Touched == true)
        {
            player.GetComponent<PlayerBehaviour>().buttonJump();
        }
    }
}