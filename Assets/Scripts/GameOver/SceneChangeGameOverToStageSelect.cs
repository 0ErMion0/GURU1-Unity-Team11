using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene ���� ��Ű�� �ҷ����� �ڵ�

public class SceneChangeGameOverToStageSelect : MonoBehaviour
{
    //GameObject BackGroundMusicStageSelectControl;
    //GameObject BackGroundMusicControl;
    //AudioSource backMusic;

    public void SceneChange()
    {
        //BackGroundMusicStageSelectControl = GameObject.Find("BackGroundMusicStageSelectionControl");
        //BackGroundMusicStageSelectControl.SetActive(true);
        SceneManager.LoadScene("StoryMode"); // ��ȣ �� ��ȯ�� scene �̸� ����

        //SceneManager.GetActiveScene("StoryMode").
        //GameObject[] list = SceneManager.LoadScene(3).GetRootGameObjects(); // ���޴��� ���� ��Ʈ������Ʈ �ҷ��� Ȯ�� �� ����
        //foreach(GameObject e in list)
        //{
        //    e.BackGroundMusicStageSelectControl.SetActive(true);
        //}

        //// 1. DontDestroy �� ������Ʈ ã��
        //BackGroundMusicControl = GameObject.Find("BackGroundMusicControl");

        //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
        //backMusic = BackGroundMusicControl.GetComponent<AudioSource>();

        //// 3. �׸��� �� ������ �����
        //backMusic.Play();
    }

    //public void MusicOn()
    //{
    //    BackGroundMusicStageSelectControl = GameObject.Find("BackGroundMusicStageSelectionControl");
    //    BackGroundMusicStageSelectControl.SetActive(true);
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
