using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class FollowTarget : MonoBehaviour
{

    public Transform target; // Obiekt do śledzenia
    public float smoothTime = 0.3f; // Czas wygładzania
    private Vector3 velocity = Vector3.zero; // Prędkość

    void Update()
    {
        // Oblicz nową pozycję wzdłuż osi Y
        float newPositionY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity.y, smoothTime);
        
        // Ustaw nową pozycję obiektu Cube
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
        
        // Użyj Mathf.Lerp, aby wygładzić ruch wzdłuż osi X i Z
        float newPositionX = Mathf.Lerp(transform.position.x, target.position.x, Time.deltaTime * smoothTime);
        float newPositionZ = Mathf.Lerp(transform.position.z, target.position.z, Time.deltaTime * smoothTime);

        // Ustaw nową pozycję Cube na podstawie Lerp
        transform.position = new Vector3(newPositionX, newPositionY, newPositionZ);
    }
}



