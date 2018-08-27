using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingMuseData : MonoBehaviour {

    public GameObject MuseRecieve;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float[] alpha_relative = MuseRecieve.GetComponent<MuseRecieve>().alpha_relative;
        float[] gamma_relative = MuseRecieve.GetComponent<MuseRecieve>().gamma_relative;
        Debug.Log("Alpha[0]: " + alpha_relative[0]);
        Debug.Log("Gamma[0]: " + gamma_relative[0]);
    }
}
