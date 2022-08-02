using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInMove : MonoBehaviour
{
    // 효과음
    public AudioSource audioSource_jump;
    public AudioSource audioSource_collid;

    //GameObject BackGroundMusicControl;
    //AudioSource backMusic;

    bool isJump = false;
    bool isTop = false;

    public float jumpHeight = 0;
    public float jumpSpeed = 0;

    public GameObject hitEffect;
    public GameObject[] heart;

    int heartN = 0;

    GameObject smObject;

    Vector2 startPosition;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;         //플레이어 초기 위치 저장

        animator = GetComponent<Animator>();

        smObject = GameObject.Find("MenuManager");

        // 효과음
        audioSource_jump = GetComponent<AudioSource>();
        //audioSource_collid = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MainMenuManager sm = smObject.GetComponent<MainMenuManager>();

        if (sm.play)
        {
            animator.speed = 1.0f;           //애니메이션 실행

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))             //마우스 좌클릭시
            {
                isJump = true;                          //isJump 활성화
                animator.SetTrigger("RunToJump");

                if (transform.position.y >= startPosition.y && transform.position.y <= -1.5) // 플레이어 위치 >= 초기 위치 && 플레이어 위치 <= 특정 위치 값
                {
                    audioSource_jump.Play(); // 효과음
                }
            }
            else if (transform.position.y <= startPosition.y)      //플레이어 위치가 초기 위치보다 낮거나 >같을< 때 (점프했다가 다시 땅에 닿았을 때)
            {
                isJump = false;                                 //다시 isJump와 isTop 거짓으로 만들어주고
                isTop = false;
                transform.position = startPosition;             //플레이어 위치 초기 위치로
            }

            if (isJump)                                  //isJump가 참일 때 (활성화 되었을 때 = 마우스 좌클릭)
            {
                
                if (transform.position.y <= jumpHeight - 0.1f && !isTop)        //점프 높이보다 플레이어 위치가 낮을 때 && 꼭대기(isTop)가 아닐 때
                {
                    transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime);       //점프
                }
                else
                {
                    isTop = true;
                }

                if (transform.position.y > startPosition.y && isTop)     //플레이어 위치가 초기 위치보다 클 때 && 꼭대기(isTop)일 때
                {
                    transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime);    //초기 위치로 (다시 내려감)
                }

            }

            if (heartN == 5)           //목숨 다섯 개 다 깎이면
            {
                SceneManager.LoadScene("InfiniteModeGameOver");          //씬 전환

                //// 1. DontDestroy 된 오브젝트 찾고
                //BackGroundMusicControl = GameObject.Find("BackGroundMusicControl");

                //// 2. 그 안에 포함된 AudioSource 변수에 넣는다
                //backMusic = BackGroundMusicControl.GetComponent<AudioSource>();

                //// 3. 그리고 그 음악을 멈춘다
                //backMusic.Stop();
            }
        }
        else
        {
            animator.speed = 0.0f;           //애니메이션 비활성화
        }
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Enemy_Books(Clone)" || co.name == "Enemy_Chair(Clone)" || co.name == "Enemy_Clothes(Clone)" || co.name == "Enemy_Fan(Clone)" || co.name == "Enemy_Fence(Clone)" || co.name == "Enemy_Sohwa(Clone)" || co.name == "Enemy_Kkokkal(Clone)" || co.name == "Enemy_Trash(Clone)" || co.name == "Enemy_Cat1(Clone)" || co.name == "Enemy_Cat2(Clone)" || co.name == "Enemy_Cat3(Clone)" || co.name == "Enemy_Flowerpot(Clone)")
        {
            audioSource_collid.Play(); // 효과음
            StartCoroutine(PlayHitEffect());
            heart[heartN].SetActive(false);
            heartN++;
        }
    }

    IEnumerator PlayHitEffect()
    {
        //audioSource_collid.Play(); // 효과음

        hitEffect.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        hitEffect.SetActive(false);
    }
}
