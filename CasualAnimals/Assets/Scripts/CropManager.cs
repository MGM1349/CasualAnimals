using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class that will manage all the crops that go to different fields. 
/// This class will also hold an index of all the crops.
/// </summary>
public class CropManager : MonoBehaviour
{
    public Dictionary<string, GameObject> cropIndex;
    public List<Field> fields;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Adds a crop from the dictionary to a given field.
    /// </summary>
    /// <param name="key">The key for the dictionary.</param>
    /// <param name="fieldNumber">The field number tha tthe crop will be added to</param>
    public void CreateCropToField(string key, int fieldNumber)
    {
        fields[fieldNumber].CurrentCrop = cropIndex[key].GetComponent<Crop>();
    }
}
