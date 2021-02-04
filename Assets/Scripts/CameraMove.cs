using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private new Transform camera;
    static int eulerAngle;
    const int FirstEulerAngle = -90;
    public GameObject gameObject01;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        eulerAngle = FirstEulerAngle;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject01 != null)
        {
            if (Input.GetKey(KeyCode.V))
            {
                eulerAngle++;
                if (camera != null)
                {
                    camera.position = new Vector3(gameObject01.transform.position.x,
                        gameObject01.transform.position.y + 2.5f, gameObject01.transform.position.z - 3f);
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
            }
        }

           
    }
}
