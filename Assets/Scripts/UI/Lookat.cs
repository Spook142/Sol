using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {        
        transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
    }
}
