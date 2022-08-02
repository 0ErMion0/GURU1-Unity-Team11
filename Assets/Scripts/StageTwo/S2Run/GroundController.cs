using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundController : MonoBehaviour
{
    public SpriteRenderer[] tiles;          //빌딩 배열
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
                if (-13 >= tiles[i].transform.position.x)           //타일이 일정 거리 이상 왼쪽으로 갔을 때
                {
                    for (int j = 0; j < tiles.Length; j++)          //가장 오른쪽 타일 탐색
                    {
                        if (temp.transform.position.x < tiles[j].transform.position.x)
                            temp = tiles[j];
                    }
                    tiles[i].transform.position = new Vector2(temp.transform.position.x + 7.6f, -1.2f);        //가장 왼쪽 타일을 가장 오른쪽 + 6(대략 그림 길이)만큼 더해줌 (-1.2는 y값)

                    if (count > 33)
                    {
                        if (count == 36)
                        {
                            tiles[i].sprite = groundImg[groundImg.Length - 1];          //일정 시간 후 부서진 신호등 나옴
                        }
                        else
                        {
                            tiles[i].sprite = groundImg[0];                         //신호등 전후로 신호등 중복 X 위해 그냥 땅 생성
                        }
                    }

                    else                                                            //아닐 경우 그냥 랜덤
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
                tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //타일 왼쪽으로
            }
        }
        else if(count==49)
        {
            SceneManager.LoadScene("S2M2Fix");                          //씬 이름 S2M2Fix로 바꾸기
        }
    }
}
