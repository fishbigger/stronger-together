using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WhichPlayer
{
    Player_1,
    Player_2
}

public class PlayerController : MonoBehaviour
{
    public WhichPlayer player;

    public Transform lookAt;

    public Rigidbody2D rb;

    public float rotateSpeed;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == WhichPlayer.Player_1)
        {
            HandlePlayer1();
        }
    }

    void HandlePlayer1()
    {
        if (Input.GetKey(KeyCode.A))
        {
            lookAt.RotateAround(transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            lookAt.RotateAround(transform.position, Vector3.back, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * moveSpeed;
        }

        Vector2 lookDir = lookAt.position - transform.position;
        float Angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, Angle);
    }
}
