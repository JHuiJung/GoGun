using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour,IItem
{
    public void Use()
    {
        Debug.Log("���� ���");
        GameManager.instance.AddScore_coin(10);
        Destroy(gameObject);
    }

    public void Destroy_TimeDone()
    {
        Destroy(gameObject);
    }
}
