using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene ���� ��Ű�� �ҷ����� �ڵ�

public class SceneChangeGameOverToHomeScreen : MonoBehaviour
{
    //GameObject BackGroundMusicControl;
    //AudioSource backMusic;

    //public int nextSceneLoad;

    public void SceneChange()
    {
        SceneManager.LoadScene("HomeScreen"); // ��ȣ �� ��ȯ�� scene �̸� ����

        //// 1. DontDestroy �� ������Ʈ ã��
        //BackGroundMusicControl = GameObject.Find("BackGroundMusicControl");

        //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
        //backMusic = BackGroundMusicControl.GetComponent<AudioSource>();

        //// 3. �׸��� �� ������ �����
        //backMusic.Play();

        //if (nextSceneLoad > PlayerPrefs.GetInt("ModeAt"))
        //{
        //    PlayerPrefs.SetInt("ModeAt", nextSceneLoad);
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex - 16;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
