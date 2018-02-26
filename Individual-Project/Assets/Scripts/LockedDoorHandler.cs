using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorHandler : MonoBehaviour {

    public GameObject [] Indicators;
    public GameObject[] Equations;
    public GameObject Door;

    bool[] solvedEquations;
    int problems;
	// Use this for initialization
	void Start () {
        problems = Equations.Length;
        solvedEquations = new bool[problems];
        for(int i = 0;i< problems; i++)
        {
            solvedEquations[i] = false;
        }
    }

    bool allEqSolved()
    {
        for (int i =0;i< problems; i++)
        {
            if (!solvedEquations[i]) { return false; }
        }
        return true;
    }

    // Update is called once per frame
    void Update () {
        if (allEqSolved())
        {
            Destroy(Door);
        }
		for (int i = 0; i < problems; i++)
        {
            GameObject equation = Equations[i];
            GameObject card = equation.GetComponentInChildren<VRTK.VRTK_SnapDropZone>().GetCurrentSnappedObject();
            if (card != null)
            {
                if (card.GetComponent<CardData>().value == equation.GetComponent<AnswerData>().value)
                {
                    solvedEquations[i] = true;
                    Indicators[i].GetComponent<MeshRenderer>().material = Indicators[i].GetComponent<ColorScript>().success;
                } else
                {
                    solvedEquations[i] = false;
                    Indicators[i].GetComponent<MeshRenderer>().material = Indicators[i].GetComponent<ColorScript>().failure;
                }
            } else
            {
                Indicators[i].GetComponent<MeshRenderer>().material = Indicators[i].GetComponent<ColorScript>().neutral;
            }
        }
	}
}
