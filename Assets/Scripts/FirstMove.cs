using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FirstMove : MonoBehaviour
{
    [SerializeField]
    GameObject particlePrefab = default;
    [SerializeField]
    GameObject particleSea = default;
    [SerializeField]
    GameObject particleDash = default;
    [SerializeField]
    GameObject particleCollider = default;
    [SerializeField]
    GameObject particleBlaki1 = default;

    //private new Transform camera;

    public GameObject gameObject01; //スケールを変更するゲームオブジェクト

    public float speed;
    public Rigidbody rb;

    public Material colorRed;
    public Material colorBlue;
    public Material colorGreen;
    public Material colorDef;

    public enum StateTransration
    {

    }

    public bool greenObject;
    public bool redObject;
    public bool speedCount;
    public bool speedCount2;
    public bool dopponSwitch;

    //static int eulerAngle;

    [SerializeField]
    TextMeshProUGUI itemText = default;
    [SerializeField]
    TextMeshProUGUI speedText = default;

    private int itemState;

    const float MaxSpeed = 40f;
    const float StopMaxSpeed = 15f;
    const float StopSpeed = 10f;
    const float SpeedMinus = 0.1f;
    const float SpeedPlus = 0.02f;

    const float LeftWall = -4.9f;
    const float RightWall = 4.9f;
    const float TopWall = 0.55f;
    const float BottomWall = -6;
    const float BottomSound = -3;

    const float StartLine = -4805f;
    const float BackLine = -4800f;
    const float MiddleSpeed = 20f;
    //const int FirstEulerAngle = -90;
    //[System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0052:読み取られていないプライベート メンバーを削除", Justification = "<保留中>")]
    //private float velocityDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //camera = Camera.main.transform;
        //eulerAngle = FirstEulerAngle;
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = StopSpeed;
        greenObject = false;
        redObject = false;
        speedCount = false;
        dopponSwitch = false;
        itemState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 move = rb.velocity;
        //moveに、speedとTime.deltaTimeをかけるやり方に変更(そうしたときに、速度がなぜか一定しない)
        Vector3 move = rb.velocity;
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = 0;//こっちにmove.yを記入する
        move.z = Input.GetAxisRaw("Vertical");
        //rb.velocity = move.normalized * speed;
        //rb.AddForce(move.x * speed * Time.deltaTime*60, 0, move.z * speed * Time.deltaTime*60);
        rb.AddForce(move * speed * Time.deltaTime * 60, ForceMode.Force);

        var pos = gameObject01.transform.position;

        //速度表記のためのプログラム
        //velocityDistance = rb.velocity.magnitude;

        //デバッグ１
        if (Input.GetKey(KeyCode.U))
        {
            gameObject01.transform.position = new Vector3(transform.position.x, 0,transform.position.z);
        }
        //デバッグ２
        if (Input.GetKey(KeyCode.O))
        {
            gameObject01.transform.position = new Vector3(transform.position.x, 0, -2000);
            //TinyAudio.PlayBGM(TinyAudio.Bgm.def);(常に最初から再生)
            //複数のBGMを流すときは、AudioSourceを配列にする必要がある
            //もしくは、新しい列挙子などを作成して、別のAudioSourceを作成するなど
            //連続再生をしたくないSEなどには有効
        }

        /*if (Input.GetKey(KeyCode.V))
        {
            eulerAngle++;
            if (camera != null)
            {
                camera.position = new Vector3(gameObject01.transform.position.x,
                    gameObject01.transform.position.y + 2.5f, gameObject01.transform.position.z -3f);
                camera.transform.localEulerAngles = new Vector3(0, eulerAngle, 0);
            }
        }
        else
        {
            if (camera != null)
            {
                camera.position = new Vector3(gameObject01.transform.position.x,
                    gameObject01.transform.position.y + 1.2f, gameObject01.transform.position.z - 5f);
                camera.transform.localEulerAngles = new Vector3(0, 0, 0);
                eulerAngle = FirstEulerAngle;
            }
        }*/

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //必要な位置に移動
            var pos2 = new Vector3(pos.x, pos.y, pos.z - 1);

            if (greenObject == false)
            {
                speed = StopMaxSpeed;
            }
            TinyAudio.PlaySe(TinyAudio.Se.braki1);//複数回再生で音を大きくできる
            rb.velocity = Vector3.zero;
            //gameObject.transform.Rotate(new Vector3(180, 0, 0));
            Instantiate(particleBlaki1, pos2, Quaternion.identity);
        }
        if (gameObject01.transform.position.x > RightWall)//4.9
        {
            var v = rb.velocity;
            v.x = -Mathf.Abs(v.x);
            rb.velocity = v;
        }
        if (gameObject01.transform.position.x < LeftWall)//4.9
        {
            var v = rb.velocity;
            v.x = Mathf.Abs(v.x);
            rb.velocity = v;
        }
        if (gameObject01.transform.position.y > TopWall)
        {
            if(GameManager.time >0)
            {
                var v = rb.velocity;
                v.y = -Mathf.Abs(v.y) * v.z;
                rb.velocity = v;
            }
        }
        if(gameObject01.transform.position.z < StartLine)
        {
            //gameObject01.transform.position = new Vector3(gameObject01.transform.position.x, 0, gameObject01.transform.position.z + 5);
            //_gameObject.transform.position = new Vector3(0, 0, -4805);
            var v = rb.velocity;
            rb.velocity = Vector3.zero;
            v.z = Mathf.Abs(v.z);
            rb.velocity = v;
        }
        if(gameObject01.transform.position.y < BottomSound)
        {
            Instantiate(particleSea,pos, Quaternion.identity);
            if(dopponSwitch == false)
            {
                TinyAudio.PlaySe(TinyAudio.Se.doppon);
                dopponSwitch = true;
            }
        }
        else
        {
            dopponSwitch = false;
        }

        if(gameObject01.transform.position.y < BottomWall)
        {
            rb.velocity = Vector3.zero;
            if(greenObject == false)
            {
                speed = StopSpeed;
            }
            if (gameObject01.transform.position.z > BackLine)
            {
                gameObject01.transform.position = new Vector3(0, 0,
                gameObject01.transform.position.z - 5);
            }
            else
            {
                gameObject01.transform.position = new Vector3(0, 0, gameObject01.transform.position.z+25);
            }
        }
        UpdateSpeedText();

        if (Input.GetKey(KeyCode.C))
        {
            if (greenObject == true) return;
            speed += SpeedPlus * Time.deltaTime * 60;//一応ちょうど10f//デルタタイム未設定
            if (speed > MaxSpeed + 1)
            {
                speed = MaxSpeed;
                if (speedCount == false)
                {
                    TinyAudio.PlaySe(TinyAudio.Se.Fanhigh);
                    speedCount = true;
                }
            }
            if(speed > MiddleSpeed && speed < MiddleSpeed + 10f)
            {
                if(speedCount2 == false)
                {
                    TinyAudio.PlaySe(TinyAudio.Se.Fanmiddle);
                    speedCount2 = true;
                }
            }
        }
        else
        {
            if (greenObject == true) return;
            speed -= SpeedMinus;
            speedCount = false;
            speedCount2 = false;
            if (speed < StopSpeed)
            {
                speed = StopSpeed;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            //必要なところに移動
            var pos1 = new Vector3(pos.x, pos.y, pos.z + 5);

            TinyAudio.PlaySe(TinyAudio.Se.Charge);
            Instantiate(particleDash, pos1, Quaternion.identity);
        }


    }
    /*void LateUpdate()
    {
        var pos3 = new Vector3(_gameObject.transform.position.x,
                    _gameObject.transform.position.y + 1.2f, _gameObject.transform.position.z - 5f);
        //camera.position = new Vector3(_gameObject.transform.position.x,
        //_gameObject.transform.position.y + 1.2f, _gameObject.transform.position.z - 5f);
        //camera.transform.position = Vector3.Lerp(camera.transform.position, _gameObject.transform.position + pos3, 0.01f * Time.deltaTime);
    }*/
        void UpdateSpeedText()
    {
        if (speedText != null)
            speedText.text = $"speed{speed:00.0}";
        //球体自体のスピードを表示するには、中括弧の中身にvelocityDistance
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            if (speed > 20f && redObject == false)//書き方がトリガーの時と少し異なる
            {
                //Instantiate(particlePrefab, collision.contacts[0].point, Quaternion.identity);
                TinyAudio.StopBGM();
                TinyAudio.PlaySe(TinyAudio.Se.bomb2);

                Instantiate(particlePrefab, collision.contacts[0].point, Quaternion.identity);
                Destroy(gameObject);

                if (GameManager.gameOverCount) return;

                GameManager.ToGameover();
            }
            else
            {
                TinyAudio.PlaySe(TinyAudio.Se.collider);
                Instantiate(particleCollider, collision.contacts[0].point, Quaternion.identity);
                speed = 10;
            }
        }

        if (collision.collider.CompareTag("Item"))
        {
            if(collision.gameObject.name == "Destroyer")
            {
                itemState = 1;
            }
            if(collision.gameObject.name == "Splash")
            {
                itemState = 2;
            }
            if(collision.gameObject.name == "FastLight")
            {
                itemState = 3;
            }

            switch (itemState)
            {
                case 0:
                    GetComponent<Renderer>().material.color = colorDef.color;
                    gameObject01.transform.localScale = Vector3.one * 1f;
                    break;

                case 1:
                    GetComponent<Renderer>().material.color = colorRed.color;
                    gameObject01.transform.localScale = Vector3.one * 1.3f;
                    redObject = true;
                    greenObject = false;
                    if (itemText != null)
                        itemText.text = $"Invisible";
                    break;

                case 2:
                    GetComponent<Renderer>().material.color = colorBlue.color;
                    gameObject01.transform.localScale = Vector3.one / 2;
                    redObject = false;
                    greenObject = false;
                    if (itemText != null)
                        itemText.text = $"Minimum";
                    break;
                case 3:
                    GetComponent<Renderer>().material.color = colorGreen.color;
                    gameObject01.transform.localScale = Vector3.one;
                    speed = 50f;
                    redObject = false;
                    greenObject = true;
                    if (itemText != null)
                        itemText.text = $"Fastest";
                    break;
            }   

        }
      
    }
    /*static IEnumerator SpeedEnabled()
    {
        yield return new WaitForSeconds(5f);
        TinyAudio.PlaySe(TinyAudio.Se.Fanlow);
    }*/
    
}
