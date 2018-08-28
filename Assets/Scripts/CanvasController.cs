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
    public GameObject StateRecordingPanel;

    public GameObject CalibrationPlusCSV;
    public GameObject ResultsOfCalibrationWaiter;
    public GameObject OSCController;

    public GameObject GameController;

    public Text AccuracyText;



    // Use this for initialization
    public void Start () {
        Objects.SetActive(false);
        LevelCanvas.SetActive(false);
        CalibrationMenu.SetActive(false);
        WelcomeMenu.SetActive(true);
        OSCController.SetActive(true);
        StateRecordingPanel.SetActive(false);
        CalibrateButton.GetComponent<Button>().onClick.AddListener(CalibrationStart);
        StartTheGameButton.GetComponent<Button>().onClick.AddListener(StartPython);
	}

    
    public void CalibrationStart()
    {
        WelcomeMenu.SetActive(false);
        LevelCanvas.SetActive(false);
        CalibrationMenu.SetActive(true);
        CalibrationPlusCSV.SetActive(true);
    }

    void StartPython()
    {
        ResultsOfCalibrationWaiter.SetActive(true);
    }

    public void StartGame(string accuracy)
    {
        Debug.Log("Start Game");
        AccuracyText.text = (accuracy);
        CalibrationPlusCSV.SetActive(false);
        ResultsOfCalibrationWaiter.SetActive(false);
        WelcomeMenu.SetActive(false);
        CalibrationMenu.SetActive(false);
        StateRecordingPanel.SetActive(false);
        LevelCanvas.SetActive(true);
        GameController.SetActive(true);
        Objects.SetActive(true);
    }

    public void RecordState()
    {
        Debug.Log("Record state code");
        StateRecordingPanel.SetActive(true);
        CalibrationPlusCSV.SetActive(true);
    }

    void Update()
    {
     
    }
}
