using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class equationConstructor : MonoBehaviour {

    public GameObject[] Equations;
    public GameObject[] CardSlots;

    public GameObject[] SpecialEquations;
    public GameObject[] SpecialCardSlots;
    // Use this for initialization
    void Awake() {
        int[] csIndexes = new int[Equations.Length];
        for (int i = 0; i < Equations.Length; i++)
        {
            int x = Random.Range(0, CardSlots.Length);
            if (alreadyExists(x, csIndexes))
            {
                i--;
            }
        }

        for (int i = 0; i < CardSlots.Length; i++)
        {
            CardSlots[i].GetComponent<CardData>().value = Random.Range(-200, 200);
        }
        for (int i = 0; i < SpecialCardSlots.Length; i++)
        {
            SpecialCardSlots[i].GetComponent<CardData>().value = Random.Range(-200, 200);
        }
        for (int i = 0; i < Equations.Length; i++)
        {
            Text equationText = Equations[i].GetComponentInChildren<Text>();
            setUp(CardSlots[csIndexes[i]], Equations[i], equationText);
        }
        for (int i = 0; i < SpecialEquations.Length; i++)
        {
            Text specialEquationText = SpecialEquations[i].GetComponentInChildren<Text>();
            setUp(SpecialCardSlots[i], SpecialEquations[i], specialEquationText);
        }
    }

    void setUp(GameObject cs, GameObject eq, Text eqTxt)
    {
        Debug.Log(cs.name);
        int op = Random.Range(0, 1);
        int unknown = Random.Range(0, 2);
        int num1 = Random.Range(0, 99);
        int num2 = Random.Range(0, 99);
        string equation = makeEquation(op, unknown, num1, num2);
        int sol = getSolution(op, unknown, num1, num2);
        Debug.Log(sol);
        eqTxt.text = equation;
        eq.GetComponent<AnswerData>().value = sol;
        cs.GetComponent<CardData>().value = sol;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    bool alreadyExists(int x, int[] arr)
    {
        for (int i = 0; i< arr.Length; i++)
        {
            if (x == arr[i])
            {
                return true;
            }
        }
        return false;
    }

    string makeEquation(int op, int uk, int n1, int n2)
    {
        switch (uk)
        {
            case 0:
                return "? "+ getOperator(op) + " " + n1.ToString() + " = " + n2.ToString();
            case 1:
                return n1.ToString() + " " + getOperator(op) + " " + "?" + " = " + n2.ToString();
            case 2:
                return n1.ToString() + " " + getOperator(op) + " " + n2.ToString() + " = " + "?";
        }
        return "Could not make equation";
    }

    string getOperator(int op)
    {
        switch (op)
        {
            case 0:
                return "+";
            case 1:
                return "-";
        }
        return "NO OP FOUND";
    }
    int getSolution(int op, int uk, int n1, int n2)
    {
        switch(uk)
        {
            case 0:
                if (op == 0) return n2 - n1;
                return n2 + n1;
            case 1:
                if (op == 0) return n2 - n1;
                return (n2 - n1)*1;
            case 2:
                if (op == 0) return n1 + n2;
                return n1 - n2;
        }
        return 0;
    }
}
