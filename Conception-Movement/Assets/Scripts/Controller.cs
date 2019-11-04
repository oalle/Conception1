using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 10;
    public float rotationRate = 180;
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";
    public float minToMove = 0.1f;

    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);
        ApplyInput(moveAxis, turnAxis);

        if (moveAxis > minToMove || moveAxis < -minToMove)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void ApplyInput(float move, float turn)
    {
        Move(move);
    }

    private void Move(float input)
    {
        transform.Translate(Vector3.forward * input * Time.deltaTime * speed);
    }

}
