using UnityEngine;
using System.Collections.Generic;

public class RandomCubeSpawner_zad1_lab4 : MonoBehaviour
{
    public GameObject cubePrefab;      // Referencja do Prefabu Cube
    public int cubeCount = 10;         // Liczba generowanych Cube'ów
    public float delay = 1.0f;         // Opóźnienie między generowaniem kolejnych Cube'ów
    public Material[] materials;       // Tablica materiałów do losowego przydzielania

    private List<Vector3> usedPositions = new List<Vector3>();  // Lista pozycji, gdzie są już Cube'y
    private Bounds platformBounds;     // Granice platformy

    void Start()
    {
        // Uzyskaj granice platformy na podstawie jej renderera
        platformBounds = GetComponent<Renderer>().bounds;
        StartCoroutine(GenerateCubesWithDelay());
    }

    IEnumerator<WaitForSeconds> GenerateCubesWithDelay()
    {
        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            GameObject newCube = Instantiate(cubePrefab, randomPosition, Quaternion.identity);

            // Przypisanie losowego materiału do nowo wygenerowanego Cube'a
            Material randomMaterial = materials[Random.Range(0, materials.Length)];
            newCube.GetComponent<Renderer>().material = randomMaterial;

            // Dodaj pozycję do listy zajętych
            usedPositions.Add(randomPosition);

            // Odczekaj zadany czas przed generowaniem kolejnego obiektu
            yield return new WaitForSeconds(delay);
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition;
        do
        {
            // Losujemy pozycję w zakresie granic platformy
            float x = Random.Range(platformBounds.min.x, platformBounds.max.x);
            float z = Random.Range(platformBounds.min.z, platformBounds.max.z);
            randomPosition = new Vector3(x, platformBounds.center.y + 0.5f, z);
        }
        while (PositionUsed(randomPosition));  // Sprawdzamy, czy pozycja jest już zajęta

        return randomPosition;
    }

    bool PositionUsed(Vector3 position)
    {
        // Sprawdzamy, czy losowana pozycja jest blisko innej już użytej pozycji
        foreach (var usedPosition in usedPositions)
        {
            if (Vector3.Distance(position, usedPosition) < 1)  // Minimalna odległość między obiektami
            {
                return true;
            }
        }
        return false;
    }
}
