using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplanacakObjeler : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(0,30,0)*Time.deltaTime); // objeleri y ekseninde d�nd�r�yor, time.deltatime yava� d�nd�rmesini sagliyor
    }
}
