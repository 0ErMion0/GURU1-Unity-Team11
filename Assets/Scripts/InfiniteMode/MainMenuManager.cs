using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    GameObject BackGroundMusic;
    AudioSource backMusic;

    //GameObject BackGroundMusicControl;
    //AudioSource backMusicMain;

    public bool play = true;
    public GameObject GameMenu;     //�Ͻ����� �޴�

    public Button MainMenu;
    public Button Continue;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.onClick.AddListener(OnClickMainMenu);
        Continue.onClick.AddListener(OnClickContinue);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))           //ESC�� ������ ��
        {
            if (GameMenu.activeSelf)                 //�̹� ���� �޴��� Ȱ��ȭ �Ǿ� �ִٸ�
            {
                GameMenu.SetActive(false);          //���� �޴� ��Ȱ��ȭ
                play = true;                        //�÷���=true

                BackGroundMusic = GameObject.Find("BackGroundMusic");
                backMusic = BackGroundMusic.GetComponent<AudioSource>();
                backMusic.Play();
            }
            else                                    //�ƴ϶��
            {
                GameMenu.SetActive(true);           //���� �޴� Ȱ��ȭ
                play = false;                       //�÷���=false

                BackGroundMusic = GameObject.Find("BackGroundMusic");
                backMusic = BackGroundMusic.GetComponent<AudioSource>();
                backMusic.Pause();
            }
        }
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("HomeScreen");          //���� �޴��� �� ��ȯ

        //// 1. DontDestroy �� ������Ʈ ã��
        //BackGroundMusicControl = GameObject.Find("BackGroundMusicControl");

        //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
        //backMusicMain = BackGroundMusicControl.GetComponent<AudioSource>();

        //// 3. �׸��� �� ������ �����
        //backMusicMain.Play();

        //Debug.Log("MainMenu");
    }

    public void OnClickContinue()
    {
        GameMenu.SetActive(false);          //���� �޴� ��Ȱ��ȭ
        play = true;                        //�÷���=true

        BackGroundMusic = GameObject.Find("BackGroundMusic");
        backMusic = BackGroundMusic.GetComponent<AudioSource>();
        backMusic.Pause();
        backMusic.Play();
    }
}
