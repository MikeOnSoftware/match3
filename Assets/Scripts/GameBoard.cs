using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] internal int row;
    [SerializeField] internal int col;
    [SerializeField] GameObject[] tilePrefabs;
    [SerializeField] GameObject[] hiders;

    GameObject[,] tiles;

    // Start is called before the first frame update
    void Start()
    {
        tiles = new GameObject[row, col];
        SetupGameBoard();
    }

    void SetupGameBoard()
    {
        float tileWidth = tilePrefabs[0].GetComponent<RectTransform>().sizeDelta.x;
        float tileHeight = tilePrefabs[0].GetComponent<RectTransform>().sizeDelta.y;
        float xOffset = tileWidth;
        float yOffset = tileHeight;

        for (int x = 0; x < row; x++)
        {
            xOffset *= (2 + x);
            for (int y = 0; y < col; y++)
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

}
