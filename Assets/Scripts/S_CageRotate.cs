using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_CageRotate : MonoBehaviour
{
    [SerializeField] InputAction RotateInput;
    [SerializeField] float RotateSpeed = 30.0f;

    S_GameMana mana;

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
        mana = FindObjectOfType<S_GameMana>();
    }

    void OnStopRotate()
    {
        mana.ResumeObjects();
    }

    // Update is called once per frame
    void Update()
    {
        float val = RotateInput.ReadValue<float>();
        if (Mathf.Abs(val) > 0)
        {
            mana.PauseObjects();
            transform.Rotate(0, 0, -val * RotateSpeed * Time.deltaTime);
        }
    }
}
