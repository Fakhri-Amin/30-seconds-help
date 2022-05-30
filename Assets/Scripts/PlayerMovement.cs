using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private float movementVelocity = 3f;
    private Rigidbody2D rb;
    private float inputX;
    private float inputY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        FaceDirection();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX, inputY).normalized * movementVelocity;
    }

    private void FaceDirection()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 gunPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - gunPos.x;
        mousePos.y = mousePos.y - gunPos.y;

        float gunAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
        {
            // transform.rotation = Quaternion.Euler(new Vector3(180f, 0f, 0f));
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            // transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            transform.localScale = new Vector3(1, 1, 1);

        }
    }
}
