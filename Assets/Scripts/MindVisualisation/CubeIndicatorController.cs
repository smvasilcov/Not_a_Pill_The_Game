using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeIndicatorController : MonoBehaviour {

    public GameObject[] Alpha_cube = new GameObject[4];
    public GameObject[] Alpha_light = new GameObject[4];
    public GameObject MuseRecieve;

    private float[] a_r = new float[5];
    private float[] b_r = new float[5];
    private float[] g_r = new float[5];

    private int maxLightIntensity = 6;

    void Start ()
    {

    }
	
	
	void Update ()
    {
        a_r = MuseRecieve.GetComponent<MuseRecieve>().alpha_relative;
        b_r = MuseRecieve.GetComponent<MuseRecieve>().beta_relative;
        g_r = MuseRecieve.GetComponent<MuseRecieve>().gamma_relative;

        Debug.Log("a_r = " + a_r);
        Alpha_cube[0].transform.localScale = new Vector3(Alpha_cube[0].transform.localScale.x, a_r[0], Alpha_cube[0].transform.localScale.z);
        Alpha_cube[1].transform.localScale = new Vector3(Alpha_cube[1].transform.localScale.x, a_r[1], Alpha_cube[1].transform.localScale.z);
        Alpha_cube[2].transform.localScale = new Vector3(Alpha_cube[2].transform.localScale.x, a_r[2], Alpha_cube[2].transform.localScale.z);
        Alpha_cube[3].transform.localScale = new Vector3(Alpha_cube[3].transform.localScale.x, a_r[3], Alpha_cube[3].transform.localScale.z);

        Alpha_light[0].GetComponent<Light>().intensity = a_r[0] * maxLightIntensity;
        Alpha_light[1].GetComponent<Light>().intensity = a_r[1] * maxLightIntensity;
        Alpha_light[2].GetComponent<Light>().intensity = a_r[2] * maxLightIntensity;
        Alpha_light[3].GetComponent<Light>().intensity = a_r[3] * maxLightIntensity;
    }
}
