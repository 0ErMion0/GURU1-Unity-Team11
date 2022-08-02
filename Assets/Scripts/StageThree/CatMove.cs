using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    public Transform[] waypoints;       //지나갈 포인트 배열
    int cur = 0;                        //현재 걷고 있는 웨이 포인트를 추적하는 인덱스 변수

    public float speed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else
            cur = (cur + 1) % waypoints.Length;
    }
}
