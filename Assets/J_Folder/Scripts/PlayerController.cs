using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum player_status{
    idle,
    run,
    sprint,
    jump
}

public class PlayerController : MonoBehaviour
{
    public float player_speed = 10f;
    player_status p_status = player_status.idle;
    Rigidbody rb;
    Animator animator;
    float hAxis;
    float vAxis;
    bool isRun;
    bool isSpace;
    bool isSprint;
    bool isGround;
    Vector3 moveVec;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player_Input();
        player_state();
        player_rotate();
        player_Move();
    }
    void player_rotate()
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveVec);
        this.GetComponent<Transform>().rotation = targetRotation;
    }
    void player_Input()
    {
        // 방향키 값을 입력 받아 
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        isSpace = Input.GetAxisRaw("Jump") != 0 ? true : false;
        isSprint = Input.GetAxisRaw("Run") != 0 ? true : false;
        moveVec = new Vector3(hAxis, 0,vAxis).normalized;
        isRun = moveVec != Vector3.zero ? true : false;

    }
    void player_state()
    {
        animator.SetBool("isRun", isRun);
        animator.SetBool("isSprint", isSprint);
        
    }
    void player_Move()
    {

        if (isRun)
        {
            transform.position += moveVec * player_speed * Time.deltaTime;
        }
        else if (isSprint)
        {
            transform.position += moveVec * 1.5f * player_speed * Time.deltaTime;
        }
        
    }
}
