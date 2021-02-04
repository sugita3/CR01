using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    GameObject particleGoal = default;
    [SerializeField]
    GameObject[] recordText = default;

    [SerializeField]
    TextMeshProUGUI timeText = default;
    [SerializeField]
    TextMeshProUGUI highTimeText = default;
    [SerializeField]
    GameObject gameObject01 = default;

    public static bool gameOverCount;
    public static bool clearCount;
    public bool startCount;

    public static float time;
    static float highTime = 1000;


    private float goalLonger2;

    public static float GoalLonger
    { 
        get
        {
            return 23f;
        }
    
    }

    public static bool CanChangeToTitle { get; private set; }

    private void Awake()
    {
        //PlayerPrefs.GetFloat("HighTime", highTime);//これは現在機能していない（逆にありだった）
        //変数にセットする必要がある//今は、個人の点数のやつのみが機能している
        gameOverCount = false;
        clearCount = false;
        startCount = false;
        CanChangeToTitle = false;
        goalLonger2 = GameManager.GoalLonger;
        Instance = this;
        //ゲームマネージャーをゲットプライベートセットした時は、必ずこれも使用するべし
        //これがないと、Instance（自作の変数の方）が取得できないエラーが起こってしまう
        
    }
    private void Start()
    {
        time = 0;
        UpdateHighTimeText(highTime);
        TinyAudio.PlaySe(TinyAudio.Se.Burst);
        TinyAudio.PlaySe(TinyAudio.Se.Burst);
        if (recordText[0] !=null)
        {
            recordText[0].SetActive(false);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (gameObject01 != null)//Destroy用
        {
            var pos = gameObject01.transform.position;
            if (gameObject01.transform.position.z < -4750 || clearCount || gameOverCount) return;
            
            if(startCount == false)
            {
                StartSe();
            }
            time += Time.fixedDeltaTime;
            UpdateTimeText();

            if (time >= 999.9f)
            {
                time = 999.9f;
            }
            if (gameObject01.transform.position.z > goalLonger2)
            {
                //gameOverCount = false;
                //UnityEngine.Debug.Log("GameOver");
                //Time.timeScale = 0;
                //gameObject.transform.position = new Vector3(1000000, 0, 0);
                //playerの方でDestroyをするのもいい
                TinyAudio.StopBGM();
                Instantiate(particleGoal, pos, Quaternion.identity);
                Destroy(gameObject01);
                UpdateTimeText();
                ToClear();
            }
        }
    }
    public static void CheckSpeedText()//Staticを入れたら、オブジェクト参照が必要です、が治った
    {
        time = Mathf.RoundToInt(time * 10f) / 10f;
        if (highTime > time)
        {
            highTime = time;
            TinyAudio.PlaySe(TinyAudio.Se.dondonpafupafu);
            TinyAudio.PlaySe(TinyAudio.Se.Stadiumcheer1);
            PlayerPrefs.SetInt("HighScore", (int)highTime);
            //Setするときは、代入する必要がない
            Instance.recordText[0].SetActive(true);
        }
        else
        {
            TinyAudio.PlaySe(TinyAudio.Se.clappinghands2);
        }
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking(time);
        Instance.StartCoroutine(RankingProc());
        //CanChangeToTitle = true;
    }
    void UpdateHighTimeText(float highTime)
    {
        if (highTimeText != null)
            highTimeText.text = $"<You>\nFastest Time:{highTime:0.0}";//#は、数字が入ってないときは表示されない
    }
    void UpdateTimeText()
    {
        if (timeText != null)
            timeText.text = $"{time:0.0}";//#は、数字が入ってないときは表示されない
    }
    public static void ToClear()
    {
        if (clearCount) return;
        SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
        CheckSpeedText();
        clearCount = true;
    }
    public static void ToGameover()
    {
        if (gameOverCount) return;
        SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
        gameOverCount = true;
    }
    public void StartSe()
    {
        TinyAudio.PlaySe(TinyAudio.Se.clack);
        startCount = true;
    }


    const float RankingShowWait = 2f;
    static IEnumerator RankingProc()
    {
        CanChangeToTitle = false;//HomeButton
        yield return new WaitForSeconds(RankingShowWait);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(time);
        yield return new WaitForSeconds(RankingShowWait/4);
        CanChangeToTitle = true;
    }
}
