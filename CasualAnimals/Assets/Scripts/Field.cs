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

    public Crop CurrentCrop { get => currentCrop; set => currentCrop = value; }
    public float GrowTimer { get => growTimer; set => growTimer = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //growTimer += Time.deltaTime;
        //
        //if(growTimer >  (currentCrop.growthTime / 3 * 2))
        //{
        //  UpdateCropImage();
        //  UpdateGameImages();
        //}
        //else if(growTimer > (currentCrop.growthTime / 3))
        //{
        //  UpdateCropImage();
        //  UpdateGameImages();
        //}
        //if(growTimer > (currentCrop.growthTime){
        //  UpdateCropImage();
        //  UpdateGameImages();
        //  currentCrop.harvestable = true;
        //}
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

}
