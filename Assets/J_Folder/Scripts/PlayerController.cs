using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float player_speed = 10f;
    public float jumpForce = 5f;
    public float view_speed;
    Rigidbody rb;
    Animator animator;
    float hAxis;
    float vAxis;
    
    int jumpCnt = 0;
    float re_jumpForce;
    bool isRun;
    bool isSpace;
    bool isSprint;
    bool isUpSpace;
    bool isGround = true;
    Vector3 moveVec;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        re_jumpForce = jumpForce;
        animator = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        player_rotate();
        player_Move();
        Jump();
    }
    void Update()
    {
        player_Input();
        player_state();
        
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;  // 땅에 닿으면 isGrounded를 true로 설정
            jumpCnt = 0;  // 점프 횟수 초기화
            jumpForce = re_jumpForce;
        }
    }
}
