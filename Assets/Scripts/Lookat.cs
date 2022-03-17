using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
    }
}
