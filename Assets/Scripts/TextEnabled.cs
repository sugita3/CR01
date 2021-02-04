using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//sceneManagerが使えるようになる
using TMPro;

public class TextEnabled : MonoBehaviour
{
    [SerializeField]
    GameObject [] startText = default;
    [SerializeField]
    GameObject [] exPlanationText = default;

    private float elapsedtime = 0f;
    private readonly float timeLimit = 3f;
    bool startnext = false;

    [Tooltip("切り替えたいシーン名"), SerializeField]
    string nextScene = "";

    [Tooltip("シーン切り替え直後に次のシーンに切り替えないようにするにはチェック")]
    public bool sceneChanged = false;

    public void SetChangeFalse()
    {
        sceneChanged = false;
    }
    private void Awake()
    {
        exPlanationText[0].SetActive(false);
        exPlanationText[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //sceneChangedがtrueだったら、Updateはすぐ終了(error用)
        if (sceneChanged) return;

        //var rank = SceneManager.GetSceneByName("Ranking");//シーン切り替えをうまくやる方法（案1）
        //if (rank.IsValid() || !GameManager.CanChangeToTitle) return;

        if (Input.GetButtonDown("Click") && startnext == false)
        {
            startnext = true;
            TinyAudio.PlaySe(TinyAudio.Se.Burst);
            TinyAudio.PlaySe(TinyAudio.Se.Burst);
        }
        if(startnext == true)
        {
            startText[0].SetActive(false);
            startText[1].SetActive(false);
            startText[2].SetActive(false);
            exPlanationText[0].SetActive(true);

            elapsedtime += Time.deltaTime; //経過時間
            if (timeLimit < elapsedtime)
            {
                exPlanationText[1].SetActive(true);
            }
        }

        if (Input.GetKey(KeyCode.X))
        {
            exPlanationText[0].SetActive(false);
            sceneChanged = true;
            //TynyAudio.PlaySe(TynyAudio.Se.Click);//TynyAudioのスクリプト内での定義を呼べる
            SceneManager.LoadScene(nextScene);//連続起動を阻止
        }
    }

}
