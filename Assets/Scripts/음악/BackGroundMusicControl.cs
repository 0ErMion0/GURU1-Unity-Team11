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
            DontDestroyOnLoad(gameObject); // 이렇게 하면 다시 메인화면 돌아가고 스테이지 선택 창 가면 스테이지 선택 창에선 노래 안나와.. 그리고 BackGroundMusicControl 새로 생성되야하는데 디스트로이 주석 처리하면.,. 안 나와..
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
