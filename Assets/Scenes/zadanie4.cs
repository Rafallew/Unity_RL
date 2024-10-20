using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Prędkość poruszania się gracza

    void Update()
    {
        // Pobieranie wejścia z klawiatury (W, A, S, D lub strzałki)
        float moveHorizontal = Input.GetAxis("Horizontal"); // Oś X (A/D lub strzałki w lewo/prawo)
        float moveVertical = Input.GetAxis("Vertical"); // Oś Z (W/S lub strzałki w górę/dół)

        // Tworzenie wektora ruchu na podstawie wejścia z klawiatury
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Przemieszczanie gracza po płaszczyźnie
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
