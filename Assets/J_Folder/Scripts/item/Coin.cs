using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour,IItem
{
    public void Use()
    {
        Debug.Log("코인 사용");
        GameManager.instance.AddScore_coin(10);
        Destroy(gameObject);
    }

    public void Destroy_TimeDone()
    {
        Destroy(gameObject);
    }
}
