using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractionDemo : MonoBehaviour
{
    //마우스로 당기는 힘의 크기
    public float stiffness = 10.0f;
    //마우스로 클릭할 범위
    public float pickingRadius = 2;
    //마우스으로 오브젝트 선택 여부
    public bool pickedFlag = false;

    private float disfromScreen = 0.0f;

    //선택된 공
    public int ballIndex;
    
    //물체와 가장 가까운 마우스 레이위 점
    public Vector3 cloesetPoint;
    
    //공 오브젝트
    public GameObject[] balls;

    private LineRenderer lineRenderer;
    void Start()
    {
        //마우스와 상호작용할 물체 받아오기
        balls = GameObject.FindGameObjectsWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 왼쪽 클릭시
        if(Input.GetMouseButtonDown(0))
        {
            //ray 활용해 가장 가까운점 찾기
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float minimum = 100000000000.0f;
            for (int i=0;i<balls.Length;i++)
            {
                Vector3 temp = PickPoint(ray.origin, ray.direction, balls[i].transform.position,out disfromScreen);
                float distance = (temp-balls[i].transform.position).magnitude;
                if (distance<minimum && distance<pickingRadius)
                {
                    //가장 가까운 점 정보들 저장
                    minimum=distance;
                    cloesetPoint=temp;
                    ballIndex=i;

                    //오브젝트가 잡힌 상태 활성화
                    pickedFlag=true;
                }
            }
        }

        //마우스로 오브젝트를 집은 상태 일때
        if(pickedFlag)
        {
            //현재 ray 받아오기
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //현재 ray로 부터 레이 위의 점 위치 업데이트
            cloesetPoint=ray.origin + ray.direction * disfromScreen;

            //가장 가까운 공으로 부터 ray위의 점으로 향하는 방향
            Vector3 direction = new Vector3(0,0,0);

            //힘 계산 및 추가
            Vector3 force = direction*stiffness;
            balls[ballIndex].GetComponent<ballphysics>().AddForce(force);
        }

        //마우스 놓으면 해제
        if(Input.GetMouseButtonUp(0))
        {
            pickedFlag=false;
        }
        
    }

    Vector3 PickPoint(Vector3 origin, Vector3 direction, Vector3 target, out float disfromScreen)
    {
        Vector3 pickPoint = new Vector3(0,0,0);
        disfromScreen = 0.0f;
        return pickPoint;
    }
}
