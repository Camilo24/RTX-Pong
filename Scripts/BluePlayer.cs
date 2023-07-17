using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayer : MonoBehaviour
{
    void Update()
    {
        CalculateMovement();

        if (transform.position.x <= -19.5)
        {
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = new Vector3(-19.5f, currentPosition.y, currentPosition.z);
            transform.position = newPosition;
        }

        if (transform.position.x >= 30.2)
        {
            Vector3 currentPosition = transform.position;
            Vector3 newPosition = new Vector3(30.2f, currentPosition.y, currentPosition.z);
            transform.position = newPosition;
        }
    }

    void CalculateMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(currentPosition.x + 1f, currentPosition.y, currentPosition.z);
        transform.position = newPosition;
    }

    void MoveDown()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(currentPosition.x - 1f, currentPosition.y, currentPosition.z);
        transform.position = newPosition;
    }
}
