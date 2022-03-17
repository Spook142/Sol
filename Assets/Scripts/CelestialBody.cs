using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CelestialBody : MonoBehaviour
{

    public float r;
    public float sGravity;
    public Vector3 initialVelocity;
    public string bName = "null";

    public Vector3 velocity { get; private set; }
    public float m { get; private set; }
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = m;
        velocity = initialVelocity;
    }

    public void UpdateVelocity(CelestialBody[] allBodies, float timeStep)
    {
        foreach (var otherBody in allBodies)
        {
            if (otherBody != this)
            {
                float sqrDst = (otherBody.rb.position - rb.position).sqrMagnitude;
                Vector3 fDir = (otherBody.rb.position - rb.position).normalized;

                Vector3 accel = fDir * Universe.gravitationalConstant * otherBody.m / sqrDst;
                velocity += accel * timeStep;
            }
        }
    }

    public void UpdateVelocity(Vector3 accel, float t)
    {
        velocity += accel * t;
    }

    public void UpdatePosition(float t)
    {
        rb.MovePosition(rb.position + velocity * t);
    }

    void OnValidate()
    {
        m = sGravity * r * r / Universe.gravitationalConstant;
        transform.localScale = Vector3.one * r;
        gameObject.name = bName;
    }

    public Rigidbody Rigidbody
    {
        get
        {
            return rb;
        }
    }

    public Vector3 Position
    {
        get
        {
            return rb.position;
        }
    }

}