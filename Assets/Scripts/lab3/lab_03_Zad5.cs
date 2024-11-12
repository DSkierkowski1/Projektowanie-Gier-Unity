using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab_03_Zad5 : MonoBehaviour
{
    public GameObject cubePrefab;
    public int cubeCount = 10;
    private float planeSize = 5f;

    private List<Vector3> occupiedPositions = new List<Vector3>();
    void Start()
    {
        SpawnCubes();
    }
    void SpawnCubes()
    {
        int spawnedCubes = 0;
        
        while (spawnedCubes < cubeCount)
        {
            float xPos = Random.Range(-planeSize, planeSize);
            float zPos = Random.Range(-planeSize, planeSize);
            Vector3 randomPosition = new Vector3(xPos, 0.5f, zPos);

            if (!occupiedPositions.Contains(randomPosition))
            {
                Instantiate(cubePrefab, randomPosition, Quaternion.identity);
                occupiedPositions.Add(randomPosition);
                spawnedCubes++;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
