using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public float Speed = 50.0f;
    int pre = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "endpoint")
        {

            int random = Random.Range(0, 4);

            Debug.Log(random);

            while (true)
            {
                random = Random.Range(0, 4);
                Debug.Log(random + "in");

                if (pre != random)
                    break;
            }

            pre = random;
            Debug.Log("pre: " + pre);

            transform.eulerAngles = new Vector3(0, 0, 90 * random);
        }
    }
}
