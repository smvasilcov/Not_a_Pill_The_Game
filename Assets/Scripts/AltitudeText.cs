using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AltitudeText : MonoBehaviour {

    public GameObject Rocket;
    public Text AltitudeTextValue;

    private string altitude;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        altitude = Convert.ToString(Convert.ToInt16(Rocket.transform.position.y*10));
        AltitudeTextValue.text = ("Altitude: " + altitude + " meters");
	}
}
