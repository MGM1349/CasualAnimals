using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class that will manage all the crops that go to different fields. 
/// This class will also hold an index of all the crops.
/// </summary>
public class CropManager : MonoBehaviour
{
    //public Dictionary<string, GameObject> cropIndex;
    public List<GameObject> fields;
    public List<GameObject> crops;
    private int cropIndex;
    private GameObject currentCrop;

    // Start is called before the first frame update
    void Start()
    {
        currentCrop = null;

        for (int i = 0; i < fields.Count; i++)
        {
            fields[i].GetComponent<Field>().FieldNumber = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCropIndex(int vCropIndex)
    {
        cropIndex = vCropIndex;
    }

    /// <summary>
    /// Adds a crop from the given crops to a specfic position within a field.
    /// </summary>
    /// <param name="fieldNumber">The field number tha tthe crop will be added to</param>
    /// <param name="fieldPosition">The field position the crop is going into</param>
    public void CreateCropToField(int fieldNumber, int fieldPosition)
    {
        currentCrop = Instantiate(crops[cropIndex]);
        fields[fieldNumber].GetComponent<Field>().SetCrop(currentCrop.GetComponent<Crop>(), fieldPosition);
    }


    /// <summary>
    /// Removes certain crops from specific positions in the field
    /// </summary>
    /// <param name="fieldNumber">The field number tha tthe crop will be added to</param>
    /// <param name="fieldPosition">The field position the crop is going into</param>
    /// <returns>the amount of crop harvested</returns>
    public int RemoveCropToField(int fieldNumber, int fieldPosition)
    {
        return fields[fieldNumber].GetComponent<Field>().RemoveCrop(fieldPosition);
    }
}
