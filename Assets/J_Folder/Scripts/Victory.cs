using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update
    public Text time_score;
    public Text coin_score;
    public Text total_scre;


    public void set_text(int time, int coin, int total)
    {
        time_score.text = "�ð� ���� : " + time.ToString();
        coin_score.text = "���� ���� : " + coin.ToString();
        total_scre.text = "�� ���� : " + total.ToString();
    }
    // Update is called once per frame
}
