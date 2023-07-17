using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float _initialPositionX, _initialPositionZ;
    private Rigidbody _rigidBody;
    private Vector3 _impulse;
    private float _velocity = 5f;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

        _initialPositionX = transform.position.x;
        _initialPositionZ = transform.position.z;
    }

    void Update()
    {
        _impulse = new Vector3(transform.position.x + _velocity, transform.position.y, transform.position.z + _velocity);
        _rigidBody.AddForce(_impulse, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Programar que al colisionar con cualquier cosa se cambie su direccion
    }
}