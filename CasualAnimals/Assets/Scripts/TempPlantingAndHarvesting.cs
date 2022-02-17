using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TempPlantingAndHarvesting : MonoBehaviour
{

    public CropManager cropManager;
    private int amountHarvested;
    public TextMeshProUGUI eggplantsHarvested;

    public List<int> cropPosGrowing;

    public PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        amountHarvested = 0;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E) && cropManager.fields[0].GetCropAtFieldPosition(0) == null)
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
        //        cropManager.CreateCropToField(0, i);
        //    }
        //}
        //else if (Input.GetKeyDown(KeyCode.E) && cropManager.fields[0].GetCropAtFieldPosition(0).harvestable)
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
        //        amountHarvested += cropManager.RemoveCropToField(0, i);
        //    }
        //}

        //eggplantsHarvested.text = amountHarvested.ToString();

        if(playerScript.CurrentCropStand == -1)
        {
            //do nothing
        }
        else if (Input.GetKeyDown(KeyCode.E) && cropManager.fields[0].GetCropAtFieldPosition(playerScript.CurrentCropStand) == null)
        {
            cropManager.CreateCropToField(0, playerScript.CurrentCropStand);
            cropPosGrowing.Add(playerScript.CurrentCropStand);
        }
        else if (Input.GetKeyDown(KeyCode.E) && cropManager.fields[0].GetCropAtFieldPosition(playerScript.CurrentCropStand).harvestable)
        {
            amountHarvested += cropManager.RemoveCropToField(0, playerScript.CurrentCropStand);
            int index = cropPosGrowing.IndexOf(playerScript.CurrentCropStand);
            cropPosGrowing.RemoveAt(index);
        }

        eggplantsHarvested.text = amountHarvested.ToString();
    }
}
