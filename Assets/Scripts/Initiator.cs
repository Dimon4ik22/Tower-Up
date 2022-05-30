using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initiator : MonoBehaviour
{
    public GameObject[] Spawners;
    public GameObject[] Choise;
    public float MinCardNum;
    public float MaxCardNum;
    private GameObject ActiveSpawner;
    private float SpawnNumber;
    private float CardNumber = 0;

    void Start()
    {
        
    }

    void Update()
    {

    }

    //Запуск политических карт.
    public void SpawnPol()
    {
        ActiveSpawner = Spawners[0];
        SpawnNumber = Random.Range(MinCardNum, MaxCardNum);
        ActiveSpawner.SetActive(true);
        foreach (GameObject BT in Choise)
        {
            BT.SetActive(false);
        }
    }

    //Запуск военных карт.
    public void SpawnWar()
    {
        ActiveSpawner = Spawners[1];
        SpawnNumber = Random.Range(MinCardNum, MaxCardNum);
        ActiveSpawner.SetActive(true);
        foreach (GameObject BT in Choise)
        {
            BT.SetActive(false);
        }
    }

    //Запуск городских карт.
    public void SpawnCity()
    {
        ActiveSpawner = Spawners[2];
        SpawnNumber = Random.Range(MinCardNum, MaxCardNum);
        ActiveSpawner.SetActive(true);
        foreach (GameObject BT in Choise)
        {
            BT.SetActive(false);
        }
    }

    //Запуск технических карт.
    public void SpawnTech()
    {
        ActiveSpawner = Spawners[3];
        SpawnNumber = Random.Range(MinCardNum, MaxCardNum);
        ActiveSpawner.SetActive(true);
        foreach (GameObject BT in Choise)
        {
            BT.SetActive(false);
        }
    }

    //Функция подсчёта использованных карт в выбранной категории.
    public void Counter()
    {
        CardNumber += 1;
        if (CardNumber >= SpawnNumber+1)
        {
            Destroy(GameObject.FindWithTag("Card"));
            ActiveSpawner.SetActive(false);
            foreach (GameObject BT in Choise)
            {
                BT.SetActive(true);
            }
            CardNumber = 0;
        }
    }
}
