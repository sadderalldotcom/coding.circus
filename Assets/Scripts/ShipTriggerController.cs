using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTriggerController : MonoBehaviour
{
    private int totalCubesCollected = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            other.GetComponent<CubeController>().GetCollected();
            totalCubesCollected++;
            Debug.Log("We have collected " + totalCubesCollected + " cubes.");
        }
    }
}
