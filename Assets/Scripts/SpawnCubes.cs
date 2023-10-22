// Stormy Dietz Interactive Scripting Fall 2023
// This code will spawn cubes at random locations around the map


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{

    public string[] names = {"Edmond", "Mercedes", "Albert"};

    //names[0] = Edmond
    //names[1] = Mercedes
    //names[2] = Albert
    //names[3] = ????

    [SerializeField]
    private Color[] colors;

    [SerializeField]
    bool debug = false;

    [SerializeField]
    private GameObject prefabCube;

    [SerializeField]
    private int totalCubes = 25;

    [SerializeField]
    [Range(0.1f, 2f)]
    private float spawnCubeInterval = 1f;

    [SerializeField]
    private float spawnPositionRange = 40;

    private bool canStartSpawnLoop = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press Shift+0 to enable debug mode.");
        if(debug) Debug.Log("<color=cyan>Press G to spawn cubes.</color>");
        if(debug) Debug.Log("<color=magenta>Press B to collect cubes.</color>");
        if(debug) Debug.Log("The first name in the array of names is " + names[0]);
        StartCoroutine(SpawnLoop());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(Input.GetKeyDown(KeyCode.Alpha0))
            {
                debug = !debug;
                Debug.Log("Debug mode is now " + debug);
            }
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            if(canStartSpawnLoop == true)
            {
           StartCoroutine(SpawnLoop());
            }
            else
            {
               if(debug) Debug.Log("<color=red>You cannot start a new loop</color> until the old one is finished.");
            }
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            CollectCubes();
        }
    }

    GameObject SpawnCube()
    {
        if(debug) Debug.Log("<color=green>Starting SpawnCube() function.</color>");

        if(debug) Debug.Log("creating cube from prefab 'prefabCube'");
        GameObject cube = Instantiate(prefabCube);

        cube.name = names[Random.Range(0, names.Length)];

        if(debug) Debug.Log("setting random location");

        Vector3 newPos = new Vector3(
            Random.Range(-spawnPositionRange, spawnPositionRange), 
            Random.Range(1.5f, 2.5f), 
            Random.Range(-spawnPositionRange, spawnPositionRange)
        );
        if(debug) Debug.Log("setting cube position to " + newPos);
        cube.transform.position = newPos;

        //if(debug) Debug.LogError("Pausing here to look at the position of the cube.");

        Color newColor = colors[Random.Range(0, colors.Length)];
        if(debug) Debug.Log("setting color to " + newColor);                      
        cube.GetComponent<Renderer>().material.color = newColor;

        if(debug) Debug.Log("adding Rigidbody component.");
        cube.AddComponent(typeof(Rigidbody));


        if(debug) Debug.Log("<color=red>End of SpawnCube() function.</color>");
        return cube;
    }

    void CollectCubes()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        int i = 0;
        while(i < cubes.Length)
        {
          cubes[i].transform.position = new Vector3(0,2,0);
          i += 1;
        }
    }

    IEnumerator SpawnLoop()
    {
        canStartSpawnLoop = false;

        int counter = 0;
        while (counter < totalCubes)
        {
            counter += 1;
            SpawnCube();
            yield return new WaitForSeconds(spawnCubeInterval);
        }

        canStartSpawnLoop = true;
    }
}