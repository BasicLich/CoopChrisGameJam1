﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public static GameObject truck = null;
    public static GameObject boat = null;
    public static GameObject tank = null;

    public Vector3 offset = new Vector3(0f, 0f, 0f);

    public static GameObject following = null;


    public GameObject UpgradeZoneOcean;
    public GameObject UpgradeZoneCity;
    public GameObject PortCacheZone;
    public GameObject PortCacheBoatZone;
    public GameObject PortCacheTankZone;
    public GameObject PortCacheBoatTankZone;

    void Start()
    {

        truck = GameObject.Find("Truck");
        boat = GameObject.Find("Boat");
        tank = GameObject.Find("Tank");

        transform.position = truck.transform.position + offset;

        truck.GetComponent<Movement>().on = true;
        boat.GetComponent<Movement>().on = false;
        tank.GetComponent<Movement>().on = false;

        following = truck;

    }

    void LateUpdate()
    {
        if (Debug.isDebugBuild) 
        {
            if(Input.GetKeyDown(KeyCode.P))
                PlayerStats.updateTruckInventory(1);
            if(Input.GetKeyDown(KeyCode.M))
                PlayerStats.money += 1000;
        }

        if(!UpgradeZoneOcean.GetComponent<UpgradeZoneOcean>().inMenu 
            && !UpgradeZoneCity.GetComponent<UpgradeZoneCity>().inMenu 
            && !PortCacheTankZone.GetComponent<PortCacheTankZone>().inMenu 
            && !PortCacheBoatTankZone.GetComponent<PortCacheBoatTankZone>().inMenu 
            && !PortCacheZone.GetComponent<PortCacheZone>().inMenu 
            && !PortCacheBoatZone.GetComponent<PortCacheBoatZone>().inMenu)

        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) { SwapToTruck(); following = truck; }

            if (Input.GetKeyDown(KeyCode.Alpha2)|| Input.GetKeyDown(KeyCode.Keypad2)) { SwapToBoat(); following = boat;}

            if (Debug.isDebugBuild) 
                if (Input.GetKeyDown(KeyCode.Alpha3)|| Input.GetKeyDown(KeyCode.Keypad3)) { SwapToTank(); following = tank;}
            transform.position = following.transform.position + offset;
        }

    }


    void SwapToTruck()
    {

        transform.position = truck.transform.position + offset;
        truck.GetComponent<Movement>().on = true;
        boat.GetComponent<Movement>().on = false;
        tank.GetComponent<Movement>().on = false;


    }

    void SwapToBoat()
    {

        transform.position = boat.transform.position + offset;
        truck.GetComponent<Movement>().on = false;
        boat.GetComponent<Movement>().on = true;
        tank.GetComponent<Movement>().on = false;

    }

    void SwapToTank()
    {

        transform.position = tank.transform.position + offset;
        truck.GetComponent<Movement>().on = false;
        boat.GetComponent<Movement>().on = false;
        tank.GetComponent<Movement>().on = true;

    }

}
