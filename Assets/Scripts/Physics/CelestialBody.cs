using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CelestialBody : MonoBehaviour
{

    public float radius;
    public float sGravity;
    public Vector3 initialVelocity;
    public string bName = "null";

    [SerializeField] private Vector3 Vel;
    public Vector3 velocity
    {
        get => Vel;
        set => Vel = value;
    }

    [SerializeField] private float Mass;
    public float mass
    {
        get => Mass;
        set => Mass = value;
    }

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
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

                Vector3 accel = fDir * Universe.gravitationalConstant * otherBody.mass / sqrDst;
                velocity += accel * timeStep;               
            }
        }
    }

    public void UpdateVelocity(Vector3 accel, float timeStep)
    {
        velocity += accel * timeStep;
    }

    public void UpdatePosition(float timeStep)
    {
        rb.MovePosition(rb.position + velocity * timeStep);
    }

    void OnValidate()
    {
        mass = sGravity * radius * radius / Universe.gravitationalConstant;
        transform.localScale = Vector3.one * radius;
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