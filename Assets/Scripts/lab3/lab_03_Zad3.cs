using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab_03_Zad3 : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 startPos;
    private int sideIndex = 0;
    private float sideLength = 10f;
    private bool moving = true;

    void Start()
    {
        startPos = transform.position;        
    }


    void Update()
    {
        if (moving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, startPos + GetSideOffset()) >= sideLength)
            {
                transform.position = startPos + GetSideOffset();
                startPos = transform.position;

                transform.Rotate(0, 90, 0);
                
                sideIndex = (sideIndex + 1) % 4;
            }
        }
    }

    Vector3 GetSideOffset()
    {
        switch (sideIndex)
        {
            case 0: return Vector3.forward * sideLength;
            case 1: return Vector3.right * sideLength;
            case 2: return Vector3.back * sideLength;
            case 3: return Vector3.left * sideLength;
            default: return Vector3.zero;
        }
    }
}
