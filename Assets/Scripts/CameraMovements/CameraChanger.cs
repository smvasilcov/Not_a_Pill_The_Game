using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour {

    public GameObject FirstCamera;
    public GameObject SecondCamera;
    public GameObject ThirdCamera;
    public GameObject ForthCamera;
    public GameObject FifthCamera;
    public GameObject Rocket;

    private float altitude = 0;

    void Start ()
    {
        FirstCamera.SetActive(true);
        SecondCamera.SetActive(false);
        ThirdCamera.SetActive(false);
        ForthCamera.SetActive(false);
        FifthCamera.SetActive(false);

	}
	
	void Update ()
    {
        altitude = Rocket.transform.position.y;
        Debug.Log(altitude);
        if (altitude <= 6)
        {
            FirstCamera.SetActive(true);
            SecondCamera.SetActive(false);
        }
        if (altitude > 6 && altitude <= 12)
        {
            SecondCamera.SetActive(true);
            FirstCamera.SetActive(false);
            ThirdCamera.SetActive(false);
        }
        if(altitude > 12 && altitude <= 23)
        {
            ThirdCamera.SetActive(true);
            SecondCamera.SetActive(false);
            ForthCamera.SetActive(false);
        }
        if (altitude > 23 && altitude <= 47)
        {
            ForthCamera.SetActive(true);
            ThirdCamera.SetActive(false);
            FifthCamera.SetActive(false);
        }
        if (altitude > 47 && altitude <= 72)
        {
            FifthCamera.SetActive(true);
            ForthCamera.SetActive(false);
            
        }
        if (altitude > 72 && altitude <= 500)
        {
            FifthCamera.transform.position = new Vector3(FifthCamera.transform.position.x, Rocket.transform.position.y, FifthCamera.transform.position.z);
        }

    }
}
