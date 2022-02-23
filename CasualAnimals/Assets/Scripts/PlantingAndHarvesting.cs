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

    public GameObject player;
    public PlayerScript playerScript;

    private int noCrop = -1;

    // Start is called before the first frame update
    void Start()
    {
        amountHarvested = 0;
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.E) && cropManager.fields[0].GetCropAtFieldPosition(0) == null)
        {
            for (int i = 0; i < 9; i++)
            {
                cropManager.CreateCropToField(0, i);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && cropManager.fields[0].GetCropAtFieldPosition(0).harvestable)
        {
            for (int i = 0; i < 9; i++)
            {
                amountHarvested += cropManager.RemoveCropToField(0, i);
            }
        }

        eggplantsHarvested.text = amountHarvested.ToString();*/

        if(playerScript.CurrentCropStand == -1)
        {
            //do nothing
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            int[] fieldPosition = { playerScript.CurrentFieldStand, playerScript.CurrentFieldStand };

            if(fieldPosition[0] == noCrop || fieldPosition[1] == noCrop)
            {
                return;
            }


            if(cropManager.fields[fieldPosition[0]].GetComponent<Field>().GetCropAtFieldPosition(fieldPosition[1]) == null)
            {
                cropManager.CreateCropToField(fieldPosition[0], fieldPosition[1]);
                //cropPosGrowing.Add(fieldPosition[1]);
            }
            else if(cropManager.fields[fieldPosition[0]].GetComponent<Field>().GetCropAtFieldPosition(fieldPosition[1]).harvestable)
            {
                amountHarvested += cropManager.RemoveCropToField(fieldPosition[0], fieldPosition[1]);
                //int index = cropPosGrowing.IndexOf(playerScript.CurrentCropStand);
                //cropPosGrowing.RemoveAt();
            }
        }

        eggplantsHarvested.text = amountHarvested.ToString();
    }

    /*public int[] CheckCollisionWithField()
    {
        BoxCollider2D playerCollider = player.GetComponent<BoxCollider2D>();

        for (int i = 0; i < cropManager.fields.Count; i++)
        {
            Field currentField = cropManager.fields[i].GetComponent<Field>();

            if (cropManager.fields[i].GetComponent<BoxCollider2D>().IsTouching(playerCollider)){
                for (int j = 0; j < currentField.cropImages.Count; j++)
                {
                    if (currentField.cropImages[j].GetComponent<BoxCollider2D>().IsTouching(playerCollider))
                    {
                        int[] fieldPosition = { i, j };
                        return fieldPosition;
                    }
                }
            }
        }

        return null;
    }*/

/*    public bool CheckCollision(GameObject fieldPosition)
    {
        BoxCollider2D playerCollider = player.GetComponent<BoxCollider2D>();
        BoxCollider2D fieldCollider = fieldPosition.GetComponent<BoxCollider2D>();



        return false;
    }*/
}
