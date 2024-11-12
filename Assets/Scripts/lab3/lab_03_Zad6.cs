using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab_03_Zad6 : MonoBehaviour
{
    public Transform target;
    public bool useSmoothDamp = true;
    private float smoothTime = 0.3f;
    private float yVelocity = 0.0f;
    private float lerpSpeed = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (useSmoothDamp)
        {
            // Użycie SmoothDamp do wygładzania ruchu
            float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
            transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
        }
        else
        {
            // Użycie Lerp do płynnego przesunięcia
            float newPosition = Mathf.Lerp(transform.position.y, target.position.y, lerpSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
        }
    }
}
