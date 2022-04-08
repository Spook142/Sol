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

    GameObject[] allCanvases;
    GameObject[] arrows;
    GameObject selfUI;
    public GameObject selfArrow;
    public GameObject selfDir;

    void Awake()
    {
        _name.text = parent.GetComponent<CelestialBody>().bName.ToString();
        selfUI = transform.gameObject;
    }

    void Update()
    {
        rad.text = (parent.GetComponent<CelestialBody>().radius * 100f).ToString();
        vel.text = (parent.GetComponent<CelestialBody>().velocity * 100f).ToString();
        grav.text = (parent.GetComponent<CelestialBody>().sGravity * 100f).ToString();
    }

    public void CloseOtherCanvases()
    {
        allCanvases = GameObject.FindGameObjectsWithTag("Canvas");
        arrows = GameObject.FindGameObjectsWithTag("Arrow");

        for (int i = 0; i < allCanvases.Length; i++)
        {
            if (allCanvases[i] != selfUI && allCanvases[i] != selfDir)
            {
                allCanvases[i].gameObject.SetActive(false);
                allCanvases[i] = null;
            }
        }

        for (int i = 0; i < arrows.Length; i++)
        {
            if(arrows[i] != selfArrow)
            {
                arrows[i].gameObject.SetActive(false);
                arrows[i] = null;
            }
        }
    }
}
