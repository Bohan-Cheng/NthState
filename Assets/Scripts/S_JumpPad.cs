using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_JumpPad : MonoBehaviour
{
    [SerializeField] float JumpForce = 1000.0f;


    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>())
        {
            other.GetComponent<Rigidbody>().AddForce(transform.right * JumpForce);
            GetComponent<Animator>().SetTrigger("Jump");
        }
    }
}
