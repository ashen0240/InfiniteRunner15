﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, offset.y, player.position.z+offset.z);
    }
}