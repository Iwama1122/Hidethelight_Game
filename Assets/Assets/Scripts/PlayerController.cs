using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;//�ړ����x
    //CharacterController�̃L���b�V��
    private CharacterController _characterController;
    private Transform _transform;//transform�̃L���b�V��
    private Vector3 _moveVelocity;//�L�����N�^�[�̈ړ����x���
    int oka = 0;
    public Text okate;
    [SerializeField] private GameObject ma;
    GameManager ga;

    //public Camera playerCamera = null;
    public GameObject avatar = null;
    private float speed = 10;
    //�����Ƀ����_���ŗ����Ă���A�C�e����
    //�n�[�g�̏����̃Z���t�̃Q�[���I�u�W�F�N�g�������_��
    //�ɕ\��������ϐ����p�ӂ���(GameManager�ɂ��邩��)
    // Start is called before the first frame update
    void Start()
    {

        _characterController = GetComponent<CharacterController>();
        _transform = transform;
        ma = GameObject.Find("GameManager");
        ga = ma.GetComponent<GameManager>();
    }

    //�J�����㉺�ړ��̍ő�A�ŏ��p�x�ł��BInspector�E�B���h�E����ݒ肵�Ă�������
    [Range(-0.999f, -0.5f)]
    public float maxYAngle = -0.5f;
    [Range(0.5f, 0.999f)]
    public float minYAngle = 0.5f;
    // Update is called once per frame
    void Update()
    {


        okate.text = "�~" + oka ;
        if(ga.START== true) {
        //�}�E�X��X,Y�����ǂ�قǈړ����������擾���܂�
        float X_Rotation = Input.GetAxis("Mouse X");

            //Y�����X�V���܂��i�L�����N�^�[����]�j�擾����X���̕ύX���L�����N�^�[��Y���ɔ��f���܂�
            this.transform.Rotate(0, X_Rotation, 0);
            //���͂ɂ��ړ�����(�����𖳎����Ă���̂ŁA���т��ѓ���)
            _moveVelocity.z = CrossPlatformInputManager.GetAxis("Vertical");
        _moveVelocity.x = CrossPlatformInputManager.GetAxis("Horizontal");


            //if(_characterController.isGrounded) {
            //  if(Input.GetKeyDown(KeyCode.Space)) {
            //�W�����v����
            //    Debug.Log("�W�����v");
            //_moveVelocity.y = jumpPower;//�W�����v�̍ۂ͏�����Ɉړ�������
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
        
        //�d�͂ɂ�����
        _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        //}
        //�I�u�W�F�N�g�𓮂���
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
