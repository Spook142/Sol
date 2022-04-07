using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionLook : MonoBehaviour
{
    Vector3 prevPos;
    Vector3 newPos;
    Quaternion _lookRotation;
    float RotationSpeed = 30.0f;

    // Update is called once per frame
    void Update()
    {
        newPos = transform.parent.parent.GetComponent<CelestialBody>().updatedPosition;
        prevPos = transform.parent.parent.GetComponent<CelestialBody>().previousPosition;

        Vector3 heading = newPos - prevPos;
        var distance = heading.magnitude;
        var direction = heading / distance;

        _lookRotation = Quaternion.LookRotation(direction);
        Quaternion newRotation = _lookRotation * Quaternion.Euler(0, 90, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Universe.physicsTimeStep * RotationSpeed);
    }
}
