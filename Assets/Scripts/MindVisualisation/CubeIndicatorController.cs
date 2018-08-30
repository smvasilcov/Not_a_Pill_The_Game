using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeIndicatorController : MonoBehaviour
{

    public GameObject[] Cube_indicator = new GameObject[4];
    public GameObject[] Light_indicator = new GameObject[4];
    public GameObject MuseRecieve;
    public Dropdown DropdownToChooseMuseData;
    public GameObject CubePrefab;
    public Material CubeMaterial;
    public GameObject LightPrefab;

    private float[] a_r = new float[5];
    private float[] b_r = new float[5];
    private float[] g_r = new float[5];
    private float[] chosenMuseData;// = new float[5];

    public Color alpha_color = Color.red;
    public Color beta_color = Color.green;
    public Color delta_color = Color.blue;
    public Color gamma_color = Color.grey;
    public Color theta_color = Color.cyan;

    private int maxLightIntensity = 8;
    private int dropdownValue = 0;

    void Start ()
    {
        dropdownValue = DropdownToChooseMuseData.value;
    }
	
	
	void Update ()
    {
        switch (dropdownValue)
        {
            case 0:
                chosenMuseData = MuseRecieve.GetComponent<MuseRecieve>().alpha_relative;

                CubeMaterial.color = alpha_color;
                Light_indicator[0].GetComponent<Light>().color = alpha_color;
                Light_indicator[1].GetComponent<Light>().color = alpha_color;
                Light_indicator[2].GetComponent<Light>().color = alpha_color;
                Light_indicator[3].GetComponent<Light>().color = alpha_color;
                //LightPrefab.GetComponent<Light>().color = alpha_color;
                if (chosenMuseData != null && chosenMuseData.Length >= 4)  // If there is signal from Muse headband
                {
                    Cube_indicator[0].transform.localScale = new Vector3(Cube_indicator[0].transform.localScale.x, chosenMuseData[0], Cube_indicator[0].transform.localScale.z);
                    Cube_indicator[1].transform.localScale = new Vector3(Cube_indicator[1].transform.localScale.x, chosenMuseData[1], Cube_indicator[1].transform.localScale.z);
                    Cube_indicator[2].transform.localScale = new Vector3(Cube_indicator[2].transform.localScale.x, chosenMuseData[2], Cube_indicator[2].transform.localScale.z);
                    Cube_indicator[3].transform.localScale = new Vector3(Cube_indicator[3].transform.localScale.x, chosenMuseData[3], Cube_indicator[3].transform.localScale.z);

                    Light_indicator[0].GetComponent<Light>().intensity = chosenMuseData[0] * maxLightIntensity;
                    Light_indicator[1].GetComponent<Light>().intensity = chosenMuseData[1] * maxLightIntensity;
                    Light_indicator[2].GetComponent<Light>().intensity = chosenMuseData[2] * maxLightIntensity;
                    Light_indicator[3].GetComponent<Light>().intensity = chosenMuseData[3] * maxLightIntensity;
                }
                return;
            case 1:
                chosenMuseData = MuseRecieve.GetComponent<MuseRecieve>().beta_relative;
                CubeMaterial.color = beta_color;
                Light_indicator[0].GetComponent<Light>().color = beta_color;
                Light_indicator[1].GetComponent<Light>().color = beta_color;
                Light_indicator[2].GetComponent<Light>().color = beta_color;
                Light_indicator[3].GetComponent<Light>().color = beta_color;
                //LightPrefab.GetComponent<Light>().color = beta_color;
                if (chosenMuseData != null && chosenMuseData.Length >= 4)  // If there is signal from Muse headband
                {
                    Cube_indicator[0].transform.localScale = new Vector3(Cube_indicator[0].transform.localScale.x, chosenMuseData[0], Cube_indicator[0].transform.localScale.z);
                    Cube_indicator[1].transform.localScale = new Vector3(Cube_indicator[1].transform.localScale.x, chosenMuseData[1], Cube_indicator[1].transform.localScale.z);
                    Cube_indicator[2].transform.localScale = new Vector3(Cube_indicator[2].transform.localScale.x, chosenMuseData[2], Cube_indicator[2].transform.localScale.z);
                    Cube_indicator[3].transform.localScale = new Vector3(Cube_indicator[3].transform.localScale.x, chosenMuseData[3], Cube_indicator[3].transform.localScale.z);

                    Light_indicator[0].GetComponent<Light>().intensity = chosenMuseData[0] * maxLightIntensity;
                    Light_indicator[1].GetComponent<Light>().intensity = chosenMuseData[1] * maxLightIntensity;
                    Light_indicator[2].GetComponent<Light>().intensity = chosenMuseData[2] * maxLightIntensity;
                    Light_indicator[3].GetComponent<Light>().intensity = chosenMuseData[3] * maxLightIntensity;
                }
                return;
            case 2:
                chosenMuseData = MuseRecieve.GetComponent<MuseRecieve>().delta_relative;
                CubeMaterial.color = delta_color;
                Light_indicator[0].GetComponent<Light>().color = delta_color;
                Light_indicator[1].GetComponent<Light>().color = delta_color;
                Light_indicator[2].GetComponent<Light>().color = delta_color;
                Light_indicator[3].GetComponent<Light>().color = delta_color;
                //LightPrefab.GetComponent<Light>().color = delta_color;
                if (chosenMuseData != null && chosenMuseData.Length >= 4)  // If there is signal from Muse headband
                {
                    Cube_indicator[0].transform.localScale = new Vector3(Cube_indicator[0].transform.localScale.x, chosenMuseData[0], Cube_indicator[0].transform.localScale.z);
                    Cube_indicator[1].transform.localScale = new Vector3(Cube_indicator[1].transform.localScale.x, chosenMuseData[1], Cube_indicator[1].transform.localScale.z);
                    Cube_indicator[2].transform.localScale = new Vector3(Cube_indicator[2].transform.localScale.x, chosenMuseData[2], Cube_indicator[2].transform.localScale.z);
                    Cube_indicator[3].transform.localScale = new Vector3(Cube_indicator[3].transform.localScale.x, chosenMuseData[3], Cube_indicator[3].transform.localScale.z);

                    Light_indicator[0].GetComponent<Light>().intensity = chosenMuseData[0] * maxLightIntensity;
                    Light_indicator[1].GetComponent<Light>().intensity = chosenMuseData[1] * maxLightIntensity;
                    Light_indicator[2].GetComponent<Light>().intensity = chosenMuseData[2] * maxLightIntensity;
                    Light_indicator[3].GetComponent<Light>().intensity = chosenMuseData[3] * maxLightIntensity;
                }
                return;
            case 3:
                chosenMuseData = MuseRecieve.GetComponent<MuseRecieve>().theta_relative;
                CubeMaterial.color = theta_color;
                Light_indicator[0].GetComponent<Light>().color = theta_color;
                Light_indicator[1].GetComponent<Light>().color = theta_color;
                Light_indicator[2].GetComponent<Light>().color = theta_color;
                Light_indicator[3].GetComponent<Light>().color = theta_color;
                //LightPrefab.GetComponent<Light>().color = theta_color;
                if (chosenMuseData != null && chosenMuseData.Length >= 4)  // If there is signal from Muse headband
                {
                    Cube_indicator[0].transform.localScale = new Vector3(Cube_indicator[0].transform.localScale.x, chosenMuseData[0], Cube_indicator[0].transform.localScale.z);
                    Cube_indicator[1].transform.localScale = new Vector3(Cube_indicator[1].transform.localScale.x, chosenMuseData[1], Cube_indicator[1].transform.localScale.z);
                    Cube_indicator[2].transform.localScale = new Vector3(Cube_indicator[2].transform.localScale.x, chosenMuseData[2], Cube_indicator[2].transform.localScale.z);
                    Cube_indicator[3].transform.localScale = new Vector3(Cube_indicator[3].transform.localScale.x, chosenMuseData[3], Cube_indicator[3].transform.localScale.z);

                    Light_indicator[0].GetComponent<Light>().intensity = chosenMuseData[0] * maxLightIntensity;
                    Light_indicator[1].GetComponent<Light>().intensity = chosenMuseData[1] * maxLightIntensity;
                    Light_indicator[2].GetComponent<Light>().intensity = chosenMuseData[2] * maxLightIntensity;
                    Light_indicator[3].GetComponent<Light>().intensity = chosenMuseData[3] * maxLightIntensity;
                }
                return;
            case 4:
                chosenMuseData = MuseRecieve.GetComponent<MuseRecieve>().gamma_relative;
                CubeMaterial.color = gamma_color;
                Light_indicator[0].GetComponent<Light>().color = gamma_color;
                Light_indicator[1].GetComponent<Light>().color = gamma_color;
                Light_indicator[2].GetComponent<Light>().color = gamma_color;
                Light_indicator[3].GetComponent<Light>().color = gamma_color;
                //LightPrefab.GetComponent<Light>().color = gamma_color;
                if (chosenMuseData != null && chosenMuseData.Length >= 4)  // If there is signal from Muse headband
                {
                    Cube_indicator[0].transform.localScale = new Vector3(Cube_indicator[0].transform.localScale.x, chosenMuseData[0], Cube_indicator[0].transform.localScale.z);
                    Cube_indicator[1].transform.localScale = new Vector3(Cube_indicator[1].transform.localScale.x, chosenMuseData[1], Cube_indicator[1].transform.localScale.z);
                    Cube_indicator[2].transform.localScale = new Vector3(Cube_indicator[2].transform.localScale.x, chosenMuseData[2], Cube_indicator[2].transform.localScale.z);
                    Cube_indicator[3].transform.localScale = new Vector3(Cube_indicator[3].transform.localScale.x, chosenMuseData[3], Cube_indicator[3].transform.localScale.z);

                    Light_indicator[0].GetComponent<Light>().intensity = chosenMuseData[0] * maxLightIntensity;
                    Light_indicator[1].GetComponent<Light>().intensity = chosenMuseData[1] * maxLightIntensity;
                    Light_indicator[2].GetComponent<Light>().intensity = chosenMuseData[2] * maxLightIntensity;
                    Light_indicator[3].GetComponent<Light>().intensity = chosenMuseData[3] * maxLightIntensity;
                }
                return;
            case 5:
                chosenMuseData = MuseRecieve.GetComponent<MuseRecieve>().alpha_absolute;
                CubeMaterial.color = alpha_color;
                Light_indicator[0].GetComponent<Light>().color = alpha_color;
                Light_indicator[1].GetComponent<Light>().color = alpha_color;
                Light_indicator[2].GetComponent<Light>().color = alpha_color;
                Light_indicator[3].GetComponent<Light>().color = alpha_color;
                //LightPrefab.GetComponent<Light>().color = alpha_color;
                if (chosenMuseData != null && chosenMuseData.Length >= 4)  // If there is signal from Muse headband
                {
                    Cube_indicator[0].transform.localScale = new Vector3(Cube_indicator[0].transform.localScale.x, chosenMuseData[0], Cube_indicator[0].transform.localScale.z);
                    Cube_indicator[1].transform.localScale = new Vector3(Cube_indicator[1].transform.localScale.x, chosenMuseData[1], Cube_indicator[1].transform.localScale.z);
                    Cube_indicator[2].transform.localScale = new Vector3(Cube_indicator[2].transform.localScale.x, chosenMuseData[2], Cube_indicator[2].transform.localScale.z);
                    Cube_indicator[3].transform.localScale = new Vector3(Cube_indicator[3].transform.localScale.x, chosenMuseData[3], Cube_indicator[3].transform.localScale.z);

                    Light_indicator[0].GetComponent<Light>().intensity = chosenMuseData[0] * maxLightIntensity;
                    Light_indicator[1].GetComponent<Light>().intensity = chosenMuseData[1] * maxLightIntensity;
                    Light_indicator[2].GetComponent<Light>().intensity = chosenMuseData[2] * maxLightIntensity;
                    Light_indicator[3].GetComponent<Light>().intensity = chosenMuseData[3] * maxLightIntensity;
                }
                return;
            case 6:
                chosenMuseData = MuseRecieve.GetComponent<MuseRecieve>().beta_absolute;
                CubeMaterial.color = beta_color;
                Light_indicator[0].GetComponent<Light>().color = beta_color;
                Light_indicator[1].GetComponent<Light>().color = beta_color;
                Light_indicator[2].GetComponent<Light>().color = beta_color;
                Light_indicator[3].GetComponent<Light>().color = beta_color;
                //LightPrefab.GetComponent<Light>().color = beta_color;
                if (chosenMuseData != null && chosenMuseData.Length >= 4)  // If there is signal from Muse headband
                {
                    Cube_indicator[0].transform.localScale = new Vector3(Cube_indicator[0].transform.localScale.x, chosenMuseData[0], Cube_indicator[0].transform.localScale.z);
                    Cube_indicator[1].transform.localScale = new Vector3(Cube_indicator[1].transform.localScale.x, chosenMuseData[1], Cube_indicator[1].transform.localScale.z);
                    Cube_indicator[2].transform.localScale = new Vector3(Cube_indicator[2].transform.localScale.x, chosenMuseData[2], Cube_indicator[2].transform.localScale.z);
                    Cube_indicator[3].transform.localScale = new Vector3(Cube_indicator[3].transform.localScale.x, chosenMuseData[3], Cube_indicator[3].transform.localScale.z);

                    Light_indicator[0].GetComponent<Light>().intensity = chosenMuseData[0] * maxLightIntensity;
                    Light_indicator[1].GetComponent<Light>().intensity = chosenMuseData[1] * maxLightIntensity;
                    Light_indicator[2].GetComponent<Light>().intensity = chosenMuseData[2] * maxLightIntensity;
                    Light_indicator[3].GetComponent<Light>().intensity = chosenMuseData[3] * maxLightIntensity;
                }
                return;
            case 7:
                chosenMuseData = MuseRecieve.GetComponent<MuseRecieve>().delta_absolute;
                CubeMaterial.color = delta_color;
                Light_indicator[0].GetComponent<Light>().color = delta_color;
                Light_indicator[1].GetComponent<Light>().color = delta_color;
                Light_indicator[2].GetComponent<Light>().color = delta_color;
                Light_indicator[3].GetComponent<Light>().color = delta_color;
                //LightPrefab.GetComponent<Light>().color = delta_color;
                if (chosenMuseData != null && chosenMuseData.Length >= 4)  // If there is signal from Muse headband
                {
                    Cube_indicator[0].transform.localScale = new Vector3(Cube_indicator[0].transform.localScale.x, chosenMuseData[0], Cube_indicator[0].transform.localScale.z);
                    Cube_indicator[1].transform.localScale = new Vector3(Cube_indicator[1].transform.localScale.x, chosenMuseData[1], Cube_indicator[1].transform.localScale.z);
                    Cube_indicator[2].transform.localScale = new Vector3(Cube_indicator[2].transform.localScale.x, chosenMuseData[2], Cube_indicator[2].transform.localScale.z);
                    Cube_indicator[3].transform.localScale = new Vector3(Cube_indicator[3].transform.localScale.x, chosenMuseData[3], Cube_indicator[3].transform.localScale.z);

                    Light_indicator[0].GetComponent<Light>().intensity = chosenMuseData[0] * maxLightIntensity;
                    Light_indicator[1].GetComponent<Light>().intensity = chosenMuseData[1] * maxLightIntensity;
                    Light_indicator[2].GetComponent<Light>().intensity = chosenMuseData[2] * maxLightIntensity;
                    Light_indicator[3].GetComponent<Light>().intensity = chosenMuseData[3] * maxLightIntensity;
                }
                return;
            case 8:
                chosenMuseData = MuseRecieve.GetComponent<MuseRecieve>().theta_absolute;
                CubeMaterial.color = theta_color;
                Light_indicator[0].GetComponent<Light>().color = theta_color;
                Light_indicator[1].GetComponent<Light>().color = theta_color;
                Light_indicator[2].GetComponent<Light>().color = theta_color;
                Light_indicator[3].GetComponent<Light>().color = theta_color;
                //LightPrefab.GetComponent<Light>().color = theta_color;
                if (chosenMuseData != null && chosenMuseData.Length >= 4)  // If there is signal from Muse headband
                {
                    Cube_indicator[0].transform.localScale = new Vector3(Cube_indicator[0].transform.localScale.x, chosenMuseData[0], Cube_indicator[0].transform.localScale.z);
                    Cube_indicator[1].transform.localScale = new Vector3(Cube_indicator[1].transform.localScale.x, chosenMuseData[1], Cube_indicator[1].transform.localScale.z);
                    Cube_indicator[2].transform.localScale = new Vector3(Cube_indicator[2].transform.localScale.x, chosenMuseData[2], Cube_indicator[2].transform.localScale.z);
                    Cube_indicator[3].transform.localScale = new Vector3(Cube_indicator[3].transform.localScale.x, chosenMuseData[3], Cube_indicator[3].transform.localScale.z);

                    Light_indicator[0].GetComponent<Light>().intensity = chosenMuseData[0] * maxLightIntensity;
                    Light_indicator[1].GetComponent<Light>().intensity = chosenMuseData[1] * maxLightIntensity;
                    Light_indicator[2].GetComponent<Light>().intensity = chosenMuseData[2] * maxLightIntensity;
                    Light_indicator[3].GetComponent<Light>().intensity = chosenMuseData[3] * maxLightIntensity;
                }
                return;
            case 9:
                chosenMuseData = MuseRecieve.GetComponent<MuseRecieve>().gamma_absolute;
                CubeMaterial.color = gamma_color;
                Light_indicator[0].GetComponent<Light>().color = gamma_color;
                Light_indicator[1].GetComponent<Light>().color = gamma_color;
                Light_indicator[2].GetComponent<Light>().color = gamma_color;
                Light_indicator[3].GetComponent<Light>().color = gamma_color;
                //LightPrefab.GetComponent<Light>().color = gamma_color;
                if (chosenMuseData != null && chosenMuseData.Length >= 4)  // If there is signal from Muse headband
                {
                    Cube_indicator[0].transform.localScale = new Vector3(Cube_indicator[0].transform.localScale.x, chosenMuseData[0], Cube_indicator[0].transform.localScale.z);
                    Cube_indicator[1].transform.localScale = new Vector3(Cube_indicator[1].transform.localScale.x, chosenMuseData[1], Cube_indicator[1].transform.localScale.z);
                    Cube_indicator[2].transform.localScale = new Vector3(Cube_indicator[2].transform.localScale.x, chosenMuseData[2], Cube_indicator[2].transform.localScale.z);
                    Cube_indicator[3].transform.localScale = new Vector3(Cube_indicator[3].transform.localScale.x, chosenMuseData[3], Cube_indicator[3].transform.localScale.z);

                    Light_indicator[0].GetComponent<Light>().intensity = chosenMuseData[0] * maxLightIntensity;
                    Light_indicator[1].GetComponent<Light>().intensity = chosenMuseData[1] * maxLightIntensity;
                    Light_indicator[2].GetComponent<Light>().intensity = chosenMuseData[2] * maxLightIntensity;
                    Light_indicator[3].GetComponent<Light>().intensity = chosenMuseData[3] * maxLightIntensity;
                }
                return;

        }
         
    }

    public void ChangeMuseData()
    {
        dropdownValue = DropdownToChooseMuseData.value;
    }
}
