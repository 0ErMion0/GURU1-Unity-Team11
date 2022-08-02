using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundMusicControl : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        //audioSource = GetComponent<AudioSource>();

        var BackGroundMusicControl = FindObjectsOfType<BackGroundMusicControl>();
        if (BackGroundMusicControl.Length == 1)
        {
            DontDestroyOnLoad(gameObject); // �̷��� �ϸ� �ٽ� ����ȭ�� ���ư��� �������� ���� â ���� �������� ���� â���� �뷡 �ȳ���.. �׸��� BackGroundMusicControl ���� �����Ǿ��ϴµ� ��Ʈ���� �ּ� ó���ϸ�.,. �� ����..
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying)
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
