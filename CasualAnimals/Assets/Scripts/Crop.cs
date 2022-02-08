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
    public bool harvestable = false; //can the crop be harvestable
    public string Name; // the name of the crop
    public int growthTime; // the amount of time for the crop to grow
    public List<Sprite> cropCycles; //images for the different crop growth cycles
    private int currentCropCycle; //value of the current crop cycle

    // Start is called before the first frame update
    void Start()
    {
        currentCropCycle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
