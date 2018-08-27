using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour {

    public Text LevelText;
    public Text TaskText;
    public Text LevelDoneText;
    public GameObject Rocket;

    private float altitude;

	void Start ()
    {
        LevelText.text = "Level 1";
        TaskText.text = "Reach 5 000 meters";
	}
	
	void Update ()
    {
        altitude = Rocket.transform.position.y*10;
        if (altitude > 5000)
        {
            LevelDoneText.text = "Congradulations! \nYou have reached 5000 meters.";
            Rocket.SetActive(false);
        }
    }
}
