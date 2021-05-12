using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField]
    public CharacterController controller;

    [SerializeField]
    public float speed = 10f;

    [SerializeField]
    public float gravity = -9.81f;

    Vector3 velocity;
    bool isGrounded;
    Vector3 movement;
    float moveCharFB;
    float moveCharLR;
    

    void Update()
    {
        CharacterMovement();
    }

    void CharacterMovement()
    {
        if(controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        moveCharFB = Input.GetAxis("Vertical");
        moveCharLR = Input.GetAxis("Horizontal");

        //Esto movería el personaje en coordenas globales, lo que queremos es moverlo en las coordenadas del poropio personaje
        //movement = new Vector3(moveCharFB, moveCharLR);

        // dirección * w(+1) hace el movimiento siendo w la tecla presionada y +1 lo que suma
        movement = transform.right * moveCharLR + transform.forward * moveCharFB;


        //El motor controller dice de moverse, la acción es "movement" establecida en la linea de arriba * velocidad
        controller.Move(movement * speed * Time.deltaTime);
        
        //Sin velocidad en el eje y que afecte con gravedad, no volverá a bajar cuando suba escaleras
        velocity.y += gravity * Time.deltaTime;

        //afecta la gravedad al tiempo
        controller.Move(velocity * Time.deltaTime);
    }


}
