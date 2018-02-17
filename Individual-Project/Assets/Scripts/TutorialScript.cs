using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

    public GameObject Equation;
    public GameObject Indicator;
    public GameObject CorrectCard;
    public GameObject WrongCard;
    public Text Instructions;

    bool wrong = false;
    bool correct = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (wrong)
        {
            CorrectCard.SetActive(true);
            Instructions.text = "Now try the other card";
        }
        GameObject card = Equation.GetComponentInChildren<VRTK.VRTK_SnapDropZone>().GetCurrentSnappedObject();
        if (card != null)
        {
            if (card.GetComponent<CardData>().value == Equation.GetComponent<AnswerData>().value)
            {
                Indicator.GetComponent<MeshRenderer>().material = Indicator.GetComponent<ColorScript>().success;
                Instructions.text = "Looks like you are read";
                Invoke("loadGame", 3);
            }
            else
            {
                Indicator.GetComponent<MeshRenderer>().material = Indicator.GetComponent<ColorScript>().failure;
                wrong = true;
            }
        }
        else
        {
            Indicator.GetComponent<MeshRenderer>().material = Indicator.GetComponent<ColorScript>().neutral;
        }
    }

    void loadGame()
    {
        SceneManager.LoadScene("Individual-Project");
    }
}
