using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D body;
    public Animator animationRef;

    Vector3 movement;
    float moveSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.currentState);
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.currentState)
        {
            case StateEnum.Title:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //do nothing
                }
                break;

            case StateEnum.Pause:
                // Stop all movement
                movement = new Vector2(0, 0);
                break;
        }

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveHorizontal, moveVertical, 0f);

        movement = movement * moveSpeed * Time.deltaTime;

        transform.position += movement;
    }
}
