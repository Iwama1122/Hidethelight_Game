using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;//移動速度
    //CharacterControllerのキャッシュ
    private CharacterController _characterController;
    private Transform _transform;//transformのキャッシュ
    private Vector3 _moveVelocity;//キャラクターの移動速度情報
    int oka = 0;
    public Text okate;
    [SerializeField] private GameObject ma;
    GameManager ga;

    //public Camera playerCamera = null;
    public GameObject avatar = null;
    private float speed = 10;
    //ここにランダムで落ちてくるアイテムと
    //ハートの女王のセリフのゲームオブジェクトをランダム
    //に表示させる変数も用意する(GameManagerにつけるかも)
    // Start is called before the first frame update
    void Start()
    {

        _characterController = GetComponent<CharacterController>();
        _transform = transform;
        ma = GameObject.Find("GameManager");
        ga = ma.GetComponent<GameManager>();
    }

    //カメラ上下移動の最大、最小角度です。Inspectorウィンドウから設定してください
    [Range(-0.999f, -0.5f)]
    public float maxYAngle = -0.5f;
    [Range(0.5f, 0.999f)]
    public float minYAngle = 0.5f;
    // Update is called once per frame
    void Update()
    {


        okate.text = "×" + oka ;
        if(ga.START== true) {
        //マウスのX,Y軸がどれほど移動したかを取得します
        float X_Rotation = Input.GetAxis("Mouse X");

            //Y軸を更新します（キャラクターを回転）取得したX軸の変更をキャラクターのY軸に反映します
            this.transform.Rotate(0, X_Rotation, 0);
            //入力による移動処理(慣性を無視しているので、きびきび動く)
            _moveVelocity.z = CrossPlatformInputManager.GetAxis("Vertical");
        _moveVelocity.x = CrossPlatformInputManager.GetAxis("Horizontal");


            //if(_characterController.isGrounded) {
            //  if(Input.GetKeyDown(KeyCode.Space)) {
            //ジャンプ処理
            //    Debug.Log("ジャンプ");
            //_moveVelocity.y = jumpPower;//ジャンプの際は上方向に移動させる
            //}
            //} else {
     if (avatar != null)
       {
            if (Input.GetKeyDown(KeyCode.D)) {
            //transform.position += transform.right * speed * Time.deltaTime;
            //moveSpeed = 2;
            _moveVelocity.x *= moveSpeed;
           
            //transform.Translate(0,0,speed);

        }
        if(Input.GetKeyDown(KeyCode.A)) {
            //moveSpeed = 2;
            // transform.position -= transform.right * speed * Time.deltaTime;
            _moveVelocity.x *= moveSpeed;
          
        }
        if(Input.GetKeyDown(KeyCode.W)) {
            //moveSpeed = 2;
            //transform.position += transform.forward * speed * Time.deltaTime;

            _moveVelocity.z *= moveSpeed;
            
        }
        if(Input.GetKeyDown(KeyCode.S)) {
            //moveSpeed = 2;
            //transform.position -= transform.forward * speed * Time.deltaTime;

            _moveVelocity.z *=- -moveSpeed;
                   

                }
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Tab))
        {
            moveSpeed = 5.0f;
            
            _moveVelocity.z *= moveSpeed;
            // transform.position += transform.forward * speed*5.0f * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Tab)) {
            moveSpeed = 5.0f;
            _moveVelocity.z *= moveSpeed;
            //transform.position -= transform.forward * speed * 5.0f * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Tab)) {
            moveSpeed = 5.0f;
            _moveVelocity.x *=  moveSpeed;
            //transform.position -= transform.right * speed * 5.0f * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Tab)) {
            moveSpeed = 5.0f;
            _moveVelocity.x *= moveSpeed;
            //transform.position += transform.right * speed * 5.0f * Time.deltaTime;
        }
        
        //重力による加速
        _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        //}
        //オブジェクトを動かす
        _characterController.Move(_moveVelocity * Time.deltaTime);
        }
        }
    }
    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("okasi")) {
            oka++;
            other.gameObject.SetActive(false);
        }
    }
}
