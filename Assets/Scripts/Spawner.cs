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

    void Start()
    {
        //������ ������ ����� ����� � ������ � ������� ��������.
        timer = Random.Range(TborderDown, TborderUp);
    }


    void Update()
    {
        //����� �����
      ExCard = GameObject.FindWithTag("Card");
        if (ExCard == null)
        {
            //���� ����� ��� - ����������� ������, �� ����� �������� - ��������� �����.
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                int randomCardID = Random.Range(0, Cards.Length);
                Instantiate(Cards[randomCardID]);
                timer = Random.Range(TborderDown, TborderUp);
            }
        }
    }
}