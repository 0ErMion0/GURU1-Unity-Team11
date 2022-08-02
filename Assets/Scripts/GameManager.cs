using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    // 싱글톤 변수
    public static GameManager gm;

    private void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
    }

    // 게임 상태 상수
    public enum GameState
    {
        Ready, // 씬 화면 보여줌
        Run, // 미션 플레이
        GameOver // 엔딩
    }

    // 현재의 게임 상태 변수
    public GameState gState;

    // 게임 상태 UI 오브젝트 변수
    public GameObject gameLabel;

    // 게임 상태 UI 텍스트 컴포넌트 변수
    //Text gameText;

    // 게임 상태 UI 이미지 컴포넌트 변수
    Image gameImage;

    // Start is called before the first frame update
    void Start()
    {
        // 초기 게임 상태는 준비 상태로 설정한다.
        gState = GameState.Ready;

        // 게임 상태 UI 오브젝트에서 Image 컴포넌트를 가져온다
        gameImage = gameLabel.GetComponent<Image>();

        // 게임 준비 -> 게임 중 상태로 전환
        StartCoroutine(ReadyToStart());

        //// 플레이어 오브젝트를 찾은 후 플레이어의 PlayerMove 컴포넌트 받아오기
        //player = GameObject.Find("Player").GetComponent<PlayerMove>();

        //SliderTimer = GameObject.Find("SliderOff").GetComponent<SliderOff>; // <질문?> 슬라이더 참조하고 싶은데 어떻게 하지;;
        
    }

    IEnumerator ReadyToStart()
    {
        // 3초간 대기 ---------- 씬 전환 시간 바꾼다면 바꾸기
        yield return new WaitForSeconds(3f);

        // 상태 텍스트를 비활성화한다.
        gameLabel.SetActive(false);

        // 상태를 ‘게임중’ 상태로 변경한다.
        gState = GameState.Run;
    }

    // Update is called once per frame
    void Update()
    {
        //// 게임 상태가 ‘게임 중’ 상태일 때만 조작할 수 있게 한다. ---- 다른 스크립트에 추가하기
        //if (GameManager.gm.gState != GameManager.GameState.Run)
        //{
        //    return;
        //}

        //// 만일, 플레이어의 hp가 0 이하라면...
        //if (player.hp <= 0)
        //{
        //    // 상태 텍스트를 활성화한다.
        //    gameLabel.SetActive(true);
        //    // 상태 텍스트의 내용을 ‘Game Over’로 한다.
        //    gameText.text = "Game Over";
        //    // 상태 텍스트의 색상을 붉은색으로 한다.
        //    gameText.color = new Color32(255, 0, 0, 255);
        //    // 상태를 ‘게임 오버’ 상태로 변경한다.
        //    gState = GameState.GameOver;
        //}
    }
}
