using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public SpriteRenderer[] tiles;          //빌딩 배열
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
                if (-19 >= tiles[i].transform.position.x)           //타일이 일정 거리 이상 왼쪽으로 갔을 때
                {
                    for (int j = 0; j < tiles.Length; j++)          //가장 오른쪽 타일 탐색
                    {
                        if (temp.transform.position.x < tiles[j].transform.position.x)
                            temp = tiles[j];
                    }
                    tiles[i].transform.position = new Vector2(temp.transform.position.x + 19f, -2f);        //가장 왼쪽 타일을 가장 오른쪽 + 18(대략 그림 길이)만큼 더해줌 (-2는 y값)
                }
            }
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);      //타일 왼쪽으로
            }
        }

    }
}
