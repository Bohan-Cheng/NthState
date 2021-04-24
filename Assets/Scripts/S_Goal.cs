using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Goal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<S_GameMana>().AddGoal();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<S_GameMana>().RemoveGoal();
        }
    }
}
