using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float speed = 1;
    public float vertical;
    public float horizonal;

    // Update is called once per frame
    void Update()
    {
        GetKey();
        Move();
    }

    public void Move()
    {
        float normalSpeed = speed * Time.deltaTime;
        transform.Translate(horizonal * normalSpeed, 0, vertical * normalSpeed);
        //ActiveAnimation();
    }

    public void ActiveAnimation()
    {
        Animator action = GetComponent<Animator>();
        if ((vertical != 0 || horizonal != 0))
        {
            // when the player move
            action.speed = 1;
            if (action.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) action.Play("Run", -1, 0f);
            else action.Play("Run");
        }
        else
        {
            // when the player stop move
            action.speed = 0.8f;
            if (action.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) action.Play("Ideal", -1, 0f);
            else action.Play("Ideal");
        }
    }

    public void GetKey()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizonal = Input.GetAxisRaw("Horizontal");
    }
}