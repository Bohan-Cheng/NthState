using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GameMana : MonoBehaviour
{
    public bool IsGameStarted = false;
    [SerializeField] GameObject[] Cages;
    GameObject CurrentCage;

    private void Start()
    {
        CurrentCage = Cages[0];
        PauseObjects();
        StartCoroutine(StartGame());
    }

    public void PauseObjects()
    {
        foreach (Rigidbody g in FindObjectsOfType<Rigidbody>())
        {
            g.transform.SetParent(CurrentCage.transform);
            g.isKinematic = true;
        }
    }

    public void ResumeObjects()
    {
        foreach (Rigidbody g in FindObjectsOfType<Rigidbody>())
        {
            g.transform.SetParent(null);
            g.isKinematic = false;
        }
    }


    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.0f);
        IsGameStarted = true;
        CurrentCage.GetComponent<S_CageRotate>().enabled = true;
        ResumeObjects();
    }
}
