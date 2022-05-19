using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public float Gold_Effect_Right;
    public float Population_Effect_Right;
    public float Gold_Effect_Left;
    public float Population_Effect_Left;
    public string Right_Desc;
    public string Left_Desc;
    private Game mainscript;
    private GameObject mainpanel;
    private GameObject SelectedCard;
    private float left_choice_count;
    private float right_choice_count;
    private Vector3 startpoint;
    private Vector3 offset;
    private Vector3 cardpoint;
    private Rigidbody2D rb;

    void Start()
    {
        startpoint = new Vector3(0, 0, 0);
        mainpanel = GameObject.FindWithTag("Game_Panel");
        mainscript = mainpanel.GetComponent<Game>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    //счётчики коллизии.
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Left_Choice")
        {
            left_choice_count += 1;
        }
        else if (col.gameObject.tag == "Right_Choice")
        {
            right_choice_count += 1;
        }
    }

    //счётчики ухода с коллизии.
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Left_Choice")
        {
            left_choice_count -= 1;
        }
        else if (col.gameObject.tag == "Right_Choice")
        {
            right_choice_count -= 1;
        }
    }

    void Update()
    {
        //"хватание" карты.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.CompareTag("Card"))
            {
                SelectedCard = targetObject.transform.gameObject;
                offset = SelectedCard.transform.position - mousePosition;
            }
        }

        //перемещение карты за курсором.
        if (SelectedCard)
        {
            SelectedCard.transform.localScale = new Vector3((float)0.4, (float)0.4, (float)1);
            SelectedCard.transform.position = mousePosition + offset;
            SelectedCard.transform.rotation = Quaternion.Euler(0, 0, SelectedCard.transform.position.x * 5);
        }

        //отображение описания.
        if (left_choice_count >= 1)
        {
            mainscript.ShowLeft(Left_Desc, true);
        }
        if (right_choice_count >= 1)
        {
            mainscript.ShowRight(Right_Desc, true);
        }

        //скрытие описания.
        if (left_choice_count <= 0)
        {
            mainscript.ShowLeft(Left_Desc, false);
        }
        if (right_choice_count <= 0)
        {
            mainscript.ShowRight(Right_Desc, false);
        }

        //действия при "отпускании" карты.
        if (Input.GetButtonUp("Fire1") && SelectedCard)
        {
            if (left_choice_count >= 1)
            {
                Debug.Log("So you have chosen Left!");
                mainscript.ChangeGold(Gold_Effect_Left);
                mainscript.ChangePopulation(Population_Effect_Left);
                mainscript.ShowLeft(Left_Desc, false);
                Destroy(SelectedCard);
            }
            else if (right_choice_count >= 1)
            {
                Debug.Log("So you have chosen Right!");
                mainscript.ChangeGold(Gold_Effect_Right);
                mainscript.ChangePopulation(Population_Effect_Right);
                mainscript.ShowRight(Right_Desc, false);
                Destroy(SelectedCard);
            }
            else
            {
                //StartCoroutine(CardReturn());
                for (int i = 0; i < 4; i++)
                {
                    rb.velocity = (startpoint - SelectedCard.transform.position);
                }
            }
        }
    }

    //возвращение карты в нули.
    //IEnumerator CardReturn()
    //{
    //    while (SelectedCard.transform.position != startpoint)
    //    {
    //            SelectedCard.transform.position = Vector3.Lerp(SelectedCard.transform.position, startpoint, (float)0.5);
    //    }
    //    SelectedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
    //    SelectedCard.transform.localScale = new Vector3((float)0.5, (float)0.5, (float)1);
    //    SelectedCard = null;
    //    yield return new WaitForEndOfFrame();
    //}
}
