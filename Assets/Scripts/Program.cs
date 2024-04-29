using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Program : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    CameraShake cameraShake;
    GameBoard gameBoard;

    internal GameObject clickedObject;
    internal List<GameObject> clickedObjects;

    int score = 0;

    void Start()
    {
        cameraShake = FindObjectOfType<CameraShake>();
        gameBoard = FindObjectOfType<GameBoard>();
        clickedObjects = new List<GameObject>();
    }

    private void Update() => CheckForMatch();

    void CheckForMatch()
    {
        if (clickedObjects.Count == 2)
        {
            if (clickedObjects[0].name == clickedObjects[1].name)
            {
                score++;
                scoreText.text = "Score: " + score.ToString();
                GameObject.Find("MatchSound").GetComponent<AudioSource>().Play();
            }
            else cameraShake.Play();

            Destroy(clickedObjects[0], .3f);
            Destroy(clickedObjects[1], .3f);
            clickedObjects = new List<GameObject>();
        }
    }
}
