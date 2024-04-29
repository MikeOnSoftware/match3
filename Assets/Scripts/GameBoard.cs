using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] int row;
    [SerializeField] int col;

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
        for (int x = 0; x < row; x++)
        {
            for (int y = 0; y < col; y++)
            {
                Vector3 position = new Vector3(x , y , 0);
                GameObject tile = Instantiate(GetRandomTilePrefab(), position, Quaternion.identity) as GameObject;
                tile.transform.parent = this.transform;
                tiles[x, y] = tile;
            }
        }
        foreach (var tile in tilePrefabs)
        {
            Destroy(tile);
        }
    }
    GameObject GetRandomTilePrefab() => tilePrefabs[Random.Range(0, tilePrefabs.Length)];
}
