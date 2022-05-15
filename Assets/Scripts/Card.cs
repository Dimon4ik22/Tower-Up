using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private GameObject SelectedCard;
    private float left_choice_count;
    private float right_choice_count;
    private Vector3 startpoint;
    private Vector3 offset;

    void Start()
    {
        startpoint = new Vector3(0, 0, 0);
    }

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

    void OnCollisionExit2D(Collision2D col)
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

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                SelectedCard = targetObject.transform.gameObject;
                offset = SelectedCard.transform.position - mousePosition;
            }
        }

        if (SelectedCard)
        {
            SelectedCard.transform.localScale = new Vector3((float)0.4, (float)0.4, (float)1);
            SelectedCard.transform.position = mousePosition + offset;
            SelectedCard.transform.rotation = Quaternion.Euler(0, 0, SelectedCard.transform.position.x * 5);
        }
        if (Input.GetButtonUp("Fire1") && SelectedCard)
        {
            if (left_choice_count >= 1)
            {
                Debug.Log("So you have chosen Left!");
                Destroy(this.gameObject);
            }
            else if (right_choice_count >= 1)
            {
                Debug.Log("So you have chosen Right!");
                Destroy(SelectedCard);
            }
            else
            {
                CardReturn();
            }
        }
    }
    void CardReturn()
    {
        while (SelectedCard.transform.position != startpoint)
        {
            SelectedCard.transform.position = Vector3.MoveTowards(SelectedCard.transform.position, startpoint, (float)0.01 * Time.deltaTime);
        }
        SelectedCard.transform.rotation = Quaternion.Euler(0, 0, 0);
        SelectedCard.transform.localScale = new Vector3((float)0.5, (float)0.5, (float)1);
        SelectedCard = null;
    }
}
