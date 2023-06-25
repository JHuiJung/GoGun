using UnityEngine;
using UnityEngine.AI; // 내비메쉬 관련 코드

// 주기적으로 아이템을 플레이어 근처에 생성하는 스크립트
public class ItemSpawner : MonoBehaviour {


    public Vector3 attack_range1 = Vector3.zero;
    public Vector3 attack_range2 = Vector3.zero;
    public float min_Spawn_delay = 3f;
    public float max_Spawn_delay = 8f;

    public GameObject[] items; // 생성할 아이템들
    float spawnRate;
    float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(min_Spawn_delay, max_Spawn_delay);
    }

    // Update is called once per frame
    void Update()
    {
        bool isrest_time = GameManager.instance.getIsRestTime();
        float game_dt = GameManager.instance.get_dt();

        if (isrest_time)
        {
            
            timeAfterSpawn = 0f;
        }
        else
        {
            timeAfterSpawn += 50* game_dt *Time.deltaTime;

            if (timeAfterSpawn >= spawnRate)
            {
                float x = Random.Range(attack_range1.x, attack_range2.x);
                float y = Random.Range(attack_range1.y, attack_range2.y);
                float z = Random.Range(attack_range1.z, attack_range2.z);
                Vector3 spawn_position = new Vector3(x, y, z);

                GameObject item = items[Random.Range(0, items.Length)];
                GameObject spawn_item = Instantiate(item, spawn_position, Quaternion.identity);
                spawn_item.transform.position += Vector3.up*0.75f;

                timeAfterSpawn = 0f;
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