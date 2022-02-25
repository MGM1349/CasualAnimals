using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// All Potential Options for game states
public enum StateEnum { Title, Game, MarketplaceTo, MarketplaceFrom, Pause, None };

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Static fields are like global, should persist throughout the game load.
    /// </summary>
    [SerializeField] public static GameManager gameInstance;
    [SerializeField] public static StateEnum currentState;
    [SerializeField] public static StateEnum priorState;
    [SerializeField] public CropManager cropManager;

    /// <summary>
    /// Need an Awake for instancing
    /// </summary>
    void Awake()
    {
        if (!gameInstance)
        {
            gameInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Duplicate GameManager created every time the scene is loaded
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Sets the current and prior state to default values when loaded
    /// </summary>
    void Start()
    {
        // Set the current state to be the title screen
        currentState = StateEnum.Title;
        priorState = StateEnum.None;
    }

    /// <summary>
    /// State machine for the game state
    /// MANAGER MUST START OFF IN TITLESCREEN OR WILL BREAK
    /// </summary>
    void Update()
    {
        Debug.Log(currentState);
        switch (GameManager.currentState)
        {
            case StateEnum.Title:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // Store the prior state
                    priorState = currentState;

                    // Start the game
                    currentState = StateEnum.Game;
                    SceneManager.LoadScene("MainGame");
                }
                break;
            case StateEnum.Game:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    // Pause game
                    priorState = currentState;
                    currentState = StateEnum.Pause;
                }
                break;
            case StateEnum.Pause:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    // Unpause the game, basic
                    priorState = currentState;
                    currentState = StateEnum.Game;
                }

                //may put a menu here? WIP?
                break;
            case StateEnum.MarketplaceTo:
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(50.0f, -1.58f, GameObject.FindGameObjectWithTag("Player").transform.position.z);
                    priorState = currentState;
                    GameObject.FindGameObjectWithTag("GoToMarketUI").GetComponent<Canvas>().enabled = false;
                    currentState = StateEnum.Game;
                } else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GameObject.FindGameObjectWithTag("GoToMarketUI").GetComponent<Canvas>().enabled = false;
                    priorState = currentState;
                    currentState = StateEnum.Game;
                }

                break;
            case StateEnum.MarketplaceFrom:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(4.24f, 5.7f, GameObject.FindGameObjectWithTag("Player").transform.position.z);
                    priorState = currentState;
                    GameObject.FindGameObjectWithTag("BackToFarmUI").GetComponent<Canvas>().enabled = false;
                    currentState = StateEnum.Game;
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GameObject.FindGameObjectWithTag("BackToFarmUI").GetComponent<Canvas>().enabled = false;
                    priorState = currentState;
                    currentState = StateEnum.Game;
                }

                break;
        }
    }
}