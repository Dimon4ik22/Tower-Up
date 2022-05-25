using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Cards;
    public int TborderUp;
    public int TborderDown;
    private int timer;
    private GameObject ExCard;

    void Start()
    {
        //таймер спавна новой карты с нижней и верхней границей.
        timer = Random.Range(TborderDown, TborderUp);
    }


    void Update()
    {
        //поиск карты
      ExCard = GameObject.FindWithTag("Card");
        if (ExCard == null)
        {
            //если карты нет - запускается таймер, по итогу которого - спавнится карта.
            timer -= 1;
            if (timer <= 0)
            {
                int randomCardID = Random.Range(0, Cards.Length);
                Instantiate(Cards[randomCardID]);
                timer = Random.Range(TborderDown, TborderUp);
            }
        }
    }
}