using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public float stiffness = 1.0f;
    public GameObject[] balls;
    public GameObject[] walls;
    private Mesh[] meshes;


    // Start is called before the first frame update
    void Start()
    {
        //충돌검사할 물체 받아오기
        balls = GameObject.FindGameObjectsWithTag("Ball");
        walls = GameObject.FindGameObjectsWithTag("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<balls.Length;i++)
        {
            float radius = balls[i].GetComponent<ballphysics>().GetRadius();
            Vector3 pos = balls[i].transform.position;
            float depth = pos.y-radius;

            //벽과 충돌검사
            if(depth<-0.05f)
            {
                pos.y=radius;
                //balls[i].transform.position = pos;    
                balls[i].GetComponent<ballphysics>().AddForce(new Vector3(0,-depth*stiffness,0));
            }
            
            //공과 공 사이 충돌검사
            for(int j=i+1;j<balls.Length;j++)
            {
                Vector3 p1 = balls[i].transform.position;
                Vector3 p2 = balls[j].transform.position;
                float radius1 = radius;
                float radius2 = balls[j].GetComponent<ballphysics>().GetRadius();

                if((p2-p1).magnitude<radius1+radius2)
                {
                    Vector3 direction = (p1-p2).normalized;
                    Vector3 contactforce=direction*(radius1+radius2 - (p2-p1).magnitude)*stiffness;
                    balls[i].GetComponent<ballphysics>().AddForce(contactforce);
                    balls[j].GetComponent<ballphysics>().AddForce(-contactforce);

                }
            }
        }
    }

}
