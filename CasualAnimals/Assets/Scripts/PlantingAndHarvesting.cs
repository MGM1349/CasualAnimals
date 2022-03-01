using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantingAndHarvesting : MonoBehaviour
{

    public CropManager cropManager;
    private int amountHarvested;
    public TextMeshProUGUI eggplantsHarvested;

    public List<int> cropPosGrowing;

    public PlayerScript playerScript;

    public SeedManager seedManager;



    private int noCrop = -1;

    // Start is called before the first frame update
    void Start()
    {
        amountHarvested = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            int[] fieldPosition = { playerScript.CurrentFieldStand, playerScript.CurrentCropStand  };

            if(fieldPosition[0] == noCrop || fieldPosition[1] == noCrop)
            {
                return;
            }


            if(cropManager.fields[fieldPosition[0]].GetComponent<Field>().GetCropAtFieldPosition(fieldPosition[1]) == null)
            {
                cropManager.CreateCropToField(fieldPosition[0], fieldPosition[1]);
            }
            else if(cropManager.fields[fieldPosition[0]].GetComponent<Field>().GetCropAtFieldPosition(fieldPosition[1]).harvestable)
            {
                amountHarvested += cropManager.RemoveCropToField(fieldPosition[0], fieldPosition[1]);
            }
        }

        eggplantsHarvested.text = amountHarvested.ToString();
    }
}
