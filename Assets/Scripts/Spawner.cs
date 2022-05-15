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
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(TborderDown, TborderUp);
    }

    // Update is called once per frame
    void Update()
    {
      ExCard = GameObject.FindWithTag("Card");
        if (ExCard == null)
        {
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