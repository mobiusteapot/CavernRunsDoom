using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour {
	[Header("Input")]
	[SerializeField] private InputActionReference moveAction = null;
	[SerializeField] private PlayerControls controller = null;
	[SerializeField] private WeaponManager weaponManager = null;
	
	private void OnEnable() {
		moveAction.action.Enable();
		moveAction.action.performed += OnMove;
		moveAction.action.canceled += OnMove;
	}
	private void OnDisable()
	{
		moveAction.action.performed -= OnMove;
		moveAction.action.canceled -= OnMove;
	}
	private void OnMove(InputAction.CallbackContext context){
		controller.SetInput(context.ReadValue<Vector2>());
	}
	// Update is called once per frame
	void Update ()
	{
		if (Doom.isPaused)
			return;

		// Move
		// Moved to new input system
		//controller.SetInput (new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")));

		// Use Environment Items
		if (Input.GetKeyDown (KeyCode.Space)) {
			controller.TryUse ();
		}
		
		// Shoot
		if (Input.GetMouseButtonDown (0)) {
			if (controller.Health > 0) {
				weaponManager.Shoot ();
			} else {
				controller.Revive(true);
			}
		}

		// Switch Weapons - is there a better way to do this?
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			weaponManager.SetSelectedWeapon(0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			weaponManager.SetSelectedWeapon(1);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			weaponManager.SetSelectedWeapon(2);
		}
	}
}
