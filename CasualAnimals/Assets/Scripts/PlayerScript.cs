using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D body;
    public Animator animationRef;

    // Flip the Character:
    Vector2 playerScale;

    Vector2 mov;
    float moveSpeed = 2.0f;

    private int currentCropStand = -1;
    private int currentFieldStand = -1;

    public int CurrentCropStand { get => currentCropStand; set => currentCropStand = value; }
    public int CurrentFieldStand { get => currentFieldStand; set => currentFieldStand = value; }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.currentState);
        playerScale = transform.localScale;
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
                mov = new Vector2(0, 0);
                break;
        }

    }

    void FixedUpdate()
    {
        //get axis
        if(GameManager.currentState != StateEnum.MarketplaceTo)
        {
            mov.x = Input.GetAxisRaw("Horizontal");
            mov.y = Input.GetAxisRaw("Vertical");

            //movement using rigidbody
            body.MovePosition(body.position + mov * moveSpeed * Time.fixedDeltaTime);

            //flip scale stuff
            //Moving right
            if (mov.x < 0)
            {
                playerScale.x = 1.2f;
            }

            //Moving left
            if (mov.x > 0)
            {
                playerScale.x = -1.2f;
            }

            //set the scale to the new scale
            transform.localScale = playerScale;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CropPlot")
        {
            currentCropStand = collision.gameObject.GetComponent<CropPlot>().PlotNumber;
            //Debug.Log("CropPlot: " + currentCropStand + "\n");
        }
        else if (collision.gameObject.tag == "Field")
        {
            currentFieldStand = collision.gameObject.GetComponent<Field>().FieldNumber;
            //Debug.Log("Field: " + currentFieldStand + "\n");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Truck")
        {
            GameManager.currentState = StateEnum.MarketplaceTo;
            GameManager.priorState = StateEnum.Game;
            GameObject.FindGameObjectWithTag("GoToMarketUI").GetComponent<Canvas>().enabled = true;
            //Debug.Log("Field: " + currentFieldStand + "\n");
        }

        if (collision.gameObject.tag == "TruckBack")
        {
            GameManager.currentState = StateEnum.MarketplaceFrom;
            GameManager.priorState = StateEnum.Game;
            GameObject.FindGameObjectWithTag("BackToFarmUI").GetComponent<Canvas>().enabled = true;
            //Debug.Log("Field: " + currentFieldStand + "\n");
        }
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
