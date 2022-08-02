using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingControllerIn : MonoBehaviour
{
    public SpriteRenderer[] tiles1;         //���� �迭 St1
    public GameObject St1BG;                //�������� 1 ���
    public GameObject St1Buil;              //�������� 1 ������Ʈ(����)
    public GameObject Enemy1;               //�������� 1 ��ֹ�

    public GameObject house;            //�������� 1 > �������� 2 ��ȯ

    public SpriteRenderer[] tiles2;         //���� �迭 St2
    public GameObject St2BG;                //�������� 2 ���
    public GameObject St2Buil;              //�������� 2 ������Ʈ(����)
    public GameObject Enemy2;               //�������� 1 ��ֹ�

    public GameObject building;             //�������� 2 > �������� 2 ��ȯ (������ �ش޶�� �ϱ�)

    public SpriteRenderer[] tiles3;         //���� �迭 St3
    public GameObject St3Buil;              //�������� 3 ������Ʈ(����)
    public GameObject Enemy3;

    public float speed = 3f;
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

    SpriteRenderer temp1;               //�������� 1 ���
    SpriteRenderer temp2;               //�������� 2 ���
    SpriteRenderer temp3;               //�������� 3 ���

    public IEnumerator AddCount()
    {
        while (true)
        {
            if(playC)
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
                        tiles1[i].transform.position = new Vector2(temp1.transform.position.x + 33f, -0.23f);        //���� ���� Ÿ���� ���� ������ +33(�뷫 �׸� ����)��ŭ ������ (-2�� y��)
                    }
                }

                for (int i = 0; i < tiles1.Length; i++)
                {
                    tiles1[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //Ÿ�� ��������
                }
            }


            if (count > 45 && count <= 140)   //�������� 2
            {
                house.SetActive(true);          //�������� 1>2 ��ȯ �� Ȱ��ȭ
                St2Buil.SetActive(true);        //�������� 2 �ǹ� Ȱ��ȭ

                house.transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);     //�������� ��ȯ �� �������� �̵�

                if (count == 58)
                {
                    St1BG.SetActive(false);             //�������� 1 ��� ��Ȱ��ȭ
                    St1Buil.SetActive(false);           //�������� 1 ������Ʈ ��Ȱ��ȭ
                    Enemy1.SetActive(false);            //�������� 1 ��ֹ� ��Ȱ��ȭ

                    St2BG.SetActive(true);              //�������� 2 ��� Ȱ��ȭ
                }

                if (count == 72)
                    Enemy2.SetActive(true);             //�������� 2 ��ֹ� Ȱ��ȭ

                if (-20 >= house.transform.position.x)            //�������� ��ȯ ���� -20���� �����϶� ��Ȱ��ȭ
                    house.SetActive(false);

                for (int i = 0; i < tiles2.Length; i++)                 //�������� 2 Ÿ��
                {
                    if (-18 >= tiles2[i].transform.position.x)           //Ÿ���� ���� �Ÿ� �̻� �������� ���� ��
                    {
                        for (int j = 0; j < tiles2.Length; j++)          //���� ������ Ÿ�� Ž��
                        {
                            if (temp2.transform.position.x < tiles2[j].transform.position.x)
                                temp2 = tiles2[j];
                        }
                        tiles2[i].transform.position = new Vector2(temp2.transform.position.x + 19f, -2f);        //���� ���� Ÿ���� ���� ����������
                    }
                }

                for (int i = 0; i < tiles2.Length; i++)
                {
                    tiles2[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //Ÿ�� �������� ������
                }
            }


            if (count > 125)            //3��������
            {
                building.SetActive(true);       //�������� 2>3 ��ȯ �� Ȱ��ȭ
                St3Buil.SetActive(true);        //�������� 3 �ǹ� Ȱ��ȭ

                building.transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);     //�������� ��ȯ �� �������� �̵�

                if (count == 140)
                {
                    St2Buil.SetActive(false);           //�������� 2 ������Ʈ ��Ȱ��ȭ
                    Enemy2.SetActive(false);            //�������� 2 ��ֹ� ��Ȱ��ȭ
                }

                if (count == 150)
                    Enemy3.SetActive(true);             //�������� 3 ��ֹ� Ȱ��ȭ

                if (-20 >= building.transform.position.x)            //�������� ��ȯ ���� -20���� �����϶� ��Ȱ��ȭ
                    building.SetActive(false);

                for (int i = 0; i < tiles3.Length; i++)                 //�������� 3 Ÿ��
                {
                    if (-29 >= tiles3[i].transform.position.x)           //Ÿ���� ���� �Ÿ� �̻� �������� ���� ��
                    {
                        for (int j = 0; j < tiles3.Length; j++)          //���� ������ Ÿ�� Ž��
                        {
                            if (temp3.transform.position.x < tiles3[j].transform.position.x)
                                temp3 = tiles3[j];
                        }
                        tiles3[i].transform.position = new Vector2(temp3.transform.position.x + 30f, -0.3f);        //���� ���� Ÿ���� ���� ����������
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
