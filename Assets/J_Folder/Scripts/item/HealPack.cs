using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPack : MonoBehaviour, IItem
{
    public void Use()
    {
        Debug.Log("ÈúÆÑ »ç¿ë");
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        p.GetComponent<PlayerController>().increas_player_health(1);
        Destroy(gameObject);
    }

    public void Destroy_TimeDone()
    {
        Destroy(gameObject);
    }
}
