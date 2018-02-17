using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour {
    
    public int value;

    void Awake()
    {
        if (value < 0)
        {
            value = Random.Range(0, 999);
        }
    }
}
