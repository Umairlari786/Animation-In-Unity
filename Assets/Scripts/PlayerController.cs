using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;

    public float jumpHeight = 2.0f;
    public float jumpDuration = 0.5f;
    public float jumpSpeed = 5.0f;

    private bool isJumping = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) == true)
        {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsJumping", false);
            if (transform.position.x < 10)
            {
                anim.SetBool("IsWalking", true);
                transform.Translate(new Vector2(0.02f, 0f));
                transform.localScale = new Vector2(5f, 5f);
            }
        }

        if (Input.GetKey(KeyCode.S) == true)
        {
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsJumping", false);
            if (transform.position.x > -10)
            {
                anim.SetBool("IsWalking", true);
                transform.Translate(new Vector2(-0.02f, 0f));
                transform.localScale = new Vector2(-5f, 5f);
            }
        }

        if (Input.GetKey(KeyCode.M) == true)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsJumping", false);
            if (transform.position.x < 10)
            {
                anim.SetBool("IsRunning", true);
                transform.Translate(new Vector2(0.09f, 0f));
                transform.localScale = new Vector2(5f, 5f);
            }
        }
        if (Input.GetKey(KeyCode.N) == true)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsJumping", false);
            if (transform.position.x > -10)
            {
                anim.SetBool("IsRunning", true);
                transform.Translate(new Vector2(-0.09f, 0f));
                transform.localScale = new Vector2(-5f, 5f);
            }
        }

        if (Input.GetKey(KeyCode.E) == true)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsRunning", false);
        

            StartCoroutine(Jump());
        }

        IEnumerator Jump()
        {
            isJumping = true;
            anim.SetBool("IsJumping", true);

            //float jumpStartY = transform.position.y;
            //float jumpEndY = jumpStartY + jumpHeight;

            float startTime = Time.time;
            while (Time.time - startTime < jumpDuration)
            {
                float jumpProgress = (Time.time - startTime) / jumpDuration;
                float newY = Mathf.Lerp(0, 1, jumpProgress);

                // Adjust position left or right as needed for a more natural jump trajectory
                float newX = transform.position.x + jumpSpeed * Time.deltaTime;

                transform.position = new Vector3(newX, newY, transform.position.z);
                yield return null;
            }

            isJumping = false;
            anim.SetBool("IsJumping", false);
        }

        /*if (Input.GetKey(KeyCode.W) == true)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsRunning", false);
            if (transform.position.x > -10)
            {
                anim.SetBool("IsJumping", true);
                transform.Translate(new Vector2(-0.04f, 0f));
                transform.localScale = new Vector2(-5f, 5f);
            }
        }*/

        if (!Input.anyKey)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsIdle", true);
        }
        
    }
}
