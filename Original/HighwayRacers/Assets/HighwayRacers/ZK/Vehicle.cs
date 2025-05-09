using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private float speed = 0;

    public Transform destination { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        speed = VehicleManager.instance.VehicleBaseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDestination(Transform transform)
    {
        transform = destination;
    }

    public void MakeVehicleVisible(bool value)
    {
        
    }
}
