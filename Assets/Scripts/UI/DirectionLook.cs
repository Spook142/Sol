using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionLook : MonoBehaviour
{
    public GameObject parent;
    Quaternion _lookRotation;
    float RotationSpeed = 30.0f;
    Vector3 newPos;
    Vector3 prevPos;

    // Update is called once per frame
    void Update()
    {
        newPos = parent.GetComponent<CelestialBody>().updatedPosition;
        prevPos = parent.GetComponent<CelestialBody>().previousPosition;

        Vector3 heading = newPos - prevPos;
        var distance = heading.magnitude;
        var direction = heading / distance;

        _lookRotation = Quaternion.LookRotation(direction);
        Quaternion newRotation = _lookRotation * Quaternion.Euler(0, 90, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Universe.physicsTimeStep * RotationSpeed);
    }
}
