using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class TouchingDirection : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;
    Animator anim;
    CapsuleCollider2D touchCol;
    RaycastHit2D[] groundHit = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];
    [SerializeField]
    private bool _isGround;

    public bool IsGround
    {
        get
        {
            return _isGround;
        }
        private set
        {
            _isGround = value;
            anim.SetBool("IsGround", value);
        }
    }

    private bool _isOnWall;

    public bool IsOnwall
    {
        get
        {
            return _isOnWall;
        }
        private set
        {
            _isOnWall = value;
            anim.SetBool("IsOnWall", value);
        }
    }

    private bool _isOnCeiling;
    private Vector2 WallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    public bool IsOnCeiling
    {
        get
        {
            return _isOnCeiling;
        }
        private set
        {
            _isOnCeiling = value;
            anim.SetBool("IsOnCeiling", value);
        }
    }

    private void Awake()
    {
        touchCol = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        IsGround = touchCol.Cast(Vector2.down, castFilter, groundHit, groundDistance) > 0;
        IsOnwall = touchCol.Cast(WallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchCol.Cast(WallCheckDirection, castFilter, ceilingHits, ceilingDistance) > 0;
    }
}
