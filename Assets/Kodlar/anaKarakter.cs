using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anaKarakter : MonoBehaviour
{
    private Animator anim;
    private bool yuru;

    private void Awake()
    {
        anim =GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown("w"))
        {
            yuru = true;
            anim.SetBool("Run", true);
           
          
        }
        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("Jump");
        }
        if (yuru)
        {
            gameObject.transform.position += new Vector3(0, 0, 5)*Time.deltaTime;
        }
        if (Input.GetKeyUp("w"))
        {
            yuru = false;
            anim.SetBool("Run", false);

        }
    }
}
