using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlowGage : MonoBehaviour
{
    public Image SlowGage_Image;
    public PlayerController pc;
    public float Gage = 100f;
    public float Reduce_Rate = 20f;
    public float increase_Rate = 10f;
    float emptyGage;
    // Start is called before the first frame update
    void Start()
    {
        emptyGage = Gage;
    }

    // Update is called once per frame
    void Update()
    {
        bool chk_slowMode = pc.get_isSlowMode();

        if (chk_slowMode)
        {
            Gage -= Reduce_Rate * Time.deltaTime;
            if(Gage < 0)
            {
                pc.set_isSlowMode(false);
            }
        }
        else
        {
            Gage += Reduce_Rate * Time.deltaTime;
            if(Gage >= emptyGage)
            {
                Gage = emptyGage;
            }
        }

        SlowGage_Image.fillAmount = Gage / emptyGage;
    }

    public float get_SlowGage()
    {
        return Gage;
    }
}
