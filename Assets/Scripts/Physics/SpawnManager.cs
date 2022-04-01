using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject sunPrefab;
    public GameObject planetPrefab;
    public GameObject asteroidPrefab;

    GameObject player;
    GameObject bodySim;

    void Awake()
    {
        player = GameObject.FindWithTag("MainCamera");
        bodySim = this.gameObject;
    }

    public void SpawnSun()
    {
        GameObject temp = Instantiate(sunPrefab, player.transform.position + (player.transform.forward * 2), transform.rotation);
        temp.transform.SetParent(bodySim.transform);
    }

    public void SpawnPlanet()
    {
        GameObject temp = Instantiate(planetPrefab, player.transform.position + (player.transform.forward * 2), transform.rotation);
        temp.transform.SetParent(bodySim.transform);
    }

    public void SpawnAsteroid()
    {
        GameObject temp = Instantiate(asteroidPrefab, player.transform.position + (player.transform.forward * 2), transform.rotation);
        temp.transform.SetParent(bodySim.transform);
    }
}
