using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // 효과음
    //GameObject S3BackGroundMusic;
    //AudioSource backMusic;
    AudioSource audioSource;

    public float speed = 0.5f;
    Rigidbody2D rigid2D;

    public GameObject hitEffect;

    public GameObject[] heart;
    int heartN = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();

        // 효과음
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");       //좌우 이동
        float y = Input.GetAxisRaw("Vertical");         //위아래 이동

        rigid2D.velocity = new Vector3(x, y, 0) * speed;

        if (heartN == 3)                                //목숨 다 깎이면 실패 씬으로
        {
            SceneManager.LoadScene("FailEnding6");

            ////S3BackGroundMusic
            //// 1. DontDestroy 된 오브젝트 찾고
            //S3BackGroundMusic = GameObject.Find("S3BackGroundMusic");

            //// 2. 그 안에 포함된 AudioSource 변수에 넣는다
            //backMusic = S3BackGroundMusic.GetComponent<AudioSource>();

            //// 3. 그리고 그 음악을 멈춘다
            //backMusic.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D co)            //우치 || 우동 || 랑이 중 하나 만나면 깜빡
    {
        if (co.name == "Uchi" || co.name == "Udong" || co.name == "RangE")
        {
            audioSource.Play(); // 효과음
            StartCoroutine(PlayHitEffect());
            heart[heartN].SetActive(false);
            heartN++;
        }
    }

    IEnumerator PlayHitEffect()
    {
        hitEffect.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        hitEffect.SetActive(false);
    }
}
