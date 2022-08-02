using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundControlOptionScript : MonoBehaviour
{
    [SerializeField] string BGMParameter = "BGMParameter"; // adjust which mixer group we control
    [SerializeField] string SoundEffectParameter = "SoundEffectParameter";

    public AudioMixer masterMixer;
    //AudioSource BackGroundMusic;
    //AudioSource SoundEffect;

    public Slider SliderBackGroundMusic; // 배경음악 슬라이더에 Value값 받아옴
    public Slider SliderSoundEffect;

    //public void SliderBackGroundMusicAudioControl()
    //{
    //    // 내가 하고 싶은 것: AudioMixer에서 BGM부분의 사운드 크기를 가져오고 싶음
    //    // 그래서 그 크기를 슬라이더 value에 넣어
    //    // 나중에 옵션 씬에 들어왔을때도 슬라이더 value가 BGM 사운드 크기 쪽에 있었으면 좋겠음.

    //    //AudioMixer.FindObjectOfType <AudioMixer> ().;
    //    float sound = SliderBackGroundMusic.value; // 껐다켰을 때도 Slider 값 유지 위해 float형 변수 추가함

    //    if (sound == -40f) masterMixer.SetFloat("BGMParameter", -80); // 소리 안 들리게한거임
    //    else masterMixer.SetFloat("BGMParameter", sound);

    //    SliderBackGroundMusic.value = PlayerPrefs.GetFloat(BackGroundMusicParameter, SliderBackGroundMusic.value);

    //    //sound = masterMixer.FindSnapshot("BGMParameter");

    //    //SliderBackGroundMusic.value = masterMixer.GetFloat("BGMParameter",out var value); 
    //}

    public void SliderBackGroundMusicAudioControl(float value)
    {
        float sound = SliderBackGroundMusic.value; // 껐다켰을 때도 Slider 값 유지 위해 float형 변수 추가함
        if (sound == -40f) masterMixer.SetFloat("BGMParameter", -80); // 소리 안 들리게한거임
        else masterMixer.SetFloat("BGMParameter", sound);
    }

    public void SliderSoundEffectControl(float value)
    {
        float sound = SliderSoundEffect.value; // 껐다켰을 때도 Slider 값 유지 위해 float형 변수 추가함
        if (sound == -40f) masterMixer.SetFloat("SoundEffectParameter", -80); // 소리 안 들리게한거임
        else masterMixer.SetFloat("SoundEffectParameter", sound);
    }

    private void Awake()
    { 
        SliderBackGroundMusic.onValueChanged.AddListener(SliderBackGroundMusicAudioControl);
        SliderSoundEffect.onValueChanged.AddListener(SliderSoundEffectControl);
    }

    private void OnDisable() // save of setting 위해 PlayerPrefs 사용
    {
        PlayerPrefs.SetFloat(BGMParameter, SliderBackGroundMusic.value);
        PlayerPrefs.SetFloat(SoundEffectParameter, SliderSoundEffect.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        SliderBackGroundMusic.value = PlayerPrefs.GetFloat(BGMParameter, SliderBackGroundMusic.value);
        SliderSoundEffect.value = PlayerPrefs.GetFloat(SoundEffectParameter, SliderSoundEffect.value);

    }
}
