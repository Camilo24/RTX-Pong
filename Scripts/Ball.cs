using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Vector3 _initialPosition;
    private float _velocity = 50f;
    //private float _velocityIncrease = 1.01f;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.AddForce(new Vector3(1, 0, 1) * _velocity, ForceMode.VelocityChange);
    }

    void Update()
    {
        _rigidBody.velocity = _rigidBody.velocity.normalized * _velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 reflectDirection = Vector3.Reflect(_rigidBody.velocity.normalized, collision.contacts[0].normal);
        //_velocity *= _velocityIncrease;
        _rigidBody.velocity = reflectDirection * _velocity;
    }
}
