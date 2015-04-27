using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour
{
    private static AudioSource BGM;
    private static AudioSource[] SE;
    public AudioClip[] AudioClipArray;
    private static Dictionary<string, AudioClip> _Dic;            //音频文件集合
    public static int isSEmute = 0;
    public UIToggle A;
    public UIToggle B;

    void Awake()
    {
        //音频源集合类的加载处理
        _Dic = new Dictionary<string, AudioClip>();
        foreach (AudioClip audioClipItem in AudioClipArray)
        {
            _Dic.Add(audioClipItem.name, audioClipItem);
        }

        //得到AudioSource
        SE = this.gameObject.GetComponents<AudioSource>();

        BGM = this.GetComponents<AudioSource>()[0];


    }

    // Use this for initialization
    void Start()
    {

        int isBGMmute = PlayerPrefs.GetInt("BGMvolmune", 0);
        if (isBGMmute == 1)
        {
            BGM.mute = true;
            A.value = true;
        }
        else
        {
            BGM.mute = false;
            A.value = false;
        }


        isSEmute = PlayerPrefs.GetInt("SEvolmune", 0);
        if (isSEmute == 1)
        {
            B.value = true;
        }
        else
        {
            B.value = false;
        }

        changeSEvolmune(isSEmute);
        BGM.Play();

    }




    public static void changeBGMvolmune()
    {
        BGM.mute = !BGM.mute;
        if (BGM.mute)
        {
            PlayerPrefs.SetInt("BGMvolmune", 1);
        }
        else
        {
            PlayerPrefs.SetInt("BGMvolmune", 0);
        }
    }

    public static void changeSEvolmune(int isSEmute)
    {

        if (isSEmute == 1)
        {
            for (int i = 1; i < SE.Length; i++)
            {
                SE[i].mute = true;
            }

        }
        else
        {
            for (int i = 1; i < SE.Length; i++)
            {
                SE[i].mute = false;
            }
        }
        PlayerPrefs.SetInt("SEvolmune", isSEmute);

    }


    //播放音效
    public static void Play(AudioClip audiClip)
    {

        //播放
        if (audiClip)
        {
            for (int i = 1; i < SE.Length; i++)
            {
                if (SE[i].isPlaying == false)
                {
                    SE[i].clip = audiClip;
                    SE[i].Play();
                    break;
                }
            }
        }
        else
        {
            Debug.LogError("[AudioManager.cs/Play()] audiClip is null!! ");
        }
    }

    //播放音效
    public static void Play(string StrAudioClipName)
    {
        if (!string.IsNullOrEmpty(StrAudioClipName))
        {
            Play(_Dic[StrAudioClipName]);
        }
        else
        {
            Debug.LogError("[AudioManager.cs/Play()] StrAudioClipName is null!! ");
        }
    }





}
