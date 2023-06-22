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
    bool isRun;
    bool isSpace;
    bool isSprint;
    bool isGround = true;
    Vector3 moveVec;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        isSpace = Input.GetAxisRaw("Jump") != 0 ? true : false;
        isSprint = Input.GetAxisRaw("Run") != 0 ? true : false;
        moveVec = new Vector3(hAxis, 0,vAxis).normalized;
        isRun = moveVec != Vector3.zero ? true : false;

    }
    void player_state()
    {
        
        
        
    }
    void player_Move()
    {

        if (isRun && !isSprint)
        {
            transform.position += moveVec * player_speed * Time.deltaTime;
            view_speed = player_speed;
            animator.SetBool("isRun", isRun);

        }
        else if (isSprint && isRun)
        {
            transform.position += moveVec * 2f * player_speed * Time.deltaTime;
            view_speed = player_speed*2;
            animator.SetBool("isSprint", isSprint);
        }

        if (isGround)
        {
            animator.SetBool("isGround", isGround);
        }
        
        
        
    }
    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < 2)
        {
            jumpCnt++;
            Debug.Log("점프 누름 :" + jumpCnt.ToString());
            isGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("isGround", isGround);

        }
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;  // 땅에 닿으면 isGrounded를 true로 설정
            jumpCnt = 0;  // 점프 횟수 초기화

        }
    }
}
