using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 velocity;
    [SerializeField] float upRay, downRay, horRay;
    [SerializeField] LayerMask boundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Movement();
    }

    void Movement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
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
        transform.Translate(moveInput * velocity * Time.deltaTime);
    }

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * horRay);
        Gizmos.DrawLine(transform.position, transform.position + transform.right * -horRay);
        Gizmos.DrawLine(transform.position, transform.position + transform.up * upRay);
        Gizmos.DrawLine(transform.position, transform.position + transform.up * -downRay);

    }
}
