using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D body;
    public Animator animationRef;

    Vector3 movement;
    float moveSpeed = 2.0f;

    private int currentCropStand = -1;
    private int currentFieldStand = -1;

    public int CurrentCropStand { get => currentCropStand; set => currentCropStand = value; }
    public int CurrentFieldStand { get => currentFieldStand; set => currentFieldStand = value; }

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

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CropPlot")
        {
            currentCropStand = collision.gameObject.GetComponent<CropPlot>().PlotNumber;
            Debug.Log("CropPlot: " + currentCropStand + "\n");
        }
        else if (collision.gameObject.tag == "Field")
        {
            currentFieldStand = collision.gameObject.GetComponent<Field>().FieldNumber;
            Debug.Log("Field: " + currentFieldStand + "\n");
        }

        Debug.Log("Field: " + currentFieldStand + "\n");
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CropPlot")
        {
            currentCropStand = -1;
        }
        else if (collision.gameObject.tag == "Field")
        {
            currentFieldStand = -1;
        }
    }
}
