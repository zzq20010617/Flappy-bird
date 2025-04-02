using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    public static PlayerInput playerInput;


    [Header("bird")]
    [SerializeField] private Transform bird;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float birdUpSpeed = 5f;
    [SerializeField] private float limitdownSpeed = -6f;
    [SerializeField] private float limitUpSpeed = 6f;

    public delegate void BirdCollid();
    public static event BirdCollid OnBirdCollid;


    private InputAction mouseAction;

    private void Awake()
    {
       playerInput = GetComponent<PlayerInput>();

        mouseAction = playerInput.actions["Mouse"];
    }



    // Update is called once per frame
    void Update()
    {
        if (mouseAction.IsPressed())
        {
            FlyBird();
        }
    }



    public void FlyBird()
    {
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y + birdUpSpeed, limitdownSpeed, limitUpSpeed));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit!");
        OnBirdCollid?.Invoke();
        Destroy(gameObject);
    }



}
