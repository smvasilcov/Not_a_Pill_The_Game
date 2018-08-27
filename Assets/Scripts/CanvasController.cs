using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public Button CalibrateButton;
    public Button StartTheGameButton;

    public GameObject WelcomeMenu;
    public GameObject CalibrationMenu;
    public GameObject Objects;

    public GameObject CalibrationPlusCSV;
    public GameObject ResultsOfCalibrationWaiter;
    public GameObject OSCController;

   

    // Use this for initialization
    void Start () {
        Objects.SetActive(false);
        CalibrationMenu.SetActive(false);
        WelcomeMenu.SetActive(true);
        OSCController.SetActive(true);
        CalibrateButton.GetComponent<Button>().onClick.AddListener(CalibrationStart);
        StartTheGameButton.GetComponent<Button>().onClick.AddListener(StartGame);
	}

    
    void CalibrationStart()
    {
        WelcomeMenu.SetActive(false);
        CalibrationMenu.SetActive(true);
        CalibrationPlusCSV.SetActive(true);
    }

    void StartGame()
    {
        ResultsOfCalibrationWaiter.SetActive(true);
    }

    void Update()
    {
     
    }
}
