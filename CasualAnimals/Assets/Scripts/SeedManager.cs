using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedManager : MonoBehaviour
{
    private int currentSeed;
    public List<GameObject> seeds;
    public List<GameObject> aboveHeadShowings;
    public GameObject hiddenSeeds;

    private float timer;
    private float maxTimeShown;
    private bool finishShowing;
    private bool setParents;

    public CropManager cropManager;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentSeed = 0;
        timer = 0;
        maxTimeShown = 5;
        finishShowing = true;
        setParents = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finishShowing)
        {
            if (timer >= maxTimeShown)
            {
                ResetView();
                ResetSeedShown();
                finishShowing = true;
            }
            else
            {

                if (!setParents)
                {
                    SetParents();
                    setParents = true;
                }

                timer += Time.deltaTime;
            }
        }

        Vector3 flippedVector = new Vector3(-1.2f, transform.localScale.y, transform.localScale.z);
        if (player.transform.localScale == flippedVector)
        {
            for (int i = 0; i < aboveHeadShowings.Count; i++)
            {
                aboveHeadShowings[i].transform.localScale = new Vector3(aboveHeadShowings[i].transform.localScale.x * -1, aboveHeadShowings[i].transform.localScale.y, 1f);
            }
        }

        KeyPresses();
    }

    public void SetParents()
    {
        ResetSeedShown();

        //seeds[currentSeed].transform.parent = aboveHeadShowings[1].transform;
        //seeds[currentSeed].transform.localPosition = Vector3.zero;

        if (currentSeed == 0)
        {
            seeds[seeds.Count - 1].transform.parent = aboveHeadShowings[0].transform;
            seeds[currentSeed].transform.parent = aboveHeadShowings[1].transform;
            seeds[currentSeed + 1].transform.parent = aboveHeadShowings[2].transform;

            seeds[seeds.Count - 1].transform.localPosition = Vector3.zero;
            seeds[currentSeed].transform.localPosition = Vector3.zero;
            seeds[currentSeed + 1].transform.localPosition = Vector3.zero;

            seeds[seeds.Count - 1].transform.localScale = new Vector3(.85f, .85f, 1f);
            seeds[currentSeed].transform.localScale = new Vector3(1f, 1f, 1f);
            seeds[currentSeed + 1].transform.localScale = new Vector3(.85f, .85f, 1f);

        }
        else if (currentSeed == seeds.Count - 1)
        {
            seeds[currentSeed - 1].transform.parent = aboveHeadShowings[0].transform;
            seeds[currentSeed].transform.parent = aboveHeadShowings[1].transform;
            seeds[0].transform.parent = aboveHeadShowings[2].transform;

            seeds[currentSeed - 1].transform.localPosition = Vector3.zero;
            seeds[currentSeed].transform.localPosition = Vector3.zero;
            seeds[0].transform.localPosition = Vector3.zero;

            seeds[currentSeed - 1].transform.localScale = new Vector3(.85f, .85f, 1f);
            seeds[currentSeed].transform.localScale = new Vector3(1f, 1f, 1f);
            seeds[0].transform.localScale = new Vector3(.85f, .85f, 1f);

        }
        else
        {
            seeds[currentSeed - 1].transform.parent = aboveHeadShowings[0].transform;
            seeds[currentSeed].transform.parent = aboveHeadShowings[1].transform;
            seeds[currentSeed + 1].transform.parent = aboveHeadShowings[2].transform;

            seeds[currentSeed - 1].transform.localPosition = Vector3.zero;
            seeds[currentSeed].transform.localPosition = Vector3.zero;
            seeds[currentSeed + 1].transform.localPosition = Vector3.zero;

            seeds[currentSeed - 1].transform.localScale = new Vector3(.85f, .85f, 1f);
            seeds[currentSeed].transform.localScale = new Vector3(1f, 1f, 1f);
            seeds[currentSeed + 1].transform.localScale = new Vector3(.85f, .85f, 1f);
        }
    }

    public void ResetSeedShown()
    {
        for (int i = 0; i < aboveHeadShowings.Count; i++)
        {
            foreach (Transform child in aboveHeadShowings[i].transform)
            {
                GameObject seedGameObject = child.gameObject;

                if (seedGameObject != null)
                {
                    seedGameObject.transform.parent = hiddenSeeds.transform;
                    seedGameObject.transform.position = Vector3.zero;
                    seedGameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                }
            }

        }
    }

    public void KeyPresses()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentSeed == 0)
            {
                currentSeed = seeds.Count - 1;
            }
            else
            {
                currentSeed--;
            }

            Debug.Log(currentSeed);

            finishShowing = false;
            cropManager.SetCropIndex(currentSeed);
            setParents = false;

        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentSeed == seeds.Count - 1)
            {
                currentSeed = 0;
            }
            else
            {
                currentSeed++;
            }

            Debug.Log(currentSeed);

            finishShowing = false;
            cropManager.SetCropIndex(currentSeed);
            setParents = false;
        }
    }

    public void ResetView()
    {
        timer = 0;
        setParents = false;
    }


}
