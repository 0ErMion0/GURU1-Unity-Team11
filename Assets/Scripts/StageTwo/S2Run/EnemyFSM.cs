using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    float speed = 8f;
    public Vector2 StartPosition;

    int count = 0;

    void OnEnable()
    {
        transform.position = StartPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddCount());
    }

    IEnumerator AddCount()
    {
        while (true)
        {
            count++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(count==40)
        {
            speed = 0f;
        }

        transform.Translate(Vector2.left * Time.deltaTime * speed);         //왼쪽으로

        if (transform.position.x < -12)         //왼쪽으로 가면
        {
            gameObject.SetActive(false);        //비활성화
        }
    }
}
