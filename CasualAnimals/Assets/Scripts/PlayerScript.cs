using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D body;
    public Animator animationRef;

    Vector3 movement;
    float moveSpeed = 2.0f;

    int currentCropStand = -1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.currentState);
    }

    public int CurrentCropStand
    {
        get
        {
            return currentCropStand;
        }
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
        //axis movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveHorizontal, moveVertical, 0f);

        movement = movement * moveSpeed * Time.deltaTime;

        transform.position += movement;

        //flipping for movement
        if(moveHorizontal != 0)
        {
            transform.localScale = new Vector2(-moveHorizontal * 1.2f, transform.localScale.y);
        }

    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "CropPlot")
    //    {
    //        currentCropStand = int.Parse(collision.name.Substring(collision.name.Length - 1)) - 1;
    //    }
    //}
    //
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "CropPlot")
    //    {
    //        currentCropStand = -1;
    //    }
    //}
}
