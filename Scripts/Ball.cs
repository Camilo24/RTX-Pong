using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField] private GameObject _initialPosition;
    private float _velocity = 50f;
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private ParticleSystem blue;
    [SerializeField] private ParticleSystem red;
    [SerializeField] private UIManager manager;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.AddForce(new Vector3(1, 0, 1) * _velocity, ForceMode.VelocityChange);
        blue.Stop();
        red.Stop();
    }

    void Update()
    {
        _rigidBody.velocity = _rigidBody.velocity.normalized * _velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 reflectDirection = Vector3.Reflect(_rigidBody.velocity.normalized, collision.contacts[0].normal);
        _rigidBody.velocity = reflectDirection * _velocity;

        if (collision.gameObject.CompareTag("Blue Goal"))
        {
            PointMade();
            manager.RedPoint();
            blue.Play();
            Invoke("PauseExplosion", 0.5f);
        }

        if (collision.gameObject.CompareTag("Red Goal"))
        {
            PointMade();
            manager.BluePoint();
            red.Play();
            Invoke("PauseExplosion", 0.5f);
        }

    }

    void PointMade()
    {
        cameraShake.Shake();
        this.gameObject.SetActive(false);
        Invoke("RestartPosition", 0.5f);
    }

    void RestartPosition()
    {
        transform.position = _initialPosition.transform.position;
        this.gameObject.SetActive(true);
    }

    void PauseExplosion()
    {
        blue.Stop();
        red.Stop();
    }
}
