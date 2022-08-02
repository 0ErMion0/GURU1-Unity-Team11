using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControllerIn : MonoBehaviour
{
    public SpriteRenderer[] tiles1;         //스테이지1 땅 배열
    public GameObject St1Ground;            //스테이지1 땅

    public SpriteRenderer[] tiles2;         //스테이지2 땅 배열
    public GameObject St2Ground;            //스테이지2 땅

    public SpriteRenderer[] tiles3;         //스테이지2 땅 배열
    public GameObject St3Ground;            //스테이지2 땅

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

    SpriteRenderer temp1;       //스테이지1 땅 계산
    SpriteRenderer temp2;       //스테이지2 땅 계산
    SpriteRenderer temp3;       //스테이지3 땅 계산

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

            if (count <= 60)     //스테이지 1
            {
                for (int i = 0; i < tiles1.Length; i++)                 //스테이지 1 타일
                {
                    if (-26 >= tiles1[i].transform.position.x)           //타일이 일정 거리 이상 왼쪽으로 갔을 때
                    {
                        for (int j = 0; j < tiles1.Length; j++)          //가장 오른쪽 타일 탐색
                        {
                            if (temp1.transform.position.x < tiles1[j].transform.position.x)
                                temp1 = tiles1[j];
                        }
                        tiles1[i].transform.position = new Vector2(temp1.transform.position.x + 27f, -4.03f);        //가장 왼쪽 타일을 가장 오른쪽으로
                    }
                }

                for (int i = 0; i < tiles1.Length; i++)
                {
                    tiles1[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //타일 왼쪽으로
                }
            }


            if (count > 45 && count < 135)   //스테이지 2
            {
                St2Ground.SetActive(true);          //스테이지2 땅 활성화

                if (count == 60)
                {
                    St1Ground.SetActive(false);      //스테이지1 땅 비활성화
                }
                else if (count == 70)
                {
                    speed = 8;
                }

                for (int i = 0; i < tiles2.Length; i++)
                {
                    if (-13 >= tiles2[i].transform.position.x)           //타일이 일정 거리 이상 왼쪽으로 갔을 때
                    {
                        for (int j = 0; j < tiles2.Length; j++)          //가장 오른쪽 타일 탐색
                        {
                            if (temp2.transform.position.x < tiles2[j].transform.position.x)
                                temp2 = tiles2[j];
                        }
                        tiles2[i].transform.position = new Vector2(temp2.transform.position.x + 7.6f, -1.2f);        //가장 왼쪽 타일을 가장 오른쪽으로

                        if (count > 115)                                               //일정시간 이후부터 그냥 땅만
                        {
                            tiles2[i].sprite = groundImg[0];
                        }
                        else
                        {
                            //땅 랜덤으로
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
                    tiles2[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //타일 왼쪽으로
                }

            }



            if (count == 150)                       ///3스테이지
            {
                St3Ground.SetActive(true);          //스테이지3 땅 활성화
                St2Ground.SetActive(false);         //스테이지2 땅 비활성화
            }

            if (count > 150)
            {
                for (int i = 0; i < tiles3.Length; i++)                 //스테이지 3 타일
                {
                    if (-13 >= tiles3[i].transform.position.x)           //타일이 일정 거리 이상 왼쪽으로 갔을 때
                    {
                        for (int j = 0; j < tiles3.Length; j++)          //가장 오른쪽 타일 탐색
                        {
                            if (temp3.transform.position.x < tiles3[j].transform.position.x)
                                temp3 = tiles3[j];
                        }
                        tiles3[i].transform.position = new Vector2(temp3.transform.position.x + 7.6f, -1.2f);        //가장 왼쪽 타일을 가장 오른쪽으로
                    }
                }

                for (int i = 0; i < tiles3.Length; i++)
                {
                    tiles3[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //타일 왼쪽으로 움직임
                }
            }
        }
        else
        {
            playC = false;
        }
        
    }
}
