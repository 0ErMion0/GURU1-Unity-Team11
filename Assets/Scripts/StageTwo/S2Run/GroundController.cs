using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundController : MonoBehaviour
{
    public SpriteRenderer[] tiles;          //���� �迭
    public float speed;
    public Sprite[] groundImg;
    int pre = 0;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        temp = tiles[0];
        StartCoroutine(AddCount());
    }
    SpriteRenderer temp;

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
        if (count < 43)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (-13 >= tiles[i].transform.position.x)           //Ÿ���� ���� �Ÿ� �̻� �������� ���� ��
                {
                    for (int j = 0; j < tiles.Length; j++)          //���� ������ Ÿ�� Ž��
                    {
                        if (temp.transform.position.x < tiles[j].transform.position.x)
                            temp = tiles[j];
                    }
                    tiles[i].transform.position = new Vector2(temp.transform.position.x + 7.6f, -1.2f);        //���� ���� Ÿ���� ���� ������ + 6(�뷫 �׸� ����)��ŭ ������ (-1.2�� y��)

                    if (count > 33)
                    {
                        if (count == 36)
                        {
                            tiles[i].sprite = groundImg[groundImg.Length - 1];          //���� �ð� �� �μ��� ��ȣ�� ����
                        }
                        else
                        {
                            tiles[i].sprite = groundImg[0];                         //��ȣ�� ���ķ� ��ȣ�� �ߺ� X ���� �׳� �� ����
                        }
                    }

                    else                                                            //�ƴ� ��� �׳� ����
                    {
                        int random = Random.Range(0, groundImg.Length - 1);

                        while (random == pre)
                            random = Random.Range(0, groundImg.Length - 1);

                        tiles[i].sprite = groundImg[random];

                        pre = random;
                    }
                }
            }
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //Ÿ�� ��������
            }
        }
        else if(count==49)
        {
            SceneManager.LoadScene("S2M2Fix");                          //�� �̸� S2M2Fix�� �ٲٱ�
        }
    }
}
