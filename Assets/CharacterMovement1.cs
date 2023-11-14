using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterMovement1 : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 direction;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * _speed * Time.fixedDeltaTime);
    }
}
