using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
#endif

/* Note: animations are called via the controller for both the character and capsule using animator null checks
 */

namespace StarterAssets
{
    [RequireComponent(typeof(CharacterController))]
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
    [RequireComponent(typeof(PlayerInput))]
#endif
    public class ThirdPersonController : MonoBehaviour
    {
        [Header("Player")]
        [Tooltip("Move speed of the character in m/s")]
        private float MoveSpeed = 2.0f;

        [Tooltip("Sprint speed of the character in m/s")]
        private float SprintSpeed = 5.335f;

        [Tooltip("How fast the character turns to face movement direction")]
        [Range(0.0f, 0.3f)]
        public float RotationSmoothTime = 0.12f;

        [Tooltip("Acceleration and deceleration")]
        public float SpeedChangeRate = 10.0f;

        public AudioClip LandingAudioClip;
        public AudioClip[] FootstepAudioClips;
        [Range(0, 1)] public float FootstepAudioVolume = 0.5f;

        [Space(10)]
        [Tooltip("The height the player can jump")]
        public float JumpHeight = 1.2f;

        [Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
        public float Gravity = -15.0f;

        [Space(10)]
        [Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
        public float JumpTimeout = 0.50f;

        [Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
        public float FallTimeout = 0.15f;

        [Header("Player Grounded")]
        [Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
        public bool Grounded = true;

        [Tooltip("Useful for rough ground")]
        public float GroundedOffset = -0.14f;

        [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
        public float GroundedRadius = 0.28f;

        [Tooltip("What layers the character uses as ground")]
        public LayerMask GroundLayers;

        [Header("Cinemachine")]
        [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
        public GameObject CinemachineCameraTarget;

        [Tooltip("How far in degrees can you move the camera up")]
        public float TopClamp = 70.0f;

        [Tooltip("How far in degrees can you move the camera down")]
        public float BottomClamp = -30.0f;

        [Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
        public float CameraAngleOverride = 0.0f;

        [Tooltip("For locking the camera position on all axis")]
        public bool LockCameraPosition = false;

        // cinemachine
        private float _cinemachineTargetYaw;
        private float _cinemachineTargetPitch;

        // player
        private float _speed;
        private float _animationBlend;
        private float _targetRotation = 0.0f;
        private float _rotationVelocity;
        private float _verticalVelocity;
        private float _terminalVelocity = 53.0f;

        // timeout deltatime
        private float _jumpTimeoutDelta;
        private float _fallTimeoutDelta;

        // animation IDs
        private int _animIDSpeed;
        private int _animIDGrounded;
        private int _animIDJump;
        private int _animIDFreeFall;
        private int _animIDMotionSpeed;

        [SerializeField] private GameObject ma;
        GameManager ga;

        int whcount = 0;//白い薔薇の獲得変数
        int drink = 0;//ドリンクの獲得数
        int kinoko = 0;//巨大キノコの個数変数
        int childcount = 0;//子供の個数
        int catcount = 0;//チャシャ猫の個数

        int pot = 0;//ポットの個数
        int cup = 0;//コップの個数
        int spoon = 0;//スプーンの数
        bool tyuspoon = false;
        public bool SPOON
        {
            set
            {
                this.tyuspoon = value;
            }
            get
            {
                return this.tyuspoon;
            }
        }
        int syugartool = 0;//お茶会道具の合計
        bool sutaminamainasu = false;
        [SerializeField] private Text pottext;
        [SerializeField] private Text cuptext;
        [SerializeField] private Text spoontext;
        [SerializeField] private GameObject si;
        Sutamina su;
        [SerializeField] private GameObject saimin;
        bool door = false;//ドアの中にはいった時にコライダーがあってそれにplayerが触れたかどうか
        
        float targetSpeed;

        [SerializeField] private GameObject ca;
        CameraController cas;
        bool kakureteiru = false;
        bool hanareru = false;
        
        bool table = false;
        bool mash = false;
        bool kabe = false;
        bool floor = false;
        VortexImageEffect ve;


       
        // float kabetime;
       
        [SerializeField] private RawImage check1;
        [SerializeField] private RawImage check2;
        [SerializeField] private RawImage check3;
        [SerializeField]
        private GameObject pots;
        RawImage potcolor;
        [SerializeField]
        private GameObject cups;
        RawImage cupcolor;
        [SerializeField]
        private GameObject spoons;
        RawImage spooncolor;
        
        float crytime;
        [SerializeField] GameObject cryef;
        [SerializeField] private GameObject closeText;
        bool mirror = false;
        

        public bool SU {
            set {
                this.sutaminamainasu = value;
            }
            get {
                return this.sutaminamainasu;
            }
        }

        public bool DOA {
            set {
                this.door = value;
            }
            get {
                return this.door;
            }
        }

        public bool KAKURERU {
            set {
                this.kakureteiru = value;
            }
            get {
                return this.kakureteiru;
            }
        }
        public bool HANARERU {
            set {
                this.hanareru = value;
            }
            get {
                return this.hanareru;
            }
        }

        public bool TABLE {
            set {
                this.table = value;
            }
            get {
                return this.table;
            }
        }
        public bool FLOOR {
            set {
                this.floor = value;
            }
            get {
                return this.floor;
            }
        }


        public bool KABE
        {
            set
            {
                this.kabe = value;
            }
            get
            {
                return this.kabe;
            }
        }

        public bool MASH {
            set {
                this.mash = value;
            }
            get {
                return this.mash;
            }
        }
        //お助けアイテム1geter•seter
        public int SYUGAR {
            set {
                this.syugartool = value;
            }
            get {
                return this.syugartool;
            }
        }

        public int CHILDCOUNT {
            set {
                this.childcount = value;
            }
            get {
                return this.childcount;
            }
        }


        public int WH {
            set {
                this.whcount = value;
            }
            get {
                return this.whcount;
            }
        }

        public int KI {
            set {
                this.kinoko = value;
            }
            get {
                return this.kinoko;
            }
        }


        public int DRINK {
            set {
                this.drink = value;
            }
            get {
                return this.drink;
            }
        }

        public int CAT {
            set {
                this.catcount = value;
            }
            get {
                return this.catcount;
            }
        }
        public bool ITEM {
            set {
                this.item = value;
            }
            get {
                return this.item;
            }
        }
      
      //=============================
        bool gameover = false;
        public bool GAMEOVER {
            set {
                this.so = value;
            }
            get {
                return this.so;
            }
        }
        bool gameovers = false;
        public bool GAMEOVERS {
            set {
                this.gameovers = value;
            }
            get {
                return this.gameovers;
            }
        }
        bool sea = false;
        public bool SEA {
            set {
                this.sea = value;
            }
            get {
                return this.sea;
            }
        }
        bool warpdo = false;
        bool warpds = false; 
        public bool WARPDO {
            set {
                this.warpdo = value;
            }
            get {
                return this.warpdo;
            }
        }
        //bool warpds = false;
        public bool WARP {
            set {
                this.warpds = value;
            }
            get {
                return this.warpds;
            }
        }
        public float SPEEDTIME {
            set {
                this.speedtime = value;
            }
            get {
                return this.speedtime;
            }
        }
        public float CATTIME {
            set {
                this.cattime = value;
            }
            get {
                return this.cattime;
            }
        }

        [SerializeField] private GameObject closeimage;
        float warptime;
        bool so = false;
        bool cry = false;
        [SerializeField] private GameObject poticon;
        Vector3 pi;
        [SerializeField] private GameObject cupicon;
        Vector3 ci;
        [SerializeField] private GameObject spoonicon;
        Vector3 sn;
        [SerializeField] private GameObject mashicon;
        Vector3 mi;
        [SerializeField] private GameObject flowericon;
        Vector3 fi;
        [SerializeField] private GameObject drinkicon;
        Vector3 di;
        [SerializeField] private GameObject childicon;
        Vector3 cin;
        [SerializeField] private GameObject caticon;
        Vector3 cat;
        [SerializeField] private GameObject area;
        SwitchCamera sw;
        bool item = false;
        [SerializeField] private GameObject im;
        hyoujisroto hy;
        float speedtime;
        bool spup = false;
        [SerializeField] private GameObject dashefect;
        [SerializeField] private GameObject upcamera;
        [SerializeField] private GameObject goalwarp;
        bool sousa = false;
        Shorudercollider sh;
        [SerializeField] private GameObject tyumane;
        TyutorialManager tyuma;
        //[SerializeField] private GameObject stage;
        bool catpush = false;
        public bool CATPUSH {
            set {
                this.catpush = value;
            }
            get {
                return this.catpush;
            }
        }
        public bool SPUP {
            set {
                this.spup = value;
            }
            get {
                return this.spup;
            }
        }
        float cattime;
        [SerializeField] private AudioClip itemmusic;
        AudioSource itemaudio;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        private PlayerInput _playerInput;
#endif
        private Animator _animator;
        private CharacterController _controller;
        private StarterAssetsInputs _input;
        private GameObject _mainCamera;

        private const float _threshold = 0.01f;

        private bool _hasAnimator;

        private bool IsCurrentDeviceMouse
        {
            get
            {
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
                return _playerInput.currentControlScheme == "KeyboardMouse";
#else
				return false;
#endif
            }
        }

        


        private void Awake()
        {
            
           
            // get a reference to our main camera
            if (_mainCamera == null)
            {
                _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            }
        }

        private void Start()
        {
            itemaudio = GetComponent<AudioSource>();
            tyuma = tyumane.GetComponent<TyutorialManager>();
            sh = GetComponentInChildren< Shorudercollider >();
            ve = ca.GetComponent<VortexImageEffect>();
            //stage.SetActive(true);
            upcamera.SetActive(false);
            dashefect.SetActive(false);
            hy = im.GetComponent<hyoujisroto>();
            sw = area.GetComponent<SwitchCamera>();
            poticon.SetActive(false);
            pi = poticon.transform.position;
            cupicon.SetActive(false);
            ci = cupicon.transform.position;
            spoonicon.SetActive(false);
            sn = spoonicon.transform.position;
            mashicon.SetActive(false);
            mi = mashicon.transform.position;
            flowericon.SetActive(false);
            fi = flowericon.transform.position;
            drinkicon.SetActive(false);
            di = drinkicon.transform.position;
            childicon.SetActive(false);
            cin = childicon.transform.position;
            caticon.SetActive(false);
            cat = caticon.transform.position;

            closeText.SetActive(false);
            closeimage.SetActive(false);
            saimin.SetActive(false);
            cryef.SetActive(false);
            potcolor = pots.GetComponent<RawImage>();
            cupcolor = cups.GetComponent<RawImage>();
            spooncolor = spoons.GetComponent<RawImage>();
            check1 = GameObject.Find("Checkpot").GetComponent<RawImage>();
            check1.enabled = false;
            check2 = GameObject.Find("Checkcup").GetComponent<RawImage>();
            check2.enabled = false;
            check3 = GameObject.Find("Checkspoon").GetComponent<RawImage>();
            check3.enabled = false;
          
            ca = GameObject.Find("MainCamera");
            cas = ca.GetComponent<CameraController>();
            si = GameObject.Find("sutamina");
            su = si.GetComponent<Sutamina>();
            ma = GameObject.Find("GameManager");
            ga = ma.GetComponent<GameManager>();
            _cinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;
            
            _hasAnimator = TryGetComponent(out _animator);
            _controller = GetComponent<CharacterController>();
            _input = GetComponent<StarterAssetsInputs>();
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
            _playerInput = GetComponent<PlayerInput>();
#else
			Debug.LogError( "Starter Assets package is missing dependencies. Please use Tools/Starter Assets/Reinstall Dependencies to fix it");
#endif

            AssignAnimationIDs();

            // reset our timeouts on start
            _jumpTimeoutDelta = JumpTimeout;
            _fallTimeoutDelta = FallTimeout;
        }

        private void Update()
        {
          
           

            float y = transform.rotation.y;
            if(gameover == true) {
                saimin.SetActive(true);
                so = true;
                _controller.radius = 0.5f;
                _controller.height = 0.5f;

                transform.DORotate(
                new Vector3(-90, y, -60), // 終了時のRotation
                4f  );
                closeimage.SetActive(true);
                closeText.SetActive(true);
            }
       
           
            
            
            if(cry == true) {
                //cas.STOP = true;
                //_animationBlend = 0f;
                SprintSpeed = 0f;
                MoveSpeed = 0f;
                //kaitime += Time.deltaTime;
            } 
            if(cry == false && spup == false){
                 MoveSpeed = 2.0f;
                SprintSpeed = 5.335f;
                _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);
            }
        
            if(cry == true) {
                //so = true;
                cryef.SetActive(true);
                crytime += Time.deltaTime;
                
            }
            
            if(crytime >= 4.0f) {
                cryef.SetActive(false);
                cry = false;
                //so = false;
                crytime = 0;
            }
            /*デバッグ用のキー
            if(Input.GetKeyDown(KeyCode.P))
            {
                pot = 2;
                cup = 2;
                spoon = 2;
            }
          */
            if(pot == 2) {
                {
                    potcolor.color = new Color32(140, 122, 122, 255);
                    check1.enabled = true;
                }
            }
            if(cup == 2) {
                {
                    cupcolor.color = new Color32(140, 122, 122, 255);
                    check2.enabled = true;
                }
            }
            if(spoon == 2) {
                {
                    spooncolor.color = new Color32(140, 122, 122, 255);
                    check3.enabled = true;
                }
            }

            if(item == false) { 
            pottext.text = "×" + pot;
            cuptext.text = "×" + cup;
            spoontext.text = "×" + spoon;
            syugartool = pot+cup+spoon;
            }
             if(sw.MOVES == true){
                pottext.text = "×" + "2";
                cuptext.text = "×" + "2";
                spoontext.text = "×" + "2";
                pot = 0;
                cup = 0;
                spoon = 0;
                syugartool = 0;
            }
            //if(warpdo == true ) {
           //     warptime += Time.deltaTime;
           //     if(warptime >= 2.0f) {
           //         warpdo = false;

           //         warptime = 0;
          //      }
          //  }
          
            if(sw.MOVES == true) {
                item = true;
                cas.STOP = true;
                sousa = true;
            }
            if(sousa == true) {
                cas.STOP = false;
                sousa = false;
           }
            
            if(ga.START == true ) 
            {
               if(cas.STOP == false) {
                  //if(warpdo == false) { 
                        if(hy.COUNT == 3) {
                        if(Gamepad.current.buttonSouth.wasReleasedThisFrame && childcount != 0) {
                           
                               
                            spup = true;
                          
                        }
                        }
                        if(spup == true) {
                                dashefect.SetActive(true);
                                MoveSpeed = 2.0f * 3f;
                                SprintSpeed = 5.335f * 3f;
                                speedtime += Time.deltaTime;
                                if(speedtime >= 10.0f) {
                                    childcount--;
                                    MoveSpeed = 2.0f;
                                    SprintSpeed = 5.335f;
                                    dashefect.SetActive(false);
                                    spup = false;
                                    speedtime = 0;
                                }
                            
                        
                        
                         }
                    if(hy.COUNT == 4) {
                        if(Gamepad.current.buttonSouth.wasReleasedThisFrame && catcount != 0) {
                            catpush = true;
                            
                        }
                        }
                        if(catpush == true) {
                            cattime += Time.deltaTime;
                            if(cattime >= 10) {
                                catpush = false;
                                catcount--;
                                cattime = 0;
                            }
                        }
                    
                    //}
                    _hasAnimator = TryGetComponent(out _animator);

                     JumpAndGravity();
                     GroundedCheck();
                     
                     // if(warpdo == false && warpds == false) {// && cry == false) {
                         if(sw.MOVES == false) { 
                         Move();
                        }
                   //   }
                 
                }
               else {
                    dashefect.SetActive(false);
                }
             }
            if(sh.SHORUDER == true) {
                //if(kakureteiru == false || ga.TIME == 0) {
                //ここにゲームオーバーシーンに行く
                _animationBlend = 0f;
                SprintSpeed = 0f;
                MoveSpeed = 0f;
                gameover = true;
                gameovers = true;
                cas.STOP = true;
                StartCoroutine("GameOvers");
                sh.SHORUDER = false;
            }
            if(ga.TIME <= 0.99) {
                _animationBlend = 0f;
                SprintSpeed = 0f;
                MoveSpeed = 0f;
                gameover = true;
                gameovers = true;
                cas.STOP = true;
                StartCoroutine("GameOvers");
            }
          
        }

        private void LateUpdate()
        {
            if (Alicetyutoriaru.gametutorial == false)
            {
                if (ga.START == true ) {
                    if(cas.STOP == false) {
                    
                        CameraRotation();
                    }
                }
            }
            if (Alicetyutoriaru.gametutorial == true)
            {
                if (ga.START == true)
                {
                    if (cas.STOP == false)
                    {

                        CameraRotation();
                    }
                }
            }
        }

        private void AssignAnimationIDs()
        {
           
            _animIDSpeed = Animator.StringToHash("Speed");
            _animIDGrounded = Animator.StringToHash("Grounded");
            _animIDJump = Animator.StringToHash("Jump");
            _animIDFreeFall = Animator.StringToHash("FreeFall");
            _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
           
        }

        private void GroundedCheck()
        {
            // set sphere position, with offset
            Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
                transform.position.z);
            Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
                QueryTriggerInteraction.Ignore);
            // update animator if using character
            if (_hasAnimator)
            {
                _animator.SetBool(_animIDGrounded, Grounded);
            }
            
        }

        private void CameraRotation()
        {
           

            // if there is an input and camera position is not fixed
            if (_input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
            {
                //Don't multiply mouse input by Time.deltaTime;
                float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

                _cinemachineTargetYaw += _input.look.x * deltaTimeMultiplier;
                _cinemachineTargetPitch += _input.look.y * deltaTimeMultiplier;
            }

            // clamp our rotations so our values are limited 360 degrees
            _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

            // Cinemachine will follow this target
            CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
                _cinemachineTargetYaw, 0.0f);
        }

        private void Move()
        {
            // set target speed based on move speed, sprint speed and if sprint is pressed
            if(su.SUTA == false) {
            targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed;
            } else {
                targetSpeed = MoveSpeed;
            }

            if(_input.sprint && _input.move != Vector2.zero) {
                
                sutaminamainasu = true;
            } else if(!_input.sprint) {
                sutaminamainasu = false;
            }
           
            // a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

            // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
            // if there is no input, set the target speed to 0
            if (_input.move == Vector2.zero) targetSpeed = 0.0f;

            // a reference to the players current horizontal velocity
            float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;
            
            float speedOffset = 0.1f;
            float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

            // accelerate or decelerate to target speed
            if (currentHorizontalSpeed < targetSpeed - speedOffset ||
                currentHorizontalSpeed > targetSpeed + speedOffset)
            {
                // creates curved result rather than a linear one giving a more organic speed change
                // note T in Lerp is clamped, so we don't need to clamp our speed
                _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                    Time.deltaTime * SpeedChangeRate);

                // round speed to 3 decimal places
                _speed = Mathf.Round(_speed * 1000f) / 1000f;
            }
            else
            {
                _speed = targetSpeed;
            }
           
           
            _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);
            if (_animationBlend < 0.01f) _animationBlend = 0f;
           
                
            
            // normalise input direction
            Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

            // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
            // if there is a move input rotate player when the player is moving
            if (_input.move != Vector2.zero)
            {
                _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                                  _mainCamera.transform.eulerAngles.y;
                float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                    RotationSmoothTime);

                // rotate to face input direction relative to camera position
                transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            }


            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

            // move the player
            _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) +
                             new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

            // update animator if using character
            //if(cas.STOP == false) { 
            //if(warpds == false) { //ここが双子の泣く範囲に触れてなければ
            if (_hasAnimator)
            {
                _animator.SetFloat(_animIDSpeed, _animationBlend);
                _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
            //}
        }
           
        }

        private void JumpAndGravity()
        {
            if (Grounded)
            {
                // reset the fall timeout timer
                _fallTimeoutDelta = FallTimeout;

                // update animator if using character
                if (_hasAnimator)
                {
                    _animator.SetBool(_animIDJump, false);
                    _animator.SetBool(_animIDFreeFall, false);
                }

                // stop our velocity dropping infinitely when grounded
                if (_verticalVelocity < 0.0f)
                {
                    _verticalVelocity = -2f;
                }

                // Jump
                if (_input.jump && _jumpTimeoutDelta <= 0.0f)
                {
                    // the square root of H * -2 * G = how much velocity needed to reach desired height
                    _verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);

                    // update animator if using character
                    if (_hasAnimator)
                    {
                        _animator.SetBool(_animIDJump, true);
                    }
                }

                // jump timeout
                if (_jumpTimeoutDelta >= 0.0f)
                {
                    _jumpTimeoutDelta -= Time.deltaTime;
                }
            }
            else
            {
                // reset the jump timeout timer
                _jumpTimeoutDelta = JumpTimeout;

                // fall timeout
                if (_fallTimeoutDelta >= 0.0f)
                {
                    _fallTimeoutDelta -= Time.deltaTime;
                }
                else
                {
                    // update animator if using character
                   
                    if (_hasAnimator)
                    {
                        _animator.SetBool(_animIDFreeFall, true);
                    }
                    
                }

                // if we are not grounded, do not jump
                _input.jump = false;
            }

            // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
            if (_verticalVelocity < _terminalVelocity)
            {
                _verticalVelocity += Gravity * Time.deltaTime;
            }
        }

        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }

        private void OnDrawGizmosSelected()
        {
            Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
            Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

            if (Grounded) Gizmos.color = transparentGreen;
            else Gizmos.color = transparentRed;

            // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
            Gizmos.DrawSphere(
                new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z),
                GroundedRadius);
        }

        private void OnFootstep(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                if(cas.STOP == false) { 
                if (FootstepAudioClips.Length > 0)
                {
                    var index = Random.Range(0, FootstepAudioClips.Length);
                    AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_controller.center), FootstepAudioVolume);
                }
                }
            }
        }

        private void OnLand(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                AudioSource.PlayClipAtPoint(LandingAudioClip, transform.TransformPoint(_controller.center), FootstepAudioVolume);
            }
        }
        
        private void OnControllerColliderHit(ControllerColliderHit hit) {
            if(hit.gameObject.tag == "Enemy"){
                //if(kakureteiru == false || ga.TIME == 0) {
                //ここにゲームオーバーシーンに行く
                _animationBlend = 0f;
                SprintSpeed = 0f;
                MoveSpeed = 0f;
                gameover = true;
                gameovers = true;
                cas.STOP = true;
                StartCoroutine("GameOvers");
               // }
            }
        }
        

        public void OnTriggerEnter(Collider col) {
            
            if(col.tag == "kabe")
            {
                kabe = true;
            }
            if(col.tag == "mash") {
                mash = true;
            }
            if(col.tag == "nasi") {
                door = true;
            }
            if(col.tag == "leaf") {
                kakureteiru = true;
            }
            if(col.tag == "floor") {
                floor = true;
            }
            if(col.tag == "Twin") {
                
                cry = true;
            }
            

        }

        public void OnTriggerStay(Collider col) {
            if(col.tag == "table" ) {
                if(Gamepad.current.buttonNorth.isPressed) {
                    table = true;
                }
            }
            if(col.tag == "drink") {
                if(Gamepad.current.buttonNorth.isPressed) {
                    drinkicon.SetActive(true);
                    itemaudio.PlayOneShot(itemmusic);
                    StartCoroutine("Drink");
                    drink++;
                    col.gameObject.SetActive(false);
                }
            }
            if(col.tag == "flower") {
                if(Gamepad.current.buttonNorth.isPressed) {
                    flowericon.SetActive(true);
                    if(Alicetyutoriaru.gametutorial == true)
                    {
                        whcount = 2;
                        itemaudio.PlayOneShot(itemmusic);
                        col.gameObject.SetActive(false);
                        StartCoroutine("Flower");
                    }
                    else {
                        itemaudio.PlayOneShot(itemmusic);
                        StartCoroutine("Flower");
                    whcount++;
                    col.gameObject.SetActive(false);
                    }
                }


            }
            if(col.tag == "kinoko") {
                if(Gamepad.current.buttonNorth.isPressed) {
                    itemaudio.PlayOneShot(itemmusic);
                    mashicon.SetActive(true);
                    StartCoroutine("Mash");
                    kinoko++;
                    col.gameObject.SetActive(false);
                }

            }
            if(col.tag == "Child") {
                if(Gamepad.current.buttonNorth.isPressed) {
                    itemaudio.PlayOneShot(itemmusic);
                    childicon.SetActive(true);
                    StartCoroutine("Child");
                    childcount++;
                    col.gameObject.SetActive(false);
                }

            }
            if(col.tag == "cat") {
                if(Gamepad.current.buttonNorth.isPressed) {
                    itemaudio.PlayOneShot(itemmusic);
                    caticon.SetActive(true);
                    StartCoroutine("Cat");
                    catcount++;
                    col.gameObject.SetActive(false);
                }

            }
            if(col.tag == "teatool") {
                if(col.name == "teapot") {
                    if(Gamepad.current.buttonNorth.isPressed) {
                        itemaudio.PlayOneShot(itemmusic);
                        poticon.SetActive(true);
                        StartCoroutine("Pot");
                        pot++;
                        col.gameObject.SetActive(false);

                    }

                }

                if(col.name == "teacup") {
                    if(Gamepad.current.buttonNorth.isPressed) {
                        itemaudio.PlayOneShot(itemmusic);
                        cupicon.SetActive(true);
                        StartCoroutine("Cup");
                        cup++;
                        col.gameObject.SetActive(false);
                    }

                }
                if(col.name == "spoon") {
                    if(Gamepad.current.buttonNorth.isPressed) {
                       
                        spoonicon.SetActive(true);
                        if(Alicetyutoriaru.gametutorial == true)
                        {
                            itemaudio.PlayOneShot(itemmusic);
                            tyuspoon =false;
                            tyuma.TYUCOUNT= true;
                            spoon = 2;
                            cup = 2;
                            pot = 2;
                            StartCoroutine("Spoon");
                            col.gameObject.SetActive(false);
                            
                           
                        }
                        else {
                            itemaudio.PlayOneShot(itemmusic);
                            StartCoroutine("Spoon");
                        spoon++;
                        
                        col.gameObject.SetActive(false);
                        }
                    } 
                }
            }
            if(col.tag == "mirror") {
               ve.enabled = true;
                //cas.STOP = true;
                warpds  = true;
                mirror = true;
                StartCoroutine("GoalWarp");
            }

            if(col.tag == "WarpPoint1") {
                upcamera.SetActive(true);
                warpdo = true;
               // warpds = true;
            }
            
            if(col.tag == "WarpPoint2") {
                upcamera.SetActive(true);
                warpdo = true;
               // warpds = true;
            }
            
            if(col.tag == "WarpPoint3") {
                upcamera.SetActive(true);
               warpdo = true;
               // warpds = true;
            }
            if(col.tag == "WarpPoint4") {
                upcamera.SetActive(true);
                warpdo = true;
               // warpds = true;
            }
            if(col.tag == "sea") {

                sea = true;
            }

        }

        public void OnTriggerExit(Collider col) {
            
            if(col.tag == "nasi") {
                door = false;
            }
            if(col.tag == "leaf") {
                kakureteiru = false;
                hanareru = true;
            }
            if(col.tag == "mash") {
                mash = false;
            }
            if(col.tag == "kabe")
            {
                kabe = false;
            }
            if(col.tag == "floor") {
                floor = false;
            }
            if(col.tag == "sea") {
                sea = false;
            }

        }
        IEnumerator GameOvers() {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("GameOver");
        }

        IEnumerator Pot() {
            yield return new WaitForSeconds(1.0f);
            poticon.SetActive(false);
            poticon.transform.position = pi;
        }
        IEnumerator Cup() {
            yield return new WaitForSeconds(1.0f);
            cupicon.SetActive(false);
            cupicon.transform.position = ci;
        }
        IEnumerator Spoon() {
            yield return new WaitForSeconds(1.0f);
            spoonicon.SetActive(false);
            spoonicon.transform.position = sn;
        }
        IEnumerator Mash() {
            yield return new WaitForSeconds(1.0f);
            mashicon.SetActive(false);
            mashicon.transform.position = mi;
        }
        IEnumerator Drink() {
            yield return new WaitForSeconds(1.0f);
            drinkicon.SetActive(false);
            drinkicon.transform.position = di;
        }
        IEnumerator Flower() {
            yield return new WaitForSeconds(1.0f);
            flowericon.SetActive(false);
            flowericon.transform.position = fi;
        }
        IEnumerator Child() {
            yield return new WaitForSeconds(1.0f);
            childicon.SetActive(false);
            childicon.transform.position = cin;
        }
        IEnumerator Cat() {
            yield return new WaitForSeconds(1.0f);
            caticon.SetActive(false);
            caticon.transform.position = cat;
        }
        IEnumerator GoalWarp() {
            yield return new WaitForSeconds(3.0f);
            //transform.position = goalwarp.transform.position;
            mirror = false;
            warpds = false;
        }
    }
}
