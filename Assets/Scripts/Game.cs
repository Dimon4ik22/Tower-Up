using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    private float Gold;
    private float Population;
    public float Starter_Gold;
    public float Starter_Population;
    public TextMeshProUGUI Gold_Number;
    public TextMeshProUGUI Population_Number;

    void Start()
    {
        Gold = Starter_Gold;
        Population = Starter_Population;
        Gold_Number.text = "«лато: " + Gold;
        Population_Number.text = "ƒворы: " + Population;
    }

    void Update()
    {
        Gold_Number.text = "«лато: " + Gold;
        Population_Number.text = "ƒворы: " + Population;
    }

    public void ChangeGold(float GValue)
    {
        Gold += + GValue;
    }
    public void ChangePopulation(float PValue)
    {
        Population += + PValue;
    }
}
