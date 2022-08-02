using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    // 효과음
    //GameObject S2BackGroundMusic;
    //AudioSource backMusic;

    public AudioSource audioSource_jump;
    public AudioSource audioSource_collid;

    bool isJump = false;
    bool isTop = false;
    public float jumpHeight = 0;
    public float jumpSpeed = 0;
    public GameObject hitEffect;
    public GameObject[] heart;
    int count = 0;
    int heartN = 0;

    Vector2 startPosition;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;         //플레이어 초기 위치 저장
        animator = GetComponent<Animator>();
        StartCoroutine(AddCount());

        // 효과음
        audioSource_jump = GetComponent<AudioSource>();
        //audioSource_collid = GetComponent<AudioSource>();
    }

    public IEnumerator AddCount()
    {
        while (true)
        {
            count++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(count<43)
        {
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
                //audioSource_jump.Play();// 효과음

                if (transform.position.y <= jumpHeight - 0.1f && !isTop)        //점프 높이보다 플레이어 위치가 낮을 때 && 꼭대기(isTop)가 아닐 때
                {
                    transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime);       //점프
                    //audioSource_jump.Play();// 효과음

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
        }
        else
        {
            animator.SetBool("Idle", true);

            if (transform.position.y > startPosition.y && isTop)     //플레이어 위치가 초기 위치보다 클 때 && 꼭대기(isTop)일 때
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime);    //초기 위치로 (다시 내려감)
            }
        }

        if(heartN==3)
        {
            SceneManager.LoadScene("FailEnding3");          //씬 전환

            ////S2BackGroundMusic
            //// 1. DontDestroy 된 오브젝트 찾고
            //S2BackGroundMusic = GameObject.Find("S2BackGroundMusic");

            //// 2. 그 안에 포함된 AudioSource 변수에 넣는다
            //backMusic = S2BackGroundMusic.GetComponent<AudioSource>();

            //// 3. 그리고 그 음악을 멈춘다
            //backMusic.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Enemy_Fence(Clone)" || co.name == "Enemy_Sohwa(Clone)" || co.name == "Enemy_Kkokkal(Clone)" || co.name == "Enemy_Trash(Clone)")
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
