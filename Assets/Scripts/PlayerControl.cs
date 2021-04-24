using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] InputAction MoveInput;
    public float Speed = 5000.0f;
    Rigidbody rigid;

    private void OnEnable()
    {
        MoveInput.Enable();
    }

    private void OnDisable()
    {
        MoveInput.Disable();
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rigid.AddForce(new Vector3(MoveInput.ReadValue<float>() * Speed * Time.deltaTime, 0.0f, 0.0f));
    }
}
