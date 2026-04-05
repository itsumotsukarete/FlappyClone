using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private InputAction jumpAction;
    private bool isJumpPressed;

    [SerializeField] private TMP_Text scoreText;
    private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + score;
        jumpAction = InputSystem.actions.FindAction("Jump");
        isJumpPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (jumpAction.IsPressed() && !isJumpPressed)
        {
            isJumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (isJumpPressed)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1f), ForceMode2D.Impulse);
            isJumpPressed = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ++score;
        scoreText.text = "Score: " + score;
    }
}
