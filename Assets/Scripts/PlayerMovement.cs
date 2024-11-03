using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 velocity;              //Velocidad de movimiento
    [SerializeField] float upRay, downRay, horRay;  //Indica la longitud de los Raycast que se usan para que wl jugador no salga de la pantalla
    [SerializeField] LayerMask boundLayer;          //Indica una máscara de capa con la que interactúan los RayCast

    void Update()
    {

        Movement();
    }

    void Movement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));  //Se almacenan los Inputs de movimiento en un Vector2

        //Llama a las funciones que evitan que el jugador se salga de la pantalla,
        //modificando el valor del Input de Movimiento cuando sea necesario
        if (moveInput.y > 0)
        {
            if (CheckBoundsUp()) { moveInput.y = 0; }
        }
        if (moveInput.y < 0)
        {
            if (CheckBoundsDown()) { moveInput.y = 0; }
        }
        if (moveInput.x > 0)
        {
            if (CheckBoundsRight()) { moveInput.x = 0; }
        }
        if (moveInput.x < 0)
        {
            if (CheckBoundsLeft()) { moveInput.x = 0; }
        }

        transform.Translate(moveInput * velocity * Time.deltaTime);     //Aplica un desplazamiento en funcion del valor del MoveInput y la velocidad
    }


    //Estas cuatro funciones chequean si el jugador está cerca de alguno de los límiter de la pantalla
    //Y devuelven un valor TRUE cuando sucede
    bool CheckBoundsUp()
    {
        return Physics2D.Raycast(transform.position, Vector2.up, upRay, boundLayer);
    }
    bool CheckBoundsDown()
    {
        return Physics2D.Raycast(transform.position, Vector2.up, -upRay, boundLayer);
    }
    bool CheckBoundsLeft()
    {
        return Physics2D.Raycast(transform.position, Vector2.right, -horRay, boundLayer);

    }
    bool CheckBoundsRight()
    {
        return Physics2D.Raycast(transform.position, Vector2.right, horRay, boundLayer);

    }

    //Esta función solo funciona en el editor, sirve para dibujar los gizmos qeu representan los Raycast que utilizamos para comprobar los límites del juego
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * horRay);
        Gizmos.DrawLine(transform.position, transform.position + transform.right * -horRay);
        Gizmos.DrawLine(transform.position, transform.position + transform.up * upRay);
        Gizmos.DrawLine(transform.position, transform.position + transform.up * -downRay);

    }
}
