using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab4_zad1 : MonoBehaviour
{
    private List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f; // Czas opóźnienia między generowaniem obiektów
    public int objectCount = 10; // Liczba obiektów do wygenerowania
    private int objectCounter = 0; // Licznik obiektów
    public GameObject block; // Prefab obiektu do generowania
    public Material[] materials; // Tablica materiałów do losowego przydzielania

    void Start()
    {
        // Pobieranie rozmiaru platformy
        Bounds platformBounds = GetComponent<Renderer>().bounds;
        float minX = platformBounds.min.x;
        float maxX = platformBounds.max.x;
        float minZ = platformBounds.min.z;
        float maxZ = platformBounds.max.z;

        // Generowanie losowych pozycji w obrębie platformy
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition;
            do
            {
                float xPos = Random.Range(minX, maxX);
                float zPos = Random.Range(minZ, maxZ);
                randomPosition = new Vector3(xPos, platformBounds.center.y + 0.5f, zPos);
            }
            while (positions.Contains(randomPosition));

            positions.Add(randomPosition);
        }

        // Uruchamiamy coroutine do generowania obiektów
        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(block, pos, Quaternion.identity);

            // Przydzielanie losowego materiału do nowego obiektu
            if (materials.Length > 0)
            {
                Material randomMaterial = materials[Random.Range(0, materials.Length)];
                newBlock.GetComponent<Renderer>().material = randomMaterial;
            }

            objectCounter++;
            yield return new WaitForSeconds(delay);
        }

        // Zatrzymujemy coroutine po wygenerowaniu wszystkich obiektów
        StopCoroutine(GenerujObiekt());
    }
}
