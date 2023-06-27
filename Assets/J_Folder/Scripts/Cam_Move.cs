using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Move : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player_Cam;
    Transform cam_t;
    bool isMoveing = false;
    void Start()
    {
        cam_t = player_Cam.GetComponent<Transform>();
    }

    // Update is called once per frame
    
    public void cam_Move(float d, float time)
    {
        StartCoroutine(move_front(d, time));
    }

    IEnumerator move_front(float d, float time)
    {
        if (!isMoveing)
        {
            isMoveing = true;
            cam_t.transform.position += Vector3.forward * d;

            for (int i = 0; i < 100; i++)
            {
                cam_t.transform.position += Vector3.forward * -1* d*0.01f;
                yield return new WaitForSeconds(time);
            }

            isMoveing = false;
        }
        else
        {
            yield return null;
        }
    }
}
