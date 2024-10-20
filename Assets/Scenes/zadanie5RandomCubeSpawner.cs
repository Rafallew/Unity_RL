using UnityEngine;
using System.Collections.Generic; // Potrzebne do korzystania z List

public class RandomCubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;  // Referencja do Prefabu Cube
    public int cubeCount = 10;     // Liczba generowanych Cube'ów
    public Vector2 planeSize = new Vector2(10, 10); // Wymiary płaszczyzny (10x10)

    private List<Vector3> usedPositions = new List<Vector3>(); // Lista pozycji, gdzie są już Cube'y

    void Start()
    {
        GenerateCubes();
    }

    void GenerateCubes()
    {
        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition;
        do
        {
            // Losujemy pozycję w zakresie płaszczyzny 10x10
            float x = Random.Range(-planeSize.x / 2, planeSize.x / 2);
            float z = Random.Range(-planeSize.y / 2, planeSize.y / 2);
            randomPosition = new Vector3(x, 0.5f, z); // 0.5f to wysokość Cube'a nad płaszczyzną
        }
        while (PositionUsed(randomPosition)); // Sprawdzamy, czy pozycja jest już zajęta

        // Dodajemy pozycję do listy zajętych
        usedPositions.Add(randomPosition);
        return randomPosition;
    }

    bool PositionUsed(Vector3 position)
    {
        // Sprawdzamy, czy losowana pozycja jest blisko innej już użytej pozycji
        foreach (var usedPosition in usedPositions)
        {
            if (Vector3.Distance(position, usedPosition) < 1) // Odległość minimalna 1 jednostka
            {
                return true;
            }
        }
        return false;
    }
}
