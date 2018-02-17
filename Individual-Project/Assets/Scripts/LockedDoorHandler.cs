using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorHandler : MonoBehaviour {

    public GameObject [] Indicators;
    public GameObject[] Equations;
    public GameObject Door;
    int problems;
    int correctAns = 0;
	// Use this for initialization
	void Start () {
        problems = Equations.Length;
	}
	
	// Update is called once per frame
	void Update () {
        if (problems == correctAns)
        {
            Destroy(Door);
            problems = 0;
        }
		for (int i = 0; i < problems; i++)
        {
            GameObject equation = Equations[i];
            GameObject card = equation.GetComponentInChildren<VRTK.VRTK_SnapDropZone>().GetCurrentSnappedObject();
            if (card != null)
            {
                if (card.GetComponent<CardData>().value == equation.GetComponent<AnswerData>().value)
                {
                    correctAns++;
                    Indicators[i].GetComponent<MeshRenderer>().material = Indicators[i].GetComponent<ColorScript>().success;
                } else
                {
                    correctAns--;
                    Indicators[i].GetComponent<MeshRenderer>().material = Indicators[i].GetComponent<ColorScript>().failure;
                }
            } else
            {
                Indicators[i].GetComponent<MeshRenderer>().material = Indicators[i].GetComponent<ColorScript>().neutral;
            }
        }
	}
}
