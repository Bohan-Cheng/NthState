using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_CageRotate : MonoBehaviour
{
    [SerializeField] InputAction RotateInput;
    [SerializeField] float RotateSpeed = 30.0f;

    GameObject player;

    private void OnEnable()
    {
        RotateInput.Enable();
        RotateInput.canceled += ctx => OnStopRotate();
    }

    private void OnDisable()
    {
        RotateInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnStopRotate()
    {
        foreach (GameObject g in FindObjectsOfType<GameObject>())
        {
            if (g.GetComponent<Rigidbody>())
            {
                g.GetComponent<Rigidbody>().isKinematic = false;
                g.transform.SetParent(null);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float val = RotateInput.ReadValue<float>();
        if (Mathf.Abs(val) > 0)
        {
            foreach ( GameObject g in FindObjectsOfType<GameObject>())
            {
                if (g.GetComponent<Rigidbody>())
                {
                    g.transform.SetParent(transform);
                    g.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
            transform.Rotate(0, 0, -val * RotateSpeed * Time.deltaTime);
        }
    }
}
