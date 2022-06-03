using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public float Starter_Gold;
    public float Starter_Population;
    public TextMeshProUGUI Gold_Number;
    public TextMeshProUGUI Population_Number;
    public TextMeshProUGUI LeftDescription;
    public TextMeshProUGUI RightDescription;
    public GameObject LeftPanelDesc;
    public GameObject RightPanelDesc;
    public GameObject Blur;
    public GameObject HideButton;
    public GameObject RevealButton;
    private float Gold;
    private float Population;
    private GameObject CurrentCard;
    private Initiator Init;
    public Image FillKingdom;
    public float Starter_WarPoints;
    public float Starter_TehnoPoints;
    private float WarPoints;
    private float TechnoPoints;
    public Image FillWar;
    public Image FillTechno;
    public Image a;
    public Image b;
    public Image c;
    void Start()
    {
        Gold = Starter_Gold;
        Population = Starter_Population;
        TechnoPoints = Starter_TehnoPoints;
        WarPoints = Starter_WarPoints;
        Gold_Number.text = "" + Gold;
        Population_Number.text = "" + Population;
        LeftDescription.gameObject.SetActive(false);
        RightDescription.gameObject.SetActive(false);
        RevealButton.SetActive(false);
        Blur.SetActive(false);
        LeftPanelDesc.SetActive(false);
        RightPanelDesc.SetActive(false);
        Init = GameObject.FindWithTag("Game_Panel").GetComponent<Initiator>();
    }

    void Update()
    {
        Gold_Number.text = "" + Gold;
        Population_Number.text = "" + Population;
        FillKingdom.fillAmount = Population / 100;
        FillWar.fillAmount = WarPoints / 100;
        FillTechno.fillAmount = TechnoPoints / 100;
        if (Population <= 0)
        {
            Init.GameOver();
        }
    }

    //функции, меняющие ключевые значения.
    public void ChangeGold(float GValue)
    {
        Gold += + GValue;
    }
    public void ChangePopulation(float PValue)
    {
        Population += + PValue;
    }
    public void ChangeWarPoints(float WValue)
    {
        WarPoints += +WValue;
    }
    public void ChangeTehnoPoints(float TValue)
    {
        TechnoPoints += +TValue;
    }

    //фунцкии показа описаний.
    public void ShowLeft(string desc, bool check)
    {
        LeftDescription.text = desc;
        LeftDescription.gameObject.SetActive(check);
        Blur.SetActive(check);
        LeftPanelDesc.SetActive(check);
    }
    public void ShowRight(string desc, bool check)
    {
        RightDescription.text = desc;
        RightDescription.gameObject.SetActive(check);
        Blur.SetActive(check);
        RightPanelDesc.SetActive(check);
    }

    //функции скрытия/возвращения карты.
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
    public void HideUi(bool check)
    {
        a.enabled = check;
        b.enabled = check;
        c.enabled = check;
        FillKingdom.enabled = check;
        FillTechno.enabled = check;
        FillWar.enabled = check;
    }

    //Перезапуск игры.
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Выход из игры.
    public void Exit()
    {
        Application.Quit();
    }
}
