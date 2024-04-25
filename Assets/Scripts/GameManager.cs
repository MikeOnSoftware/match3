using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject portraitCanvas;
    [SerializeField] GameObject landscapeCanvas;

    string startOrientationState;
    string orientationState;

    void Awake()
    {
        OrientationSet();
        startOrientationState = orientationState;
    }

    // Update is called once per frame
    void Update()
    {
        if (OrientationChanged())
        {
            Debug.Log(orientationState);
            OnRestart();
        }
        OrientationSet();
    }

    void OrientationSet()
    {
        if (Input.deviceOrientation == DeviceOrientation.Portrait && orientationState != "portrait")
        {
            orientationState = "portrait";
            portraitCanvas.SetActive(true);
            landscapeCanvas.SetActive(false);
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft && orientationState != "landscape left")
        {
            orientationState = "landscape left";
            landscapeCanvas.SetActive(true);
            portraitCanvas.SetActive(false);
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight && orientationState != "landscape right")
        {
            orientationState = "landscape right";
            landscapeCanvas.SetActive(true);
            portraitCanvas.SetActive(false);
        }
    }
    internal bool OrientationChanged()
    {        
        return orientationState != startOrientationState;
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
