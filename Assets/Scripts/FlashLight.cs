using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] Light flashLight;
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 0.1f;
    [SerializeField] float minAngle = 20f;

    // Update is called once per frame
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    void DecreaseLightAngle()
    {
        if (flashLight.intensity <= 0) return;
        flashLight.intensity -= lightDecay * Time.deltaTime;
    }

    void DecreaseLightIntensity()
    {
        if (flashLight.spotAngle <= minAngle) return;
        flashLight.spotAngle -= angleDecay * Time.deltaTime;
    }

    public void RestoreLight(float angle, float intensity)
    {
        flashLight.spotAngle = angle;
        flashLight.intensity += intensity;
    }
}
