using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBodySimulation : MonoBehaviour
{
    CelestialBody[] bodies;
    static NBodySimulation instance;

    public float timeScale;

    void Awake()
    {
        findNewBodies();
        Time.fixedDeltaTime = Universe.physicsTimeStep;
    }

    public void findNewBodies()
    {
        bodies = FindObjectsOfType<CelestialBody>();
    }

    void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            if (bodies[i] != null)
            {
                Vector3 accel = CalculateAcceleration(bodies[i].Position, bodies[i]);
                bodies[i].UpdateVelocity(accel, timeScale);
                bodies[i].UpdatePosition(timeScale);
            }
        }
    }

    public static Vector3 CalculateAcceleration(Vector3 p, CelestialBody ignoreBody = null)
    {
        Vector3 accel = Vector3.zero;
        foreach (var body in Instance.bodies)
        {
            if (body != ignoreBody && body != null)
            {
                float sqrDst = (body.Position - p).sqrMagnitude;
                Vector3 fDir = (body.Position - p).normalized;
                accel += fDir * Universe.gravitationalConstant * body.mass / sqrDst;
            }
        }

        return accel;
    }

    public void AdjustTime(float newTime)
    {
        timeScale = newTime;
    }

    public void DestroyAllBodies()
    {
        foreach (var body in bodies)
        {
            if (body != null)
            {
                Destroy(body.transform.gameObject);
            }
        }
    }

    public static CelestialBody[] Bodies
    {
        get
        {
            return Instance.bodies;
        }
    }

    static NBodySimulation Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<NBodySimulation>();
            }
            return instance;
        }
    }
}