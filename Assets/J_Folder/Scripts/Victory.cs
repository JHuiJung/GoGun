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
        time_score.text = "시간 점수 : " + time.ToString();
        coin_score.text = "코인 점수 : " + coin.ToString();
        total_scre.text = "총 점수 : " + total.ToString();
    }
    // Update is called once per frame
}
