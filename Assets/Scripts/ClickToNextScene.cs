using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//sceneManagerが使えるようになる

public class ClickToNextScene : MonoBehaviour
{
    [Tooltip("切り替えたいシーン名"), SerializeField]
    string nextScene = "";

    [Tooltip("シーン切り替え直後に次のシーンに切り替えないようにするにはチェック")]
    public bool sceneChanged = false;

    public void SetChangeFalse()
    {
        sceneChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        //sceneChangedがtrueだったら、Updateはすぐ終了(error用)
        if (sceneChanged) return;

        //var rank = SceneManager.GetSceneByName("Ranking");//シーン切り替えをうまくやる方法（案1）
        //if (rank.IsValid() || !GameManager.CanChangeToTitle) return;

        if (Input.GetButtonDown("Click"))
        {
            TinyAudio.PlaySe(TinyAudio.Se.Burst);
            sceneChanged = true;
            //TynyAudio.PlaySe(TynyAudio.Se.Click);//TynyAudioのスクリプト内での定義を呼べる
            SceneManager.LoadScene(nextScene);//連続起動を阻止
        }

    }
   
}
