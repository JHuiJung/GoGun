using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public GameObject Victory_obj;
    public Text score_Txt;
    public Text time_Txt;
    public Text stage_Txt;
    bool isGameOver = false;
    bool isRestTime = false;
    int now_time = 100;
    public int restTime = 10;
    public int stage_time = 45;
    float one_sec = 0;
    public int score = 0;
    public int score_coin = 0;
    public int score_time = 0;
    public int score_Obj = 0;

    public int stageLevel = 0;

    float dt = 0.02f;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        setTime();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        UpdateTime();
        if(stageLevel == 4 && isRestTime)
        {
            Victory();
        }
    }
    void UpdateText()
    {
        score = score_time + score_coin + score_Obj;
        score_Txt.text = "���� : " + score.ToString();
        time_Txt.text = "���� �ð� : " + now_time.ToString();
        if (!isRestTime) {
            stage_Txt.text = "�������� : " + stageLevel.ToString();
            
        }
        else {
            stage_Txt.text = "���� �ð�"; 
        }
         
    }
    void setTime()
    {
        if (!isRestTime)
        {
            now_time = restTime;
            stageLevel += 1;
            isRestTime = true;
        }
        else
        {
            now_time = stage_time;
            isRestTime = false;
        }
    }
    void UpdateTime()
    {
        one_sec += dt*50*Time.deltaTime;
        if(one_sec >= 1)
        {
            now_time -= 1;
            one_sec = 0;
            if (!isRestTime)
            {
                score_time += 1;
            }
            if(now_time <= 0)
            {
                setTime();
            }
        }

        
        
    }

    public void AddScore_Obj(int _score)
    {
        score_Obj += _score;
    }

    public void AddScore_coin(int _score)
    {
        score_coin += _score;
    }

    public bool getIsRestTime()
    {
        return isRestTime;
    }

    public int get_Stage_Level()
    {
        return stageLevel;
    }
    public void set_dt(float d)
    {
        this.dt = d;
    }
    public float get_dt()
    {
        return dt;
    }
    public bool get_isGameOver()
    {
        return isGameOver;
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("���ӿ���");
        SceneManager.LoadScene("Fail");

    }
    public void Victory()
    {
        isGameOver = true;
        Victory_obj.SetActive(true);
        Victory_obj.GetComponent<Victory>().set_text(score_time,score_coin,score);
    }
}
