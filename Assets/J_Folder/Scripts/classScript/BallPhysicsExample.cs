using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysicsExample : MonoBehaviour
{
    //물리와 관련된 변수들

    public bool fixedball = false;
    public bool useGravity = true;
    public float damping = 0.1f;
    public float mass = 1.0f;
    public float dt = 0.02f;

    public Vector3 vel;
    public Vector3 force;
    public Vector3 gravity = new Vector3(0.0f, -9.8f, 0.0f);

    // Update is called once per frame
    void Update()
    {
        //고정된 점이 아닌 경우 업데이트

        //힘에 중력 추가

        //흡수힘 추가

        //속도 업데이트

        //위치 업데이트

        //힘 초기화
    }

    public void AddForce(Vector3 _force)
    {

    }
    public float GetRadius()
    {
        //this.transform.localScale;
        return 0.0f;
    }
}
