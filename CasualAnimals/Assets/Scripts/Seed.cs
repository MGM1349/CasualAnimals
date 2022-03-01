using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Seed : MonoBehaviour
{
    [Header("Script Info")]
    public int seedAmount;


    [Header("Text Objects")]
    public TextMeshPro SeedAmountText;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SeedAmountText.text = seedAmount.ToString();
    }

    public void UpdateSeedAmount(int amount)
    {
        seedAmount += amount;
    }
}
