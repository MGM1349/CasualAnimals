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
    private Crop currentCrop;
    public List<Image> cropImages;
    public Sprite soil;
    public Crop[] fieldPositions;

    public float GrowTimer { get => growTimer; set => growTimer = value; }

    // Start is called before the first frame update
    void Start()
    {
        fieldPositions = new Crop[9];
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < fieldPositions.Length; i++)
        {
            if(fieldPositions[i] != null)
            {
                cropImages[i].sprite = fieldPositions[i].GetCurrentCropCycleImage();
            }
            else
            {
                cropImages[i].sprite = soil;
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
        for (int i = 0; i < cropImages.Count; i++)
        {
            cropImages[i].sprite = currentCrop.GetCurrentCropCycleImage();
        }
    }

    public Crop GetCropAtFieldPosition(int fieldPosition)
    { 
        return fieldPositions[fieldPosition];
    }

    /// <summary>
    /// Sets a crop to a position withing a field
    /// </summary>
    /// <param name="crop">The incoming crop that will go to a position in the field</param>
    /// <param name="fieldPosition">The field position where the crop will be planted at</param>
    public void SetCrop(Crop crop, int fieldPosition)
    {
        fieldPositions[fieldPosition] = crop;
    }

    /// <summary>
    /// Removes a crop from a specific field position
    /// </summary>
    /// <param name="fieldPosition">The position of the field the crop was harvested from</param>
    /// <returns>The amount a crop was harvested for</returns>
    public int RemoveCrop(int fieldPosition)
    {
        int cropAmount = fieldPositions[fieldPosition].GetHarvestAmount();
        fieldPositions[fieldPosition].Delete();
        fieldPositions[fieldPosition] = null;
        return cropAmount;
    }



}
