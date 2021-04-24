using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    // основные параметры
    public float speedMove; // скорость персонажа
    public float jumpPowe; // сила прыжка

    // ѕараметры геймпле€ дл€ персонажа
    private float gravityForce;//гравитаци€ персонажа
    private Vector3 moveVector;//направление движени€ персонажа


    //ссылки на компоненты
    private CharacterController ch_controller;
    private Animator ch_animator;

    private void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CharacterMove();
        GamingGraviti();
    }


    //метод перемещени€ персонажа
    private void CharacterMove()
    {
        // перемещение по поверхности
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speedMove;
        moveVector.z = Input.GetAxis("Vertical") * speedMove;

        if(Vector3.Angle(Vector3.forward,moveVector)>1f || Vector3.Angle(Vector3.forward, moveVector) ==0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        moveVector.y = gravityForce;
        ch_controller.Move(moveVector * Time.deltaTime);//метод передвижени€ по направлению
    }

    //метод гравитации

    private void GamingGraviti()
    {
        if (!ch_controller.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;
        if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded) gravityForce = jumpPowe;
    }





}
