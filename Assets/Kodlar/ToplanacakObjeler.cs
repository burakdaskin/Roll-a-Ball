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
        transform.Rotate(new Vector3(15,30,45)*Time.deltaTime); // objeleri d�nd�r�yor, time.deltatime ise yava� d�nd�rmeye yar�yor
    }
}
