using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerHealth : MonoBehaviour
{

    public Image[] Heart_Image;
    GameObject player;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerController.get_player_health())
        {
            case 0:
                Heart_Image[0].color = Color.black;
                Heart_Image[1].color = Color.black;
                Heart_Image[2].color = Color.black;
                break;

            case 1:
                Heart_Image[0].color = Color.black;
                Heart_Image[1].color = Color.black;
                Heart_Image[2].color = Color.white;
                break;
            case 2:
                Heart_Image[0].color = Color.black;
                Heart_Image[1].color = Color.white;
                Heart_Image[2].color = Color.white;
                break;
            case 3:
                Heart_Image[0].color = Color.white;
                Heart_Image[1].color = Color.white;
                Heart_Image[2].color = Color.white;
                break;

        }
    }
}
