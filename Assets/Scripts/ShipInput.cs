using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInput : MonoBehaviour
{
    [SerializeField] private ShipCamera shipCam;
    private ShipMovement shipMove;
    private bool readyToLaunch = true;


    // Start is called before the first frame update
    void Start()
    {
        if(shipCam == null) shipCam = this.gameObject.GetComponent<ShipCamera>();
        shipMove = this.GetComponent<ShipMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1)) shipCam.ZoomOut();
        if(Input.GetKeyUp(KeyCode.Mouse1)) shipCam.DefaultZoom();
         if(Input.GetKeyDown(KeyCode.Mouse0) && readyToLaunch)
        {
            Launch();
        }
    }

     public void Launch()
    {
        Debug.Log("Launching!");
        readyToLaunch = false;

    }

    // runs every 0.02 seconds
    void FixedUpdate() {
        shipMove.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}