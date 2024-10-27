using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public float moveSpeed = 2f; // Prędkość ruchu obiektu

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Ruch w poziomie
        float moveVertical = Input.GetAxis("Vertical"); // Ruch w pionie

        // Przesuwanie obiektu w kierunku wejścia
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.position += movement * moveSpeed * Time.deltaTime; // Przemieszczenie
    }
}

