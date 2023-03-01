using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

        
		[Header("Mouse Cursor Settings")]
		//public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		[SerializeField] private GameObject pl;
		StarterAssets.ThirdPersonController th;
		[SerializeField] private GameObject area;
		SwitchCamera sw;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED

		private void Start() {
			sw = area.GetComponent<SwitchCamera>();
			th = pl.GetComponent<StarterAssets.ThirdPersonController>();
        }

		
        private void Update() {
            if(th.GAMEOVER == true) {
				cursorInputForLook = false;
				look.x = 0;
				look.y = 0;
				move.x = 0;
				move.y = 0;

			} /*else {
				cursorInputForLook = true;
			}
			*/
			if(th.WARP == true) {
				cursorInputForLook = false;
				StartCoroutine("Warps");
			}
			if(sw.MOVES == true) {
				cursorInputForLook = false;
				StartCoroutine("Came");
			}

        }
		

        public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(th.GAMEOVER == false) {
				if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			if(th.GAMEOVER == false) {
				look = newLookDirection;
			}
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
		/*
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
		*/
		IEnumerator Warps() {
			yield return new WaitForSeconds(6.0f);
			cursorInputForLook = true;
		}
		IEnumerator Came() {
			yield return new WaitForSeconds(8.0f);
			cursorInputForLook = true;
		}
	}
	
}

