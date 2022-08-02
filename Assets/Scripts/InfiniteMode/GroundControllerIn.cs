using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControllerIn : MonoBehaviour
{
    public SpriteRenderer[] tiles1;         //��������1 �� �迭
    public GameObject St1Ground;            //��������1 ��

    public SpriteRenderer[] tiles2;         //��������2 �� �迭
    public GameObject St2Ground;            //��������2 ��

    public SpriteRenderer[] tiles3;         //��������2 �� �迭
    public GameObject St3Ground;            //��������2 ��

    public Sprite[] groundImg;
    int pre = 0;

    float speed = 3;
    int count = 0;

    GameObject smObject;
    public bool playC = true;

    // Start is called before the first frame update
    void Start()
    {
        temp1 = tiles1[0];
        temp2 = tiles2[0];
        temp3 = tiles3[0];

        StartCoroutine(AddCount());

        smObject = GameObject.Find("MenuManager");
    }

    SpriteRenderer temp1;       //��������1 �� ���
    SpriteRenderer temp2;       //��������2 �� ���
    SpriteRenderer temp3;       //��������3 �� ���

    IEnumerator AddCount()
    {
        while (true)
        {
            if (playC)
                count++;

            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MainMenuManager sm = smObject.GetComponent<MainMenuManager>();

        if(sm.play)
        {
            playC = true;

            if (count <= 60)     //�������� 1
            {
                for (int i = 0; i < tiles1.Length; i++)                 //�������� 1 Ÿ��
                {
                    if (-26 >= tiles1[i].transform.position.x)           //Ÿ���� ���� �Ÿ� �̻� �������� ���� ��
                    {
                        for (int j = 0; j < tiles1.Length; j++)          //���� ������ Ÿ�� Ž��
                        {
                            if (temp1.transform.position.x < tiles1[j].transform.position.x)
                                temp1 = tiles1[j];
                        }
                        tiles1[i].transform.position = new Vector2(temp1.transform.position.x + 27f, -4.03f);        //���� ���� Ÿ���� ���� ����������
                    }
                }

                for (int i = 0; i < tiles1.Length; i++)
                {
                    tiles1[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //Ÿ�� ��������
                }
            }


            if (count > 45 && count < 135)   //�������� 2
            {
                St2Ground.SetActive(true);          //��������2 �� Ȱ��ȭ

                if (count == 60)
                {
                    St1Ground.SetActive(false);      //��������1 �� ��Ȱ��ȭ
                }
                else if (count == 70)
                {
                    speed = 8;
                }

                for (int i = 0; i < tiles2.Length; i++)
                {
                    if (-13 >= tiles2[i].transform.position.x)           //Ÿ���� ���� �Ÿ� �̻� �������� ���� ��
                    {
                        for (int j = 0; j < tiles2.Length; j++)          //���� ������ Ÿ�� Ž��
                        {
                            if (temp2.transform.position.x < tiles2[j].transform.position.x)
                                temp2 = tiles2[j];
                        }
                        tiles2[i].transform.position = new Vector2(temp2.transform.position.x + 7.6f, -1.2f);        //���� ���� Ÿ���� ���� ����������

                        if (count > 115)                                               //�����ð� ���ĺ��� �׳� ����
                        {
                            tiles2[i].sprite = groundImg[0];
                        }
                        else
                        {
                            //�� ��������
                            int random = Random.Range(0, groundImg.Length);

                            while (random == pre)
                                random = Random.Range(0, groundImg.Length);

                            tiles2[i].sprite = groundImg[random];

                            pre = random;
                        }

                    }
                }

                for (int i = 0; i < tiles2.Length; i++)
                {
                    tiles2[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //Ÿ�� ��������
                }

            }



            if (count == 150)                       ///3��������
            {
                St3Ground.SetActive(true);          //��������3 �� Ȱ��ȭ
                St2Ground.SetActive(false);         //��������2 �� ��Ȱ��ȭ
            }

            if (count > 150)
            {
                for (int i = 0; i < tiles3.Length; i++)                 //�������� 3 Ÿ��
                {
                    if (-13 >= tiles3[i].transform.position.x)           //Ÿ���� ���� �Ÿ� �̻� �������� ���� ��
                    {
                        for (int j = 0; j < tiles3.Length; j++)          //���� ������ Ÿ�� Ž��
                        {
                            if (temp3.transform.position.x < tiles3[j].transform.position.x)
                                temp3 = tiles3[j];
                        }
                        tiles3[i].transform.position = new Vector2(temp3.transform.position.x + 7.6f, -1.2f);        //���� ���� Ÿ���� ���� ����������
                    }
                }

                for (int i = 0; i < tiles3.Length; i++)
                {
                    tiles3[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //Ÿ�� �������� ������
                }
            }
        }
        else
        {
            playC = false;
        }
        
    }
}
