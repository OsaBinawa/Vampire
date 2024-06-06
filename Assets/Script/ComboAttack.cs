using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComboAttack : MonoBehaviour
{
    public static ComboAttack Instance;

    public bool canReceiveInput;
    public bool inputReceived;

    PlayerController playerController;

    

    private void Awake()
    {
        Instance = this;
       // playerController = GetComponent<PlayerController>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void attack(InputAction.CallbackContext context)
    {
       
        if (context.performed)
        {
            inputReceived = true;
            canReceiveInput = false;
            //playerController.canMove = false;
        }
        else
        {
            return;
        }
    }

    public void InputManager()
    {
        if (!inputReceived)
        {
            canReceiveInput = true;
        }
        else
        {
            canReceiveInput = false;
        }
    }
}
