using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text headText;

    [SerializeField] public bool inDialog = false;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        if(!inDialog)
            animator.SetFloat("Speed", movement.sqrMagnitude);
        else
            animator.SetFloat("Speed", 0);
    }
    private void FixedUpdate()
    {
        if(!inDialog)
            Move();
    }
    private void Move(){
        rb.MovePosition(rb.position + movement.normalized*speed*Time.fixedDeltaTime);
        // rb.velocity = new Vector2(horizontal, vertical).normalized*speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("DialogTrigger"))
        {
            headText.text = "Press Space to talk";
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("DialogTrigger"))
        {
            headText.text = "";
        }
    }

}
