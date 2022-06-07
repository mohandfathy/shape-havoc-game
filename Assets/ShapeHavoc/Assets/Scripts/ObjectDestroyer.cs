﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);      //If something collides with this gameobject, then it will be destroyed
    }
}
