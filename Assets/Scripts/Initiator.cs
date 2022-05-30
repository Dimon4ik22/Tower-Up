using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initiator : MonoBehaviour
{
    public GameObject[] Spawners;
    public GameObject[] Choise;
    public GameObject Blur;
    public GameObject Clicker_Text;
    public float MinCardNum;
    public float MaxCardNum;
    public float Clicker;
    private float Clicker_Count = 0;
    private float SpawnNumber;
    private float CardNumber = 0;
    private GameObject ActiveSpawner;

    //������ ������������ ����.
    public void SpawnPol()
    {
        ActiveSpawner = Spawners[0];
        SpawnNumber = Random.Range(MinCardNum, MaxCardNum);
        foreach (GameObject BT in Choise)
        {
            BT.SetActive(false);
        }
        Clicker_Text.SetActive(true);
    }

    //������ ������� ����.
    public void SpawnWar()
    {
        ActiveSpawner = Spawners[1];
        SpawnNumber = Random.Range(MinCardNum, MaxCardNum);
        foreach (GameObject BT in Choise)
        {
            BT.SetActive(false);
        }
        Clicker_Text.SetActive(true);
    }

    //������ ��������� ����.
    public void SpawnCity()
    {
        ActiveSpawner = Spawners[2];
        SpawnNumber = Random.Range(MinCardNum, MaxCardNum);
        foreach (GameObject BT in Choise)
        {
            BT.SetActive(false);
        }
        Clicker_Text.SetActive(true);
    }

    //������ ����������� ����.
    public void SpawnTech()
    {
        ActiveSpawner = Spawners[3];
        SpawnNumber = Random.Range(MinCardNum, MaxCardNum);
        foreach (GameObject BT in Choise)
        {
            BT.SetActive(false);
        }
        Clicker_Text.SetActive(true);
    }

    //������� �������� �������������� ���� � ��������� ���������.
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

    //������. �� ��� ��� �� �������, ����� �� �����.
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ActiveSpawner != null)
        {
            Clicker_Count += 1;
        }

        if (Clicker_Count == Clicker)
        {
            ActiveSpawner.SetActive(true);
            Blur.SetActive(false);
            Clicker_Text.SetActive(false);
        }
    }
}
