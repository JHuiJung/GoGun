using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpwner : MonoBehaviour
{
    public Vector3 attack_range1 = Vector3.zero;
    public Vector3 attack_range2 = Vector3.zero;
    public float min_Spawn_delay = 1f;
    public float max_Spawn_delay = 5f;
    public GameObject[] attacks;

    float spawnRate;
    float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(min_Spawn_delay, max_Spawn_delay);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool isrest_time = GameManager.instance.getIsRestTime();
        float game_dt = GameManager.instance.get_dt();

        if (isrest_time)
        {
            GameObject[] ats = GameObject.FindGameObjectsWithTag("Attack");
            for(int i = 0; i < ats.Length; i++)
            {
                ballphysics bp = ats[i].GetComponent<ballphysics>();
                if(bp != null)
                {
                    bp.Destroy_TimeDone();
                }
            }
            timeAfterSpawn = 0f;
        }
        else
        {
            timeAfterSpawn += 50*game_dt*Time.deltaTime;

            if (timeAfterSpawn >= spawnRate)
            {
                float x = Random.Range(attack_range1.x, attack_range2.x);
                float y = Random.Range(attack_range1.y, attack_range2.y);
                float z = Random.Range(attack_range1.z, attack_range2.z);
                Vector3 shoot_position = new Vector3(x, y, z);

                timeAfterSpawn = 0f;
                GameObject attack = attacks[Random.Range(0, GameManager.instance.get_Stage_Level())];
                GameObject shoot_attack = Instantiate(attack, shoot_position, attack.transform.rotation);
                

                spawnRate = Random.Range(min_Spawn_delay, max_Spawn_delay);
            }
        }
        
    }
    void set_time()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(min_Spawn_delay, max_Spawn_delay);
    }
}
