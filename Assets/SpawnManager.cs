using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject bgSpoolPrefab;

    private Vector3 spawnLocaiton = new Vector3(30, 0, 0);
    private float initalWait = 1;
    private float periodRepeat = 2;


    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", initalWait, periodRepeat);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        int bgBoxCount = 20;
        float bgWidth = GameObject.Find("Background").GetComponent<BoxCollider>().size.x;
        float spacing = bgWidth / bgBoxCount;

        for (int count = 0; count < bgBoxCount; count++)
        {
            Debug.Log(count * 10);
            Instantiate(bgSpoolPrefab, new Vector3(count* spacing, 0, 4.15f), bgSpoolPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerController.gameOver == false )
        {
            Instantiate(obstaclePrefab, spawnLocaiton, obstaclePrefab.transform.rotation);
        }
        
    }
}
