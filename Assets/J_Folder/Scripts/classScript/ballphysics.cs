using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballphysics : MonoBehaviour
{
    public bool fixedball = false;
    public bool useGravity = true;
    public float stiffness = 1.0f;
    public float damping = 0.1f;
    public float mass = 1.0f;
    public float dt = 0.02f;

    public Vector3 vel;
    public Vector3 force;
    public Vector3 gravity = new Vector3(0.0f, -9.8f, 0.0f);
    GameObject Ground;
    float ground_y;
    // Start is called before the first frame update
    void Start()
    {
        Ground = GameObject.FindGameObjectWithTag("Ground");
        ground_y = Ground.transform.position.y;
        AddForce(Vector3.forward * -1*50f);
        Rigidbody rb = this.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!fixedball)
        {
            
            //add gravity
            if(useGravity)
            {
                force+=gravity*mass;
            }

            //add damping force
            force-= vel*damping;

            //update ball
            vel += force/mass*dt;

            //update position
            this.transform.position += vel*dt;

            //clear force
            force = new Vector3(0,0,0);
        }
        
        if (this.transform.position.y < ground_y)
        {

            float depth = this.transform.position.y - GetRadius();
            Vector3 a = Vector3.up * -1* depth * stiffness;
            AddForce(a);


        }
    }
    public void AddForce(Vector3 _force)
    {
        force += _force;
    }
    public float GetRadius()
    {
        Vector3 scales = this.transform.localScale;
        return Mathf.Max(scales.x, scales.y, scales.z)/2.0f;
    }
}
