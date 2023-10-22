using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    
    public int riseSpeed = 0;
    public int cubeSpeed;

    void Start()
    {
        cubeSpeed = Random.Range(1, 10);
    }

    void Update()
    {
        this.transform.Translate(0, riseSpeed * Time.deltaTime, 0);
    }

    public void GetCollected() {
       if (cubeSpeed > 6) 
        {
            GetComponent<Renderer>().material.color = Color.green;

            cubeSpeed = 5;

            GetComponent<Rigidbody>().isKinematic = true;
            Destroy(gameObject, 5f); 
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.red;

            Destroy(gameObject, 1f); 
        }
    }
}
