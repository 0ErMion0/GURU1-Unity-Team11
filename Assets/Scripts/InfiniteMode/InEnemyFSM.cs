using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InEnemyFSM : MonoBehaviour
{
    float speed = 8f;
    public Vector2 StartPosition;

    GameObject smObject;

    void OnEnable()
    {
        transform.position = StartPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        smObject = GameObject.Find("MenuManager");
    }

    // Update is called once per frame
    void Update()
    {
        MainMenuManager sm = smObject.GetComponent<MainMenuManager>();

        if(sm.play)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);         //��������

            if (transform.position.x < -12)         //�������� ����
            {
                gameObject.SetActive(false);        //��Ȱ��ȭ
            }
        }
        
    }
}
