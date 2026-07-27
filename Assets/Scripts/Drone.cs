using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private void OnDestroy()
    {
        GameManager.Instance.DroneKilled();
    }
}
