using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Program : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    CameraShake cameraShake;
    AudioSource matchSound;

    internal GameObject clickedObject;
    internal List<GameObject> clickedObjects;

    int score = 1;

    void Start()
    {
        matchSound = GameObject.Find("MatchSound").GetComponent<AudioSource>();
        cameraShake = FindObjectOfType<CameraShake>();
        clickedObjects = new List<GameObject>();
    }

    private void Update() => CheckForMatch();

    void CheckForMatch()
    {
        if (clickedObjects.Count == 2)
        {
            if (IsMatch(clickedObjects))
            {
                ScoreUp();
                matchSound.Play();
            }
            else cameraShake.Play();

            DisableClickedPair();
        }
    }

    bool IsMatch(List<GameObject> clickedObjects) => clickedObjects[0].name == clickedObjects[1].name;

    void ScoreUp() => scoreText.text = $"Score: {score++}";

    void DisableClickedPair()
    {
        Destroy(clickedObjects[0].GetComponent<Image>(), .3f);
        Destroy(clickedObjects[1].GetComponent<Image>(), .3f);
        clickedObjects = new List<GameObject>();
    }
}
