using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public Button CalibrateButton;
    public Button StartTheGameButton;

    public GameObject WelcomeMenu;
    public GameObject CalibrationMenu;
    public GameObject LevelCanvas;
    public GameObject Objects;

    public GameObject CalibrationPlusCSV;
    public GameObject ResultsOfCalibrationWaiter;
    public GameObject OSCController;

    public GameObject GameController;

    public Text AccuracyText;



    // Use this for initialization
    void Start () {
        Objects.SetActive(false);
        LevelCanvas.SetActive(false);
        CalibrationMenu.SetActive(false);
        WelcomeMenu.SetActive(true);
        OSCController.SetActive(true);
        CalibrateButton.GetComponent<Button>().onClick.AddListener(CalibrationStart);
        StartTheGameButton.GetComponent<Button>().onClick.AddListener(StartPython);
	}

    
    void CalibrationStart()
    {
        WelcomeMenu.SetActive(false);
        CalibrationMenu.SetActive(true);
        CalibrationPlusCSV.SetActive(true);
    }

    void StartPython()
    {
        ResultsOfCalibrationWaiter.SetActive(true);
    }

    public void StartGame(string accuracy)
    {
        AccuracyText.text = (accuracy);
        WelcomeMenu.SetActive(false);
        CalibrationMenu.SetActive(false);
        LevelCanvas.SetActive(true);
        GameController.SetActive(true);
        Objects.SetActive(true);
    }

    void Update()
    {
     
    }
}
