using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    public GameObject top;
    Vector3 aradakiMesafe;

    void Start()
    {
        aradakiMesafe = transform.position - top.transform.position; // kamera ile top arasindaki mesafe farkini verir
    }

    void LateUpdate() // daha stabil kamera icin
    {
        transform.position = top.transform.position + aradakiMesafe; // kamera ile top arasi mesafeyi sabitleyip kameraya topu takip ettiriyor
    }
}
