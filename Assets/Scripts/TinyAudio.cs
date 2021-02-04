using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyAudio : MonoBehaviour
{
    //このスクリプトは、他でも使用できる関数を作成しているだけ（効力はない）

    public static TinyAudio instance;//publicをつけると、外部アクセス可能
                                     //staticをつけると、クラス変数になる//staticは一つだけ持てる

    public enum Bgm//BGMとSEは、それぞれ別のTinyAudioで作成した方がいい
    {
        Undef,
        def//連続再生したいSEの作成

        //Click,Hit,Get
    }
    [Tooltip("BGM音源"), SerializeField]
    AudioClip[] bgmList = null;

    public enum Se
    {
        Burst,
        Stadiumcheer1,
        Charge,
        Fanlow,//消したところを、別のに置き換える
        Fanmiddle,
        Fanhigh,
        dondonpafupafu,
        cracker1,
        clappinghands2,
        clappinghands1,
        braki1,
        bomb2,
        bigbomb,
        clack,
        doppon,
        collider
        //Clear,GameOver
    }
    [Tooltip("効果音データ"), SerializeField]
    AudioClip[] seList = null;
    AudioSource audioSource;

    public static bool paused1;

    // Start is called before the first frame update
    private void Awake()//StartとUpdateを　privateという（非公開）//Awake(Start前に行う初期化)→Start(ゲームで行う初期化)→Update
    {
        instance = this;//thisは、そのクラスのインスタンスのこと、
        //つまり、このスクリプトが付いているゲームオブジェクトのクラスのインスタンスのこと
        audioSource = GetComponent<AudioSource>();//そのプレハブのAudioSourceを受け取る
    }

    public static void PlaySe(Se se)
    {
        instance.audioSource.PlayOneShot(
            instance.seList[(int)se] ,0.5f);//第二引数で、音量の調整（０～1）
        //一回だけ音を流す・・・PlayOneShot（〇〇List[(int)◎◎]);
    }

    public static void StopBGM()
    {
        instance.audioSource.Stop();//BGMを止める
    }

    public static void PlayBGM(Bgm bgm)
    {
        //StopBGM();//BGMとSEは基本的に分けておく
        instance.audioSource.clip = instance.bgmList[(int)bgm];
        //リストのbgmを、audioSourceに持ってくる
        instance.audioSource.Play();//BGMを流す
    }
    public static void PauseBGM()
    {
        instance.audioSource.Pause();
        //paused1 = true;

    }
    public static void UnPauseBGM()
    {
        instance.audioSource.UnPause();
        //paused1 = false;
    }
}
