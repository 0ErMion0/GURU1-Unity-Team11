using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public SpriteRenderer[] tiles;          //���� �迭
    public float speed;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        temp = tiles[0];
        StartCoroutine(AddCount());
    }
    SpriteRenderer temp;

    public IEnumerator AddCount()
    {
        while(true)
        {
            count++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(count < 43)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (-19 >= tiles[i].transform.position.x)           //Ÿ���� ���� �Ÿ� �̻� �������� ���� ��
                {
                    for (int j = 0; j < tiles.Length; j++)          //���� ������ Ÿ�� Ž��
                    {
                        if (temp.transform.position.x < tiles[j].transform.position.x)
                            temp = tiles[j];
                    }
                    tiles[i].transform.position = new Vector2(temp.transform.position.x + 19f, -2f);        //���� ���� Ÿ���� ���� ������ + 18(�뷫 �׸� ����)��ŭ ������ (-2�� y��)
                }
            }
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //Ÿ�� ��������
            }
        }

    }
}
