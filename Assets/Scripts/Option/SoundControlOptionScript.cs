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

    public Slider SliderBackGroundMusic; // ������� �����̴��� Value�� �޾ƿ�
    public Slider SliderSoundEffect;

    //public void SliderBackGroundMusicAudioControl()
    //{
    //    // ���� �ϰ� ���� ��: AudioMixer���� BGM�κ��� ���� ũ�⸦ �������� ����
    //    // �׷��� �� ũ�⸦ �����̴� value�� �־�
    //    // ���߿� �ɼ� ���� ���������� �����̴� value�� BGM ���� ũ�� �ʿ� �־����� ������.

    //    //AudioMixer.FindObjectOfType <AudioMixer> ().;
    //    float sound = SliderBackGroundMusic.value; // �������� ���� Slider �� ���� ���� float�� ���� �߰���

    //    if (sound == -40f) masterMixer.SetFloat("BGMParameter", -80); // �Ҹ� �� �鸮���Ѱ���
    //    else masterMixer.SetFloat("BGMParameter", sound);

    //    SliderBackGroundMusic.value = PlayerPrefs.GetFloat(BackGroundMusicParameter, SliderBackGroundMusic.value);

    //    //sound = masterMixer.FindSnapshot("BGMParameter");

    //    //SliderBackGroundMusic.value = masterMixer.GetFloat("BGMParameter",out var value); 
    //}

    public void SliderBackGroundMusicAudioControl(float value)
    {
        float sound = SliderBackGroundMusic.value; // �������� ���� Slider �� ���� ���� float�� ���� �߰���
        if (sound == -40f) masterMixer.SetFloat("BGMParameter", -80); // �Ҹ� �� �鸮���Ѱ���
        else masterMixer.SetFloat("BGMParameter", sound);
    }

    public void SliderSoundEffectControl(float value)
    {
        float sound = SliderSoundEffect.value; // �������� ���� Slider �� ���� ���� float�� ���� �߰���
        if (sound == -40f) masterMixer.SetFloat("SoundEffectParameter", -80); // �Ҹ� �� �鸮���Ѱ���
        else masterMixer.SetFloat("SoundEffectParameter", sound);
    }

    private void Awake()
    { 
        SliderBackGroundMusic.onValueChanged.AddListener(SliderBackGroundMusicAudioControl);
        SliderSoundEffect.onValueChanged.AddListener(SliderSoundEffectControl);
    }

    private void OnDisable() // save of setting ���� PlayerPrefs ���
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
