using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Crop class that allows for a crop to grow over a certain period of time
/// The crop also has different sprites based on how far along the crop has been planted.
/// </summary>
public class Crop : MonoBehaviour
{

    public string Name; // the name of the crop
    public int growthTime; // the amount of time for the crop to grow
    public List<Sprite> cropCycles; //images for the different crop growth cycles
    public int harvestAmount; //The amount of crop that will be awarded to a player when a crop is harvested
    public bool harvestable = false; //can the crop be harvestable
    private int currentCropCycle; //value of the current crop cycle
    private float currentGrowthTimer; //timer that holds the current growth of the crop
    private bool startGrowth; //Value that holds whether a crop should grow or not

    // Start is called before the first frame update
    void Start()
    {
        currentCropCycle = 0;
        currentGrowthTimer = 0;
        startGrowth = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentGrowthTimer += Time.deltaTime;


        if(currentGrowthTimer >  (growthTime / 3) && currentGrowthTimer < (growthTime / 3 * 2))
        {
            currentCropCycle = 1;
        }
        else if(currentGrowthTimer > (growthTime / 3 * 2) && currentGrowthTimer < growthTime)
        {
            currentCropCycle = 2;
        }
        else if(currentGrowthTimer > growthTime){
            currentCropCycle = 3;
            harvestable = true;
        }
    }

    /// <summary>
    /// Returns the current crop cycle sprite
    /// </summary>
    /// <returns>The current Crop cycle sprite</returns>
    public Sprite GetCurrentCropCycleImage()
    {
        return cropCycles[currentCropCycle];
    }

    /// <summary>
    /// Updates the current crop cycle sprite
    /// </summary>
    public void UpdateCurrentCropCycle()
    {
        if(currentCropCycle < cropCycles.Count - 1)
        {
            currentCropCycle++;
        }
    }

    /// <summary>
    /// Initializes the growing process on this crop
    /// </summary>
    public void StartGrowing()
    {
        startGrowth = true;
    }

    /// <summary>
    /// Gets the amount of crop returned upon harvesting
    /// </summary>
    /// <returns></returns>
    public int GetHarvestAmount()
    {
        return harvestAmount;
    }

    /// <summary>
    /// Destroys the gameobject created
    /// </summary>
    public void Delete()
    {
        Destroy(this.gameObject);
    }
}
