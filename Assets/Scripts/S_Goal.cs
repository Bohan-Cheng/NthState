using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Goal : MonoBehaviour
{
    public bool IsMet = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsMet = true;
            FindObjectOfType<S_GameMana>().AddGoal();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsMet = false;
            FindObjectOfType<S_GameMana>().RemoveGoal();
        }
    }
}
