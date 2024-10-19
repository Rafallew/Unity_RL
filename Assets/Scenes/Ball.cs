using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
        // Publiczne pole do ustawienia prędkości
    public float speed = 2f;
        // Prywatne zmienne
    private bool movingRight = true;
    private float startPositionX;
    private float targetPositionX = 10f;
    // Start is called before the first frame update
    void Start()
    {
                // Zapamiętujemy początkową pozycję X
        startPositionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
                // Sprawdzamy kierunek ruchu
        if (movingRight)
        {
            // Ruch w prawo
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            // Jeśli osiągnięto 10 jednostek od startu, zmieniamy kierunek
            if (transform.position.x >= startPositionX + targetPositionX)
            {
                movingRight = false;
            }
        }
        else
        {
            // Ruch w lewo (powrót)
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            // Jeśli wrócimy do pozycji początkowej, znowu ruszamy w prawo
            if (transform.position.x <= startPositionX)
            {
                movingRight = true;
            }
        }
    }
}
