using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 2.0f;  // Prędkość ruchu
    private Vector3[] directions; // Tablica kierunków, którymi porusza się Cube
    private int currentDirection = 0; // Aktualny kierunek
    private Vector3 targetPosition; // Docelowa pozycja Cube
    private float distanceToMove = 10.0f; // Odległość do przebycia w jednej osi

    void Start()
    {
        // Definiujemy kierunki "kwadratu" w przestrzeni
        directions = new Vector3[] {
            Vector3.right, // Ruch w prawo (oś X)
            Vector3.forward, // Ruch w głąb (oś Z)
            Vector3.left, // Ruch w lewo (oś X)
            Vector3.back // Ruch w tył (oś Z)
        };

        // Inicjalizacja docelowej pozycji
        targetPosition = transform.position + directions[currentDirection] * distanceToMove;
    }

    void Update()
    {
        // Przemieszczamy Cube w stronę docelowej pozycji
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Sprawdzamy, czy Cube dotarł do wierzchołka kwadratu
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Obracamy Cube o 90 stopni
            transform.Rotate(0, 90, 0);

            // Zmieniamy kierunek ruchu na następny w tablicy directions
            currentDirection = (currentDirection + 1) % directions.Length;

            // Obliczamy nową docelową pozycję
            targetPosition = transform.position + directions[currentDirection] * distanceToMove;
        }
    }
}
