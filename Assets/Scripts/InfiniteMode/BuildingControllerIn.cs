using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingControllerIn : MonoBehaviour
{
    public SpriteRenderer[] tiles1;         //빌딩 배열 St1
    public GameObject St1BG;                //스테이지 1 배경
    public GameObject St1Buil;              //스테이지 1 오브젝트(빌딩)
    public GameObject Enemy1;               //스테이지 1 장애물

    public GameObject house;            //스테이지 1 > 스테이지 2 전환

    public SpriteRenderer[] tiles2;         //빌딩 배열 St2
    public GameObject St2BG;                //스테이지 2 배경
    public GameObject St2Buil;              //스테이지 2 오브젝트(빌딩)
    public GameObject Enemy2;               //스테이지 1 장애물

    public GameObject building;             //스테이지 2 > 스테이지 2 전환 (디자인 해달라고 하기)

    public SpriteRenderer[] tiles3;         //빌딩 배열 St3
    public GameObject St3Buil;              //스테이지 3 오브젝트(빌딩)
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

    SpriteRenderer temp1;               //스테이지 1 계산
    SpriteRenderer temp2;               //스테이지 2 계산
    SpriteRenderer temp3;               //스테이지 3 계산

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
                        tiles1[i].transform.position = new Vector2(temp1.transform.position.x + 33f, -0.23f);        //가장 왼쪽 타일을 가장 오른쪽 +33(대략 그림 길이)만큼 더해줌 (-2는 y값)
                    }
                }

                for (int i = 0; i < tiles1.Length; i++)
                {
                    tiles1[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //타일 왼쪽으로
                }
            }


            if (count > 45 && count <= 140)   //스테이지 2
            {
                house.SetActive(true);          //스테이지 1>2 전환 집 활성화
                St2Buil.SetActive(true);        //스테이지 2 건물 활성화

                house.transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);     //스테이지 전환 집 왼쪽으로 이동

                if (count == 58)
                {
                    St1BG.SetActive(false);             //스테이지 1 배경 비활성화
                    St1Buil.SetActive(false);           //스테이지 1 오브젝트 비활성화
                    Enemy1.SetActive(false);            //스테이지 1 장애물 비활성화

                    St2BG.SetActive(true);              //스테이지 2 배경 활성화
                }

                if (count == 72)
                    Enemy2.SetActive(true);             //스테이지 2 장애물 활성화

                if (-20 >= house.transform.position.x)            //스테이지 전환 집이 -20보다 왼쪽일때 비활성화
                    house.SetActive(false);

                for (int i = 0; i < tiles2.Length; i++)                 //스테이지 2 타일
                {
                    if (-18 >= tiles2[i].transform.position.x)           //타일이 일정 거리 이상 왼쪽으로 갔을 때
                    {
                        for (int j = 0; j < tiles2.Length; j++)          //가장 오른쪽 타일 탐색
                        {
                            if (temp2.transform.position.x < tiles2[j].transform.position.x)
                                temp2 = tiles2[j];
                        }
                        tiles2[i].transform.position = new Vector2(temp2.transform.position.x + 19f, -2f);        //가장 왼쪽 타일을 가장 오른쪽으로
                    }
                }

                for (int i = 0; i < tiles2.Length; i++)
                {
                    tiles2[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //타일 왼쪽으로 움직임
                }
            }


            if (count > 125)            //3스테이지
            {
                building.SetActive(true);       //스테이지 2>3 전환 집 활성화
                St3Buil.SetActive(true);        //스테이지 3 건물 활성화

                building.transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);     //스테이지 전환 집 왼쪽으로 이동

                if (count == 140)
                {
                    St2Buil.SetActive(false);           //스테이지 2 오브젝트 비활성화
                    Enemy2.SetActive(false);            //스테이지 2 장애물 비활성화
                }

                if (count == 150)
                    Enemy3.SetActive(true);             //스테이지 3 장애물 활성화

                if (-20 >= building.transform.position.x)            //스테이지 전환 집이 -20보다 왼쪽일때 비활성화
                    building.SetActive(false);

                for (int i = 0; i < tiles3.Length; i++)                 //스테이지 3 타일
                {
                    if (-29 >= tiles3[i].transform.position.x)           //타일이 일정 거리 이상 왼쪽으로 갔을 때
                    {
                        for (int j = 0; j < tiles3.Length; j++)          //가장 오른쪽 타일 탐색
                        {
                            if (temp3.transform.position.x < tiles3[j].transform.position.x)
                                temp3 = tiles3[j];
                        }
                        tiles3[i].transform.position = new Vector2(temp3.transform.position.x + 30f, -0.3f);        //가장 왼쪽 타일을 가장 오른쪽으로
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
