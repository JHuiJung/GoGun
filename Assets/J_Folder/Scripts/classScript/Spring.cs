using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public GameObject ball1;
    public GameObject ball2;
    public float springConstant = 1;
    public float restLength;
    public float currentLength;

    private ballphysics connectedBody1;
    private ballphysics connectedBody2;

    //스프링 연결 관계 그리기 위함
    LineRenderer lineRenderer;

    void Start()
    {
        connectedBody1=ball1.GetComponent<ballphysics>();
        connectedBody2=ball2.GetComponent<ballphysics>();

        restLength = (ball1.transform.position - ball2.transform.position).magnitude;


        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
    }

    void FixedUpdate() {
        // 두 강체 간의 거리를 계산
        Vector3 connectionVector = ball2.transform.position - ball1.transform.position;
        currentLength = connectionVector.magnitude;

        // 스프링이 원래 길이보다 늘어난 정도를 계산
        float displacement = currentLength - restLength;

        // 힘의 크기를 계산
        float springForceMagnitude = displacement * springConstant;

        // 각각의 강체에 힘을 적용
        Vector3 springForce = connectionVector.normalized * springForceMagnitude;
        connectedBody1.AddForce(springForce);
        connectedBody2.AddForce(-springForce);

        //그리기 위한 정보 전달
        lineRenderer.SetPosition(0, ball1.transform.position);
        lineRenderer.SetPosition(1, ball2.transform.position);
    }
}
