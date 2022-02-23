using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a class for all the fields that will be within the game.
/// This class is for holding the growth of the crops and updating images on the screen when necessary.
/// </summary>
public class Field : MonoBehaviour
{
    private float growTimer = 0;
    private int fieldNumber = 0;
    private Crop currentCrop;
    public List<GameObject> cropPlots;
    public Sprite soil;
    public Crop[] cropsCreated;
    public bool setCropPos = false;

    public int FieldNumber { get => fieldNumber; set => fieldNumber = value; }
    public float GrowTimer { get => growTimer; set => growTimer = value; }

    // Start is called before the first frame update
    void Start()
    {
        cropsCreated = new Crop[9];

        for(int i = 0; i < cropPlots.Count; i++)
        {
            cropPlots[i].GetComponent<CropPlot>().PlotNumber = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cropsCreated.Length; i++)
        {
            if(cropsCreated[i] != null)
            {
                cropPlots[i].GetComponent<SpriteRenderer>().sprite = cropsCreated[i].GetCurrentCropCycleImage();
            }
            else
            {
                cropPlots[i].GetComponent<SpriteRenderer>().sprite = soil;
            }
        }
    }

    /// <summary>
    /// Updates the crop image within the crop class.
    /// </summary>
    public void UpdateCropImage()
    {
        currentCrop.UpdateCurrentCropCycle();
    }

    /// <summary>
    /// Updates the crop images on the screen.
    /// </summary>
    public void UpdateGameImages()
    {
        for (int i = 0; i < cropPlots.Count; i++)
        {
            cropPlots[i].GetComponent<SpriteRenderer>().sprite = currentCrop.GetCurrentCropCycleImage();
        }
    }

    public Crop GetCropAtFieldPosition(int fieldPosition)
    { 
        return cropsCreated[fieldPosition];
    }

    /// <summary>
    /// Sets a crop to a position withing a field
    /// </summary>
    /// <param name="crop">The incoming crop that will go to a position in the field</param>
    /// <param name="fieldPosition">The field position where the crop will be planted at</param>
    public void SetCrop(Crop crop, int fieldPosition)
    {
        cropsCreated[fieldPosition] = crop;
        crop.Pos = fieldPosition;
    }

    /// <summary>
    /// Removes a crop from a specific field position
    /// </summary>
    /// <param name="fieldPosition">The position of the field the crop was harvested from</param>
    /// <returns>The amount a crop was harvested for</returns>
    public int RemoveCrop(int fieldPosition)
    {
        int cropAmount = cropsCreated[fieldPosition].GetHarvestAmount();
        cropsCreated[fieldPosition].Delete();
        cropsCreated[fieldPosition] = null;
        return cropAmount;
    }
}
