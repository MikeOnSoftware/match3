using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Program : MonoBehaviour
{
    [SerializeField] internal int width;
    [SerializeField] internal int height;
    [SerializeField] GameObject[] tilePrefabs;
    [SerializeField] GameObject[] hiders;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject restartButton;

    CameraShake cameraShake;
    GameObject[,] tiles;

    internal GameObject clickedObject;
    internal List<GameObject> clickedObjects;

    int score = 0;

    void Start()
    {
        cameraShake = FindObjectOfType<CameraShake>();

        tiles = new GameObject[width, height];
        SetupGameBoard();
        clickedObjects = new List<GameObject>();
    }

    private void Update() => CheckForMatch();

    void SetupGameBoard()
    {
        float tileWidth = tilePrefabs[0].GetComponent<RectTransform>().sizeDelta.x;
        float tileHeight = tilePrefabs[0].GetComponent<RectTransform>().sizeDelta.y;
        float xOffset = tileWidth;
        float yOffset = tileHeight;

        for (int x = 0; x < width; x++)
        {
            xOffset *= (2 + x);
            for (int y = 0; y < height; y++)
            {
                yOffset *= (2 + y);

                Vector3 position = new Vector3(x + xOffset, y + yOffset, 0);
                GameObject tile = Instantiate(GetRandomTilePrefab(), position, Quaternion.identity) as GameObject;
                tile.transform.parent = this.transform;
                tiles[x, y] = tile;

                yOffset = tileHeight;
            }
            xOffset = tileWidth;
        }
        foreach (var tile in tilePrefabs)
        {
            Destroy(tile);
        }
    }

    GameObject GetRandomTilePrefab() => tilePrefabs[Random.Range(0, tilePrefabs.Length)];

    void CheckForMatch()
    {
        if (clickedObjects.Count == 2)
        {
            if (clickedObjects[0].name == clickedObjects[1].name)
            {
                score++;
                Debug.Log(score);
                scoreText.text = "Score: " + score.ToString();
                GameObject.Find("MatchSound").GetComponent<AudioSource>().Play();
            }
            else
            {
                cameraShake.Play();
            }
            Destroy(clickedObjects[0], .3f);
            Destroy(clickedObjects[1], .3f);
            clickedObjects = new List<GameObject>();
        }
    }
}