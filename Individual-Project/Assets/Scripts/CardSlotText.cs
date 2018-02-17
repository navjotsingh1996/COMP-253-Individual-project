using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().text = gameObject.transform.root.gameObject.GetComponent<CardData>().value.ToString();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
