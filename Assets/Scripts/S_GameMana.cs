using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameMana : MonoBehaviour
{
    public int reachedGoal = 0;
    public bool IsGamePaused = false;
    [SerializeField] string NextMap;
    [SerializeField] GameObject CurrentCage;

    private void Start()
    {
        PauseObjects();
        StartCoroutine(StartGame());
    }

    public void PauseObjects()
    {
        foreach (Rigidbody g in FindObjectsOfType<Rigidbody>())
        {
            g.transform.SetParent(CurrentCage.transform);
            //g.isKinematic = true;
        }
        IsGamePaused = true;
    }

    public void ResumeObjects()
    {
        foreach (Rigidbody g in FindObjectsOfType<Rigidbody>())
        {
            g.transform.SetParent(null);
            //g.isKinematic = false;
        }
        IsGamePaused = false;
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.0f);
        CurrentCage.GetComponent<S_CageRotate>().enabled = true;
        ResumeObjects();
    }

    public void AddGoal()
    {
        reachedGoal++;
        CheckWin();
    }

    public void RemoveGoal()
    {
        reachedGoal--;
        CancelInvoke("ToNextMap");
    }

    void CheckWin()
    {
        if (BothMet() && reachedGoal == 2)
        {
            Invoke("ToNextMap", 2.0f);
        }
    }

    void ToNextMap()
    {
        if (reachedGoal == 2)
        {
            SceneManager.LoadScene(NextMap);
        }
    }

    bool BothMet()
    {
        foreach (S_Goal g in FindObjectsOfType<S_Goal>())
        {
            if (!g.IsMet)
            {
                return false;
            }
        }
        return true;
    }

}
