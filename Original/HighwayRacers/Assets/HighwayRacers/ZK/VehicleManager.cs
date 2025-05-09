using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using HighwayRacers;
using UnityEngine;
using UnityEngine.Pool;

public class VehicleManager : MonoBehaviour
{
    public static VehicleManager instance { get; private set; }

    [SerializeField]
    private GameObject[] vehicles;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private Transform[] destinations;

    private LinkedList<Vehicle> vehiclesPool = new LinkedList<Vehicle>();
    private const int maxVehicles = 1000;

    private int vehicleSpawnRate = 1;
    private int vehicleBaseSpeed = 0;

    public int VehicleSpawnRate
    {
        get { return vehicleSpawnRate; }
        set { vehicleSpawnRate = value; }
    }

    public int VehicleBaseSpeed
    {
        get { return vehicleBaseSpeed; }
        set { vehicleBaseSpeed = value; }
    }

    private bool canSpawn = true;

    public bool CanSpawn
    {
        get { return canSpawn; }
        set { canSpawn = value; }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxVehicles; i++)
        {
            int randomV = Random.Range(0, vehicles.Length);
            Vehicle v = Instantiate(vehicles[randomV], transform).GetComponent<Vehicle>();
            v.MakeVehicleVisible(true);
            vehiclesPool.AddLast(v);
        }

        StartCoroutine(SpawnVehicles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vehicle AddVehicle()
    {
        //foreach (Car car in cars)
        //{
        //    Car frontCar = GetCarInFront(car);
        //    float backDistance = GetEquivalentDistance(car.distanceFront, car.lane, lane);
        //    float frontDistance = GetEquivalentDistance(frontCar.distanceBack, frontCar.lane, lane);
        //    float space = DistanceTo(backDistance, lane, frontDistance);
        //    if (space > car.distanceToFront + car.distanceToBack + MIN_DIST_BETWEEN_CARS * 2)
        //    {
        //        // enough space to add car
        //        float distance = backDistance + (space - (car.distanceToFront + car.distanceToBack)) / 2 + car.distanceToBack;
        //        return AddCarUnsafe(distance, lane);
        //    }
        //}

        int randomV = Random.Range(0, vehicles.Length);
        int randomD = Random.Range(0, destinations.Length);
        Vehicle v = Instantiate(vehicles[randomV], transform).GetComponent<Vehicle>();
        v.SetDestination(destinations[randomD]);


        //car.SetRandomPropeties();
        //car.distance = distance;
        //car.lane = lane;
        //car.velocityPosition = car.defaultSpeed;
        //cars.AddLast(car);
        //car.UpdatePosition();
        return v;
    }

    private IEnumerator SpawnVehicles()
    {
        yield return new WaitForSeconds(vehicleSpawnRate);

        yield return new WaitUntil(() => canSpawn);


    }
}
