using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // scene ���� ��Ű�� �ҷ����� �ڵ�

// �̰� �̷��� �ѹ��� �ϸ� ���� ���°� run�� �ƴҶ����� ��� ����� ���� ��

public class GameFlow : MonoBehaviour
{
    //public int nextSceneLoad;

    //GameObject S1M2BackGroundMusic;
    //AudioSource backMusic;

    AudioSource audioSource_pickup;

    // ī�޶� �̵� ���� ����
    //public GameObject MainCamera;
    Camera MainCamera;

    // ��ư ���� ����
    public Button BookShelfButton, DeskButton, BedButton; // ó����� ��ư
    //public Button DrawerButton; // Part2-1�� ���ϰ� ���ִ� ��ư

    public Button FindBookButton; // (������)�������� ��ư
    public Button FindComputerButton, FindPencilCaseButton; // (������) ��ǻ��, ���� ��ư
    public Button FindBatteryButton, FindIDCardButton, FindWalletButton; // (������) ���͸�, IDī��, ����


    // �ڷ� ���� ��ư
    public Button BookShelfGoBackButton; // Part1 å�忡�� ��������
    public Button DeskGoBackButton; // Part2 å�󿡼� ��������
    public Button BedGoBackButton; // Part3 ħ�뿡�� ��������


    // ����/������ ������Ʈ ���� - �̹���
    //public GameObject PopBookShelf; // å�� ���


    // ����/������ ������Ʈ ���� - ��ư
    //public GameObject BackGroundImage; // ���׶���
    public GameObject BackGroundImageFalse; // å��, å��, ħ�� ���� ��ư��

    public GameObject BookShelfButtonControl; // å�弦 ��ư��(������, �ڷΰ���)
    public GameObject FindBookButtonControl; // (������) �������� ��ư ����

    public GameObject DeskButtonControl; // å�� ��ư��(������, �ڷΰ���)
    public GameObject FindComputerButtonControl; // (������) ��ǻ�� ��ư ����
    public GameObject FindPencilCaseButtonControl; // (������) ���� ��ư ����
    //public GameObject DeskGoBackButtonControl; // �ڷΰ���

    //public GameObject DrowerButtonControl; // �������� �̵� ��ư

    public GameObject BedButtonControl; // ħ�뼦 ��ư��(������, �ڷΰ���)
    public GameObject FindBatteryButtonControl;
    public GameObject FindIDCardButtonControl;
    public GameObject FindWalletButtonControl;

    // �����۵�(��ܿ� ǥ�ÿ�)
    public GameObject book;
    public GameObject computer;
    public GameObject pencilcase;
    public GameObject wallet;
    public GameObject idcard;
    public GameObject battery;


    // ��Ÿ
    private bool state;
    public int count = 0; // ������ ���� ���ٰ���

    // Start is called before the first frame update
    void Start()
    {
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        
        
        // ���� - ī�޶�
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); // ���� ī�޶�

        // ���� - �̹���
        //PopBookShelf = GameObject.Find("PopBookShelf"); // å�� ��

        // ���� - ��ư
        //BackGroundImage = GameObject.Find("BackGroundImage"); // ó�����(���� �ʿ����)
        BackGroundImageFalse = GameObject.Find("BackGroundImageFalse"); // ó����� ��ư��

        BookShelfButtonControl = GameObject.Find("BookShelfButtonControl"); // å�弦 ��ư��
        FindBookButtonControl = GameObject.Find("FindBookButtonControl"); // (������)�������� ��ư

        DeskButtonControl = GameObject.Find("DeskButtonControl"); // å�� ��ư��(������, �ڷΰ���)
        FindComputerButtonControl = GameObject.Find("FindComputerButtonControl"); // (������) ��ǻ�� ��ư ����
        FindPencilCaseButtonControl = GameObject.Find("FindPencilCaseButtonControl"); // (������) ���� ��ư ����
        //DeskGoBackButtonControl = GameObject.Find("DeskGoBackButtonControl"); // �ڷΰ���
        //DrowerButtonControl = GameObject.Find("DrowerButtonControl"); // ����

        BedButtonControl = GameObject.Find("BedButtonControl"); // ħ�뼦 ��ư��(������, �ڷΰ���)
        // (������) ���͸�, IDī��, ����
        FindBatteryButtonControl = GameObject.Find("FindBatteryButtonControl");
        FindIDCardButtonControl = GameObject.Find("FindIDCardButtonControl");
        FindWalletButtonControl = GameObject.Find("FindWalletButtonControl");

        // �����۵�(��ܿ� ǥ�ÿ�)
        book = GameObject.Find("book");
        computer = GameObject.Find("computer");
        pencilcase = GameObject.Find("pencilcase");
        wallet = GameObject.Find("wallet");
        idcard = GameObject.Find("idcard");
        battery = GameObject.Find("battery");


        // (��������) 1A. ù ȭ�鿡�� å�� ��ư ��Ȱ��ȭ 
        BookShelfButtonControl.SetActive(false);
        // 1B. desk ��ư ��Ȱ��ȭ
        DeskButtonControl.SetActive(false);
        // 1C. bed ��ư ��Ȱ��ȭ
        BedButtonControl.SetActive(false);


        // ��ư ������ ������ �Լ� -  �߰��� �Լ��� �μ� ����x�� �Լ��� �Է�
        //button = GetComponent<Button>();
        BookShelfButton.onClick.AddListener(OnClickBookShelfButton); // å�� ����
        DeskButton.onClick.AddListener(OnClickDeskButton); // å�� ����
        BedButton.onClick.AddListener(OnClickBedButton); // ħ�� ����

        //DrawerButton.onClick.AddListener(OnClickDrowerButton);// ���� ����

        FindBookButton.onClick.AddListener(OnClickFindBookButton); // (������)�������� ����

        FindComputerButton.onClick.AddListener(OnClickFindComputerButton); // (������) ��ǻ�� ����
        FindPencilCaseButton.onClick.AddListener(OnClickFindPencilCaseButton); // (������) ���� ����

        FindBatteryButton.onClick.AddListener(OnClickFindBatteryButton);
        FindIDCardButton.onClick.AddListener(OnClickFindIDCardButton);
        FindWalletButton.onClick.AddListener(OnClickFindWalletButton);

        // �ڷΰ��� ��ư��
        BookShelfGoBackButton.onClick.AddListener(OnClickBookShelfGoBackButton); // Part1 å�忡�� ��������
        DeskGoBackButton.onClick.AddListener(OnClickDeskGoBackButton); // Part2 å�󿡼� ��������
        BedGoBackButton.onClick.AddListener(OnClickBedGoBackButton); // Part3 ħ�뿡�� ��������


        // ����
        audioSource_pickup = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���°� ������ �ߡ� ������ ���� ������ �� �ְ� �Ѵ�.
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        // ������ �� ã���� �� "StageTwo"�� �̵�
        if(count == 6)
        {
            SceneManager.LoadScene("StageTwo"); // <<<�ּ� ����>>>
            //SceneManager.LoadScene("NextSceneLoad");

            //// 1. DontDestroy �� ������Ʈ ã��
            //S1M2BackGroundMusic = GameObject.Find("S1M2BackGroundMusic");

            //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
            //backMusic = S1M2BackGroundMusic.GetComponent<AudioSource>();

            //// 3. �׸��� �� ������ �����
            //backMusic.Stop();
        }
    }

    //------- ó�� ��� ��ư --------
    public void OnClickBookShelfButton() // å�� ���� ��ư
    {
        // (��������) 2A. å�� ��Ʈ���� ��Ȱ��ȭ�ߴ� �ش� ��ư�� Ȱ��ȭ 
        BookShelfButtonControl.SetActive(true);

        MainCamera.transform.position = new Vector2(0, -100); // ī�޶� �̵�

        // UI �����(å��,å��,ħ�� ��ư, �⺻ ���)
        //BackGroundImage.SetActive(false); - �����־ �ּ�ó���ؾߵ�. �ȱ׷��� ����
        BackGroundImageFalse.SetActive(false);
        //BookShelfButtonControl.SetActive(true); //å����

        // ��Ÿ����(å�� �ܵ� ��) - �ʿ����. ī�޶� ����� ǥ���ҰŶ�
        //PopBookShelf.SetActive(true);

        //Debug.Log("hey");
    }
    public void OnClickDeskButton() // å�� ���� ��ư
    {
        DeskButtonControl.SetActive(true); // ��Ȱ��ȭ�ߴ� ��ư�� Ȱ��ȭ
        MainCamera.transform.position = new Vector2(0, -200); // ī�޶� �̵�
        BackGroundImageFalse.SetActive(false);
    }

    //public void OnClickDrowerButton() // å�� ���� ���� ��ư
    //{
    //    //DrawerButtonControl.SetActive(true); // ��Ȱ��ȭ�ߴ� ��ư�� Ȱ��ȭ
    //    MainCamera.transform.position = new Vector2(100, -200); // ī�޶� �̵�
    //    FindComputerButtonControl.SetActive(false);
    //    FindPencilCaseButtonControl.SetActive(false);
    //    DeskGoBackButtonControl.SetActive(false);
        
    //    //DrowerButtonControl.SetActive(false);
    //}

    public void OnClickBedButton() // ħ�� ���� ��ư
    {
        BedButtonControl.SetActive(true); // ��Ȱ��ȭ�ߴ� ��ư�� Ȱ��ȭ
        MainCamera.transform.position = new Vector2(0, -300); // ī�޶� �̵�
        BackGroundImageFalse.SetActive(false);
    }

    // ------------------------------ ��� ��ư�� ---------------------------------------
    // å�� ��� ��ư
    public void OnClickFindBookButton() //(������) ��������
    {
        audioSource_pickup.Play();
        count += 1; // ������ ȹ��
        FindBookButtonControl.SetActive(false); //(������) �������� ����� - ȹ���߱� ����
        book.SetActive(false);
    }

    // å�� ��� ��ư
    public void OnClickFindComputerButton() // (������) ��ǻ��
    {
        audioSource_pickup.Play();
        count += 1; // ������ ȹ��
        FindComputerButtonControl.SetActive(false);
        computer.SetActive(false);
    }

    public void OnClickFindPencilCaseButton() // (������) ����
    {
        audioSource_pickup.Play();
        count += 1; // ������ ȹ��
        FindPencilCaseButtonControl.SetActive(false);
        pencilcase.SetActive(false);
    }

    // ħ�� ��� ��ư
    public void OnClickFindBatteryButton() // (������) �������͸�
    {
        audioSource_pickup.Play();
        count += 1; // ������ ȹ��
        FindBatteryButtonControl.SetActive(false);
        battery.SetActive(false);
    }

    public void OnClickFindIDCardButton() // (������) ī��
    {
        audioSource_pickup.Play();
        count += 1; // ������ ȹ��
        FindIDCardButtonControl.SetActive(false);
        idcard.SetActive(false);
    }

    public void OnClickFindWalletButton() // (������) ����
    {
        audioSource_pickup.Play();
        count += 1; // ������ ȹ��
        FindWalletButtonControl.SetActive(false);
        wallet.SetActive(false);
    }



    // ---------------------------- �ڷΰ��� ��ư�� -------------------------------
    public void OnClickBookShelfGoBackButton() // Part1 å�� �ڷΰ����ư
    {
        // ��ư(������, �ڷΰ���) ����� ó�� ������� ����

        // 3A. å�� ��ư(������, �ڷΰ���) ����� ó�� ������� ����
        BookShelfButtonControl.SetActive(false);
        // 3B. Desk ��ư ����� ó�� ������� ���� 
        //DeskButtonControl.SetActive(false);
        // 3C. Bed ��ư ����� ó�� ������� ����


        MainCamera.transform.position = new Vector2(0, 0); // ī�޶� �̵�
        BackGroundImageFalse.SetActive(true);
    }

    public void OnClickDeskGoBackButton() // Part2 å�� �ڷΰ����ư
    {
        // ��ư(������, �ڷΰ���) ����� ó�� ������� ����
        DeskButtonControl.SetActive(false);

        MainCamera.transform.position = new Vector2(0, 0); // ī�޶� �̵�
        BackGroundImageFalse.SetActive(true);
    }

    public void OnClickBedGoBackButton() // Part3 ħ�� �ڷΰ����ư
    {
        // ��ư(������, �ڷΰ���) ����� ó�� ������� ����
        BedButtonControl.SetActive(false);

        MainCamera.transform.position = new Vector2(0, 0); // ī�޶� �̵�
        BackGroundImageFalse.SetActive(true);
    }
}
