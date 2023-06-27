using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float player_speed = 10f;
    public float jumpForce = 5f;
    public float view_speed;
    public int player_heath = 3;
    public GameObject player_cam;
    public GameObject sm_panel;
    Rigidbody rb;
    Animator animator;
    float hAxis;
    float vAxis;
    
    int jumpCnt = 0;
    float re_jumpForce;
    float time_hit;
    float dt;
    bool ishitted;
    bool isRun;
    bool isSpace;
    bool isSprint;
    bool isUpSpace;
    bool isGround = true;
    bool isSlowMode = false;
    Vector3 moveVec;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        re_jumpForce = jumpForce;
        animator = this.GetComponent<Animator>();
        dt = GameManager.instance.get_dt();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        player_rotate();
        player_Move();
        Jump();
        chk_hit();
    }
    void Update()
    {
        player_Input();
        player_state();
        SlowMode();
        if(player_heath == 0)
        {
            GameManager.instance.GameOver();
        }
        
    }
    void chk_hit()
    {
        if (ishitted)
        {
            time_hit += 50*dt*Time.deltaTime;
            if(time_hit >= 0.5f)
            {
                ishitted = false;
                time_hit = 0;
            }
        }
    }
    void player_rotate()
    {
        transform.LookAt(moveVec + transform.position);
    }
    void player_Input()
    {
        // 방향키 값을 입력 받아 
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        isSpace = Input.GetButtonDown("Jump");
        isUpSpace = Input.GetButtonUp("Jump");
        isSprint = Input.GetAxisRaw("Run") != 0 ? true : false;
        
        
        moveVec = new Vector3(hAxis, 0,vAxis).normalized;
        isRun = moveVec != Vector3.zero ? true : false;

        bool chk_slowmode = Input.GetKeyDown(KeyCode.G);
        if (chk_slowmode)
        {
            if (isSlowMode)
            {
                isSlowMode = false;
            }
            else
            {
                isSlowMode=true;
            }
        }

    }
    void player_state()
    {

        if (isGround)
        {
            animator.SetBool("isRun", isRun);
            if (isRun) { animator.SetBool("isSprint", isSprint);  }
            
           
        }
        else
        {
            animator.SetBool("isRun", isRun);
        }
        
        
    }
    void player_Move()
    {

       
        if (isSprint && isRun)
        {
            transform.position += moveVec * 2f * player_speed * Time.deltaTime;
            view_speed = player_speed*2;
        }
        else if(!isSprint && isRun)
        {
            transform.position += moveVec * player_speed * Time.deltaTime;
            view_speed = player_speed;
        }

        
        
        
    }
    void Jump()
    {
        if (isSpace && jumpCnt < 2)
        {
            jumpCnt++;

            isGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

        }
        else if (isUpSpace)
        {
            rb.velocity *= 0.5f;
        }
        
        
    }
    void SlowMode()
    {
        GameObject[] ats = GameObject.FindGameObjectsWithTag("Attack");
        

        if (isSlowMode)
        {
            sm_panel.SetActive(true);
            for (int i = 0; i < ats.Length; i++)
            {
                ballphysics bp = ats[i].GetComponent<ballphysics>();
                if (bp != null)
                {
                    bp.Change_dt(0.005f);
                    GameManager.instance.set_dt(0.005f);
                }
            }
        }
        else
        {
            sm_panel.SetActive(false);
            for (int i = 0; i < ats.Length; i++)
            {
                ballphysics bp = ats[i].GetComponent<ballphysics>();
                if (bp != null)
                {
                    bp.Change_dt(0.02f);
                    GameManager.instance.set_dt(0.02f);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;  // 땅에 닿으면 isGrounded를 true로 설정
            jumpCnt = 0;  // 점프 횟수 초기화
            jumpForce = re_jumpForce;
        }

        if (collision.gameObject.CompareTag("Attack") && !ishitted && GameManager.instance.get_isGameOver() == false)
        {
            ishitted = true;

            player_heath -= 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HealPack hp = other.GetComponent<HealPack>();
        if(hp != null)
        {
            hp.Use();
        }
        
        Coin coin = other.GetComponent<Coin>();
        if(coin != null)
        {
            coin.Use();
        }
    }

    public void set_isSlowMode(bool ps)
    {
        isSlowMode = ps;
    }

    public bool get_isSlowMode()
    {
        return isSlowMode;
    }

    public void increas_player_health(int health)
    {
        if(player_heath < 3)
        {
            player_heath += health;
        }
        
    }
    public int get_player_health()
    {
        return player_heath;
    }
}
