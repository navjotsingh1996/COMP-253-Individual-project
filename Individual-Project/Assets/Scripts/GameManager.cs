using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject mainDoor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (mainDoor == null)
        {
            Invoke("GO", 3);
        }
	}

    void GO ()
    {
        SceneManager.LoadScene("Game Over");
    }
}
