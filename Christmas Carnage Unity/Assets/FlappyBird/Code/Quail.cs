using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quail : MonoBehaviour
{
    public float jumpVelocity;
    public AudioSource jumpSound;
    public AudioSource hurtSound;
    Rigidbody2D rigidBody2D;

    bool canJump = true;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            Jump();
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.fingerId == 0 && Time.timeScale == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began && canJump)
                {
                    Jump();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Lose();
    }

    void Jump()
    {
        rigidBody2D.velocity = Vector2.up * jumpVelocity;
        jumpSound.Play();
    }

    void Lose()
    {
        canJump = false;
        GetComponent<Collider2D>().enabled = false;
        transform.localScale = new Vector3(1, -1, 1);
        hurtSound.Play();
        StartCoroutine(DelayGameOver());
    }

    private IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.GameOver();
    }
}
