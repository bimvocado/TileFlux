using System;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public int x = 0;
    public int y = 0;

    private Rigidbody2D rb;
    
    private void Start()
    {
        x = y = 7;
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector2(x, y);
    }

    private void Update()
    {
        if ((x != 0) && (Input.GetKeyDown(KeyCode.A)))
            x -= 1;
        else if ((x != 14) && (Input.GetKeyDown(KeyCode.D)))
            x += 1;
        else if ((y != 0) && (Input.GetKeyDown(KeyCode.S)))
            y -= 1;
        else if ((y != 14) && (Input.GetKeyDown(KeyCode.W)))
            y += 1;
        rb.position = new Vector2(x, y);
    }
}
