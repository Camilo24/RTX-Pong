using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeDuration = 0.5f;
    private float shakeAmount = 0.2f;
    private Vector3 originalPosition;

    public void Shake()
    {
        originalPosition = transform.localPosition;
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeAmount;
            float y = Random.Range(-1f, 1f) * shakeAmount;

            transform.localPosition = originalPosition + new Vector3(x, y, 0f);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
