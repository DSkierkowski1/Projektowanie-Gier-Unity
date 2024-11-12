using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab_03_Zad1 : MonoBehaviour
{
    public float speed = 1f;
    private float startX;
    private bool movingRight = true;
    private float moveDistance = 10f;
    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x >= startX + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x <= startX)
            {
                movingRight = true;
            }
        } 
    }
}
