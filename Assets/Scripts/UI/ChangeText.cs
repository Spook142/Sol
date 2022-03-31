using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    GameObject parent;
    TextMeshProUGUI[] Texts;

    GameObject bodySim;

    // Start is called before the first frame update
    void Start()
    {
        Texts = GetComponentsInChildren<TextMeshProUGUI>();
        bodySim = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        parent = transform.parent.gameObject;
        for(int i = 0; i < Texts.Length; i++)
        {
            if (Texts[i].ToString() == "RText (TMPro.TextMeshProUGUI)")
                Texts[i].text = (parent.gameObject.GetComponent<CelestialBody>().radius * 100f).ToString();
            if (Texts[i].ToString() == "VText (TMPro.TextMeshProUGUI)")
                Texts[i].text = (parent.gameObject.GetComponent<CelestialBody>().velocity * 100f).ToString();
            if (Texts[i].ToString() == "GText (TMPro.TextMeshProUGUI)")
                Texts[i].text = (parent.gameObject.GetComponent<CelestialBody>().sGravity * 100f).ToString();
        }
    }

    public void AdjustTime()
    {

    }
}
