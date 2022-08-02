using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControlScript : MonoBehaviour
{
    // 1
    private AudioSource audioSource;

    // 2
    //public static MusicControlScript Instance;

    private void Awake()
    {
        // 1
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();

        // 2
        //Instance = this;

        // 3
        //var BackGroundMusicControl = FindObjectsOfType<BackGroundMusicControl>();
        //if (BackGroundMusicControl.Length == 1)
        //{
        //    DontDestroyOnLoad(gameObject); // �̷��� �ϸ� �ٽ� ����ȭ�� ���ư��� �������� ���� â ���� �������� ���� â���� �뷡 �ȳ���.. �׸��� BackGroundMusicControl ���� �����Ǿ��ϴµ� ��Ʈ���� �ּ� ó���ϸ�.,. �� ����..
        //    audioSource = GetComponent<AudioSource>();
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

    }

    public void PlayMusic()
    {
        if(audioSource.isPlaying)
        {
            return;
        }
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
