using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehicleInputController : MonoBehaviour
{
    [SerializeField]
    private Text vehicleSpawnRateText;
    [SerializeField]
    private Text vehicleBaseSpeedText;

    private const string vehicleSpawnRateString = "Vehicle Spawn Rate: ";
    private const string vehicleBaseSpeedString = "Vehicle Base Speed: ";


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChangedVehicleSpawnRate(float value)
    {
        value = VehicleManager.instance.VehicleSpawnRate;
        vehicleSpawnRateText.text = vehicleSpawnRateString + value.ToString();
    }

    public void OnValueChangedVehicleBaseSpeed(float value)
    {
        value = VehicleManager.instance.VehicleBaseSpeed;
        vehicleBaseSpeedText.text = vehicleBaseSpeedString + value.ToString();
    }
}
