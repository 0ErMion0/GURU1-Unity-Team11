using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 1000.0f;
    Rigidbody2D rigid2D;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");       //좌우 이동
        float y = Input.GetAxisRaw("Vertical");         //위아래 이동

        rigid2D.velocity = new Vector3(x, y, 0) * Speed * Time.deltaTime;
    }
}
