using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeavyAttack : MonoBehaviour
{
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void HeavyAtk(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetBool("HeavyAtk", true);
        }
        else
        {
            animator.SetBool("HeavyAtk", false);
        }
        
    }
}
