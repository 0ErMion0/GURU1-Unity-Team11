using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // scene 관련 패키지 불러오는 코드

// 이거 이렇게 한번에 하면 게임 상태가 run이 아닐때에도 계속 띄워진 상태 됨

public class GameFlow : MonoBehaviour
{
    //public int nextSceneLoad;

    //GameObject S1M2BackGroundMusic;
    //AudioSource backMusic;

    AudioSource audioSource_pickup;

    // 카메라 이동 위해 선언
    //public GameObject MainCamera;
    Camera MainCamera;

    // 버튼 변수 선언
    public Button BookShelfButton, DeskButton, BedButton; // 처음배경 버튼
    //public Button DrawerButton; // Part2-1로 향하게 해주는 버튼

    public Button FindBookButton; // (아이템)전공서적 버튼
    public Button FindComputerButton, FindPencilCaseButton; // (아이템) 컴퓨터, 필통 버튼
    public Button FindBatteryButton, FindIDCardButton, FindWalletButton; // (아이템) 배터리, ID카드, 지갑


    // 뒤로 가기 버튼
    public Button BookShelfGoBackButton; // Part1 책장에서 메인으로
    public Button DeskGoBackButton; // Part2 책상에서 메인으로
    public Button BedGoBackButton; // Part3 침대에서 메인으로


    // 숨김/보여줌 오브젝트 선언 - 이미지
    //public GameObject PopBookShelf; // 책장 배경


    // 숨김/보여줌 오브젝트 선언 - 버튼
    //public GameObject BackGroundImage; // 찐백그라운드
    public GameObject BackGroundImageFalse; // 책장, 책상, 침대 선택 버튼들

    public GameObject BookShelfButtonControl; // 책장샷 버튼들(아이템, 뒤로가기)
    public GameObject FindBookButtonControl; // (아이템) 전공서적 버튼 포함

    public GameObject DeskButtonControl; // 책상샷 버튼들(아이템, 뒤로가기)
    public GameObject FindComputerButtonControl; // (아이템) 컴퓨터 버튼 포함
    public GameObject FindPencilCaseButtonControl; // (아이템) 필통 버튼 포함
    //public GameObject DeskGoBackButtonControl; // 뒤로가기

    //public GameObject DrowerButtonControl; // 서랍으로 이동 버튼

    public GameObject BedButtonControl; // 침대샷 버튼들(아이템, 뒤로가기)
    public GameObject FindBatteryButtonControl;
    public GameObject FindIDCardButtonControl;
    public GameObject FindWalletButtonControl;

    // 아이템들(상단에 표시용)
    public GameObject book;
    public GameObject computer;
    public GameObject pencilcase;
    public GameObject wallet;
    public GameObject idcard;
    public GameObject battery;


    // 기타
    private bool state;
    public int count = 0; // 아이템 개수 세줄거임

    // Start is called before the first frame update
    void Start()
    {
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        
        
        // 참조 - 카메라
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); // 메인 카메라

        // 참조 - 이미지
        //PopBookShelf = GameObject.Find("PopBookShelf"); // 책장 샷

        // 참조 - 버튼
        //BackGroundImage = GameObject.Find("BackGroundImage"); // 처음배경(이제 필요없음)
        BackGroundImageFalse = GameObject.Find("BackGroundImageFalse"); // 처음배경 버튼들

        BookShelfButtonControl = GameObject.Find("BookShelfButtonControl"); // 책장샷 버튼들
        FindBookButtonControl = GameObject.Find("FindBookButtonControl"); // (아이템)전공서적 버튼

        DeskButtonControl = GameObject.Find("DeskButtonControl"); // 책상샷 버튼들(아이템, 뒤로가기)
        FindComputerButtonControl = GameObject.Find("FindComputerButtonControl"); // (아이템) 컴퓨터 버튼 포함
        FindPencilCaseButtonControl = GameObject.Find("FindPencilCaseButtonControl"); // (아이템) 필통 버튼 포함
        //DeskGoBackButtonControl = GameObject.Find("DeskGoBackButtonControl"); // 뒤로가기
        //DrowerButtonControl = GameObject.Find("DrowerButtonControl"); // 서랍

        BedButtonControl = GameObject.Find("BedButtonControl"); // 침대샷 버튼들(아이템, 뒤로가기)
        // (아이템) 배터리, ID카드, 지갑
        FindBatteryButtonControl = GameObject.Find("FindBatteryButtonControl");
        FindIDCardButtonControl = GameObject.Find("FindIDCardButtonControl");
        FindWalletButtonControl = GameObject.Find("FindWalletButtonControl");

        // 아이템들(상단에 표시용)
        book = GameObject.Find("book");
        computer = GameObject.Find("computer");
        pencilcase = GameObject.Find("pencilcase");
        wallet = GameObject.Find("wallet");
        idcard = GameObject.Find("idcard");
        battery = GameObject.Find("battery");


        // (어드바이저) 1A. 첫 화면에서 책자 버튼 비활성화 
        BookShelfButtonControl.SetActive(false);
        // 1B. desk 버튼 비활성화
        DeskButtonControl.SetActive(false);
        // 1C. bed 버튼 비활성화
        BedButtonControl.SetActive(false);


        // 버튼 눌리면 적용할 함수 -  추가할 함수에 인수 존재x면 함수명 입력
        //button = GetComponent<Button>();
        BookShelfButton.onClick.AddListener(OnClickBookShelfButton); // 책장 선택
        DeskButton.onClick.AddListener(OnClickDeskButton); // 책상 선택
        BedButton.onClick.AddListener(OnClickBedButton); // 침대 선택

        //DrawerButton.onClick.AddListener(OnClickDrowerButton);// 서랍 선택

        FindBookButton.onClick.AddListener(OnClickFindBookButton); // (아이템)전공서적 선택

        FindComputerButton.onClick.AddListener(OnClickFindComputerButton); // (아이템) 컴퓨터 선택
        FindPencilCaseButton.onClick.AddListener(OnClickFindPencilCaseButton); // (아이템) 필통 선택

        FindBatteryButton.onClick.AddListener(OnClickFindBatteryButton);
        FindIDCardButton.onClick.AddListener(OnClickFindIDCardButton);
        FindWalletButton.onClick.AddListener(OnClickFindWalletButton);

        // 뒤로가기 버튼들
        BookShelfGoBackButton.onClick.AddListener(OnClickBookShelfGoBackButton); // Part1 책장에서 메인으로
        DeskGoBackButton.onClick.AddListener(OnClickDeskGoBackButton); // Part2 책상에서 메인으로
        BedGoBackButton.onClick.AddListener(OnClickBedGoBackButton); // Part3 침대에서 메인으로


        // 사운드
        audioSource_pickup = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 상태가 ‘게임 중’ 상태일 때만 조작할 수 있게 한다.
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        // 아이템 다 찾으면 씬 "StageTwo"로 이동
        if(count == 6)
        {
            SceneManager.LoadScene("StageTwo"); // <<<주석 해제>>>
            //SceneManager.LoadScene("NextSceneLoad");

            //// 1. DontDestroy 된 오브젝트 찾고
            //S1M2BackGroundMusic = GameObject.Find("S1M2BackGroundMusic");

            //// 2. 그 안에 포함된 AudioSource 변수에 넣는다
            //backMusic = S1M2BackGroundMusic.GetComponent<AudioSource>();

            //// 3. 그리고 그 음악을 멈춘다
            //backMusic.Stop();
        }
    }

    //------- 처음 배경 버튼 --------
    public void OnClickBookShelfButton() // 책장 선택 버튼
    {
        // (어드바이저) 2A. 책자 파트에서 비활성화했던 해당 버튼들 활성화 
        BookShelfButtonControl.SetActive(true);

        MainCamera.transform.position = new Vector2(0, -100); // 카메라 이동

        // UI 숨기기(책장,책상,침대 버튼, 기본 배경)
        //BackGroundImage.SetActive(false); - 꺼져있어서 주석처리해야됨. 안그러면 에러
        BackGroundImageFalse.SetActive(false);
        //BookShelfButtonControl.SetActive(true); //책장쪽

        // 나타나기(책장 단독 샷) - 필요없음. 카메라 무브로 표현할거라
        //PopBookShelf.SetActive(true);

        //Debug.Log("hey");
    }
    public void OnClickDeskButton() // 책상 선택 버튼
    {
        DeskButtonControl.SetActive(true); // 비활성화했던 버튼들 활성화
        MainCamera.transform.position = new Vector2(0, -200); // 카메라 이동
        BackGroundImageFalse.SetActive(false);
    }

    //public void OnClickDrowerButton() // 책상 서랍 선택 버튼
    //{
    //    //DrawerButtonControl.SetActive(true); // 비활성화했던 버튼들 활성화
    //    MainCamera.transform.position = new Vector2(100, -200); // 카메라 이동
    //    FindComputerButtonControl.SetActive(false);
    //    FindPencilCaseButtonControl.SetActive(false);
    //    DeskGoBackButtonControl.SetActive(false);
        
    //    //DrowerButtonControl.SetActive(false);
    //}

    public void OnClickBedButton() // 침대 선택 버튼
    {
        BedButtonControl.SetActive(true); // 비활성화했던 버튼들 활성화
        MainCamera.transform.position = new Vector2(0, -300); // 카메라 이동
        BackGroundImageFalse.SetActive(false);
    }

    // ------------------------------ 배경 버튼들 ---------------------------------------
    // 책장 배경 버튼
    public void OnClickFindBookButton() //(아이템) 전공서적
    {
        audioSource_pickup.Play();
        count += 1; // 아이템 획득
        FindBookButtonControl.SetActive(false); //(아이템) 전공서적 숨기기 - 획득했기 때문
        book.SetActive(false);
    }

    // 책상 배경 버튼
    public void OnClickFindComputerButton() // (아이템) 컴퓨터
    {
        audioSource_pickup.Play();
        count += 1; // 아이템 획득
        FindComputerButtonControl.SetActive(false);
        computer.SetActive(false);
    }

    public void OnClickFindPencilCaseButton() // (아이템) 필통
    {
        audioSource_pickup.Play();
        count += 1; // 아이템 획득
        FindPencilCaseButtonControl.SetActive(false);
        pencilcase.SetActive(false);
    }

    // 침대 배경 버튼
    public void OnClickFindBatteryButton() // (아이템) 보조배터리
    {
        audioSource_pickup.Play();
        count += 1; // 아이템 획득
        FindBatteryButtonControl.SetActive(false);
        battery.SetActive(false);
    }

    public void OnClickFindIDCardButton() // (아이템) 카드
    {
        audioSource_pickup.Play();
        count += 1; // 아이템 획득
        FindIDCardButtonControl.SetActive(false);
        idcard.SetActive(false);
    }

    public void OnClickFindWalletButton() // (아이템) 지갑
    {
        audioSource_pickup.Play();
        count += 1; // 아이템 획득
        FindWalletButtonControl.SetActive(false);
        wallet.SetActive(false);
    }



    // ---------------------------- 뒤로가기 버튼들 -------------------------------
    public void OnClickBookShelfGoBackButton() // Part1 책상 뒤로가기버튼
    {
        // 버튼(아이템, 뒤로가기) 숨기고 처음 배경으로 가기

        // 3A. 책자 버튼(아이템, 뒤로가기) 숨기고 처음 배경으로 가기
        BookShelfButtonControl.SetActive(false);
        // 3B. Desk 버튼 숨기고 처음 배경으로 가기 
        //DeskButtonControl.SetActive(false);
        // 3C. Bed 버튼 숨기고 처음 배경으로 가기


        MainCamera.transform.position = new Vector2(0, 0); // 카메라 이동
        BackGroundImageFalse.SetActive(true);
    }

    public void OnClickDeskGoBackButton() // Part2 책장 뒤로가기버튼
    {
        // 버튼(아이템, 뒤로가기) 숨기고 처음 배경으로 가기
        DeskButtonControl.SetActive(false);

        MainCamera.transform.position = new Vector2(0, 0); // 카메라 이동
        BackGroundImageFalse.SetActive(true);
    }

    public void OnClickBedGoBackButton() // Part3 침대 뒤로가기버튼
    {
        // 버튼(아이템, 뒤로가기) 숨기고 처음 배경으로 가기
        BedButtonControl.SetActive(false);

        MainCamera.transform.position = new Vector2(0, 0); // 카메라 이동
        BackGroundImageFalse.SetActive(true);
    }
}
