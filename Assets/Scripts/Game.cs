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
    public TextMeshProUGUI LeftDescription;
    public TextMeshProUGUI RightDescription;
    public GameObject HideButton;
    public GameObject RevealButton;
    private GameObject CurrentCard;

    void Start()
    {
        Gold = Starter_Gold;
        Population = Starter_Population;
        Gold_Number.text = "«лато: " + Gold;
        Population_Number.text = "ƒворы: " + Population;
        LeftDescription.gameObject.SetActive(false);
        RightDescription.gameObject.SetActive(false);
        RevealButton.SetActive(false);
    }

    void Update()
    {
        Gold_Number.text = "«лато: " + Gold;
        Population_Number.text = "ƒворы: " + Population;
    }

    //функции, мен€ющие ключевые значени€.
    public void ChangeGold(float GValue)
    {
        Gold += + GValue;
    }
    public void ChangePopulation(float PValue)
    {
        Population += + PValue;
    }

    //фунцкии показа описаний.
    public void ShowLeft(string desc, bool check)
    {
        LeftDescription.text = desc;
        LeftDescription.gameObject.SetActive(check);
    }
    public void ShowRight(string desc, bool check)
    {
        RightDescription.text = desc;
        RightDescription.gameObject.SetActive(check);
    }

    //функции скрыти€/возвращени€ карты
    public void HideCard()
    { 
        CurrentCard = GameObject.FindWithTag("Card");
        CurrentCard.GetComponent<Renderer>().enabled = false;
        CurrentCard.GetComponent<Collider2D>().enabled = false;
        RevealButton.SetActive(true);
        HideButton.SetActive(false);
    }
    public void RevealCard()
    {
        CurrentCard = GameObject.FindWithTag("Card");
        CurrentCard.GetComponent<Renderer>().enabled = true;
        CurrentCard.GetComponent<Collider2D>().enabled = true;
        RevealButton.SetActive(false);
        HideButton.SetActive(true);
    }
}
