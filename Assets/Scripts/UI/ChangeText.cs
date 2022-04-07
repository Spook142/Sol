using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public GameObject parent;
    public TextMeshProUGUI _name;
    public TextMeshProUGUI rad;
    public TextMeshProUGUI vel;
    public TextMeshProUGUI grav;

    void Awake()
    {
        _name.text = parent.GetComponent<CelestialBody>().bName.ToString();
    }

    void Update()
    {
        rad.text = (parent.GetComponent<CelestialBody>().radius * 100f).ToString();
        vel.text = (parent.GetComponent<CelestialBody>().velocity * 100f).ToString();
        grav.text = (parent.GetComponent<CelestialBody>().sGravity * 100f).ToString();
    }
}
