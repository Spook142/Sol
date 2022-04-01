using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CelestialBody : MonoBehaviour
{

    public float radius;
    public float sGravity;
    public Vector3 initialVelocity;
    public string bName = "null";

    static int scale = 100;

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
        gameObject.name = bName;
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

    public void UpdateMass()
    {
        mass = sGravity * radius * radius / Universe.gravitationalConstant;
    }

    public void ChangeRadius(float i)
    {
        radius += i / scale;
        transform.localScale = Vector3.one * radius;
        UpdateMass();
    }
    public void ChangeGravity(float i)
    {
        sGravity += i / scale;
        UpdateMass();
    }

    public void ChangeVelocityX(float i)
    {
        velocity += new Vector3(i / scale, 0, 0);
    }

    public void ChangeVelocityY(float i)
    {
        velocity += new Vector3(0, i / scale, 0);
    }

    public void ChangeVelocityZ(float i)
    {
        velocity += new Vector3(0, 0, i / scale);
    }

    //Debugging Purposes
    void OnValidate()
    {
        gameObject.name = bName;
        transform.localScale = Vector3.one * radius;
        UpdateMass();
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

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}