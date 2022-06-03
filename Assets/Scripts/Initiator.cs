using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initiator : MonoBehaviour
{
    public GameObject[] Spawners;
    public GameObject[] Choise;
    public Sprite[] ClickerCards;
    public GameObject Blur;
    public GameObject Clicker_Text;
    public GameObject ClickerBar;
    public GameObject ClickerCard;
    public GameObject GameOverMenu;
    public Image ClickerImage;
    public float MinCardNum;
    public float MaxCardNum;
    public float Clicker;
    private float Clicker_Count = 0;
    private float SpawnNumber;
    private float CardNumber = 0;
    private GameObject ActiveSpawner;
    private Game mainscript;
    private GameObject mainpanel;

    //Запуск политических карт.
    public void Start()
    {
        mainpanel = GameObject.FindWithTag("Game_Panel");
        mainscript = mainpanel.GetComponent<Game>();
    }
    public void SpawnPol()
    {
        ActiveSpawner = Spawners[0];
        SpawnNumber = Random.Range(MinCardNum, MaxCardNum);
        foreach (GameObject BT in Choise)
        {
            BT.SetActive(false);
        }
        Clicker_Text.SetActive(true);
        ClickerBar.SetActive(true);
        ClickerCard.SetActive(true);
        mainscript.HideUi(false);
        ClickerImage.sprite = ClickerCards[0];
    }

    //Запуск военных карт.
    public void SpawnWar()
    {
        ActiveSpawner = Spawners[1];
        SpawnNumber = Random.Range(MinCardNum, MaxCardNum);
        foreach (GameObject BT in Choise)
        {
            BT.SetActive(false);
        }
        Clicker_Text.SetActive(true);
        ClickerBar.SetActive(true);
        ClickerCard.SetActive(true);
        mainscript.HideUi(false);
        ClickerImage.sprite = ClickerCards[1];
    }

    //Запуск городских карт.
    public void SpawnCity()
    {
        ActiveSpawner = Spawners[2];
        SpawnNumber = Random.Range(MinCardNum, MaxCardNum);
        foreach (GameObject BT in Choise)
        {
            BT.SetActive(false);
        }
        Clicker_Text.SetActive(true);
        ClickerBar.SetActive(true);
        ClickerCard.SetActive(true);
        mainscript.HideUi(false);
        ClickerImage.sprite = ClickerCards[2];
    }

    //Запуск технических карт.
    public void SpawnTech()
    {
        ActiveSpawner = Spawners[3];
        SpawnNumber = Random.Range(MinCardNum, MaxCardNum);
        foreach (GameObject BT in Choise)
        {
            BT.SetActive(false);
        }
        Clicker_Text.SetActive(true);
        ClickerBar.SetActive(true);
        ClickerCard.SetActive(true);
        mainscript.HideUi(false);
        ClickerImage.sprite = ClickerCards[3];
    }

    //Функция подсчёта использованных карт в выбранной категории.
    public void Counter()
    {
        CardNumber += 1;
        if (CardNumber >= SpawnNumber+1)
        {
            Destroy(GameObject.FindWithTag("Card"));
            ActiveSpawner.SetActive(false);
            ActiveSpawner = null;
            foreach (GameObject BT in Choise)
            {
                BT.SetActive(true);
            }
            Blur.SetActive(true);
            CardNumber = 0;
            Clicker_Count = 0;
        }
    }

    //Кликер. Вызывается кнопкой в виде карты.
    public void Click()
    {
            Clicker_Count += 1;
        if (Clicker_Count == Clicker)
        {
            ActiveSpawner.SetActive(true);
            Blur.SetActive(false);
            ClickerCard.SetActive(false);
            Clicker_Text.SetActive(false);
            ClickerBar.SetActive(false);
            mainscript.HideUi(true);
        }
    }

    //Конец игры. И отображение соответствующего меню.
    public void GameOver()
    { 
        ActiveSpawner.SetActive(false);
        Blur.SetActive(true);
        GameOverMenu.SetActive(true);
    }
}
