using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Cards;
    public float TborderUp;
    public float TborderDown;
    private float timer;
    private GameObject ExCard;
    private Initiator Init;

    void Start()
    {
        //таймер спавна новой карты с нижней и верхней границей.
        timer = Random.Range(TborderDown, TborderUp);
        Init = GameObject.FindWithTag("Game_Panel").GetComponent<Initiator>();
    }


    void Update()
    {
        //поиск карты
      ExCard = GameObject.FindWithTag("Card");
        if (ExCard == null)
        {
            //если карты нет - запускается таймер, по итогу которого - спавнится карта.
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                int randomCardID = Random.Range(0, Cards.Length);
                Instantiate(Cards[randomCardID]);
                timer = Random.Range(TborderDown, TborderUp);
                Init.Counter();
            }
        }
    }
}