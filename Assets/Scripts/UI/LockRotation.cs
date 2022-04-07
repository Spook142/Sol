using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
