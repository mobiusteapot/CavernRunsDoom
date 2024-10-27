using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoomInputManager : MonoBehaviour {
	[Header("Input")]
	[SerializeField] private InputActionReference moveAction = null;
	[SerializeField] private InputActionReference useAction = null;
	[SerializeField] private InputActionReference shootAction = null;
	[SerializeField] private InputActionReference switchWeapon1 = null;
	[SerializeField] private InputActionReference switchWeapon2 = null;
	[SerializeField] private InputActionReference switchWeapon3 = null;
	[SerializeField] private float deadZone = 0.1f;
	[SerializeField] private PlayerControls controller = null;
	[SerializeField] private WeaponManager weaponManager = null;
	
	private void OnEnable() {
		moveAction.action.Enable();
		moveAction.action.performed += OnMove;
		moveAction.action.canceled += OnMove;
		shootAction.action.Enable();
		shootAction.action.performed += OnShoot;
		useAction.action.Enable();
		useAction.action.performed += OnUse;
		switchWeapon1.action.Enable();
		switchWeapon2.action.Enable();
		switchWeapon3.action.Enable();
		switchWeapon1.action.performed += ctx => weaponManager.SetSelectedWeapon(0);
		switchWeapon2.action.performed += ctx => weaponManager.SetSelectedWeapon(1);
		switchWeapon3.action.performed += ctx => weaponManager.SetSelectedWeapon(2);
	}
	private void OnDisable()
	{
		moveAction.action.performed -= OnMove;
		moveAction.action.canceled -= OnMove;
		shootAction.action.performed -= OnShoot;
		useAction.action.performed -= OnUse;
		switchWeapon1.action.performed -= ctx => weaponManager.SetSelectedWeapon(0);
		switchWeapon2.action.performed -= ctx => weaponManager.SetSelectedWeapon(1);
		switchWeapon3.action.performed -= ctx => weaponManager.SetSelectedWeapon(2);
	}
	private void OnMove(InputAction.CallbackContext ctx){
		if(Doom.isPaused)
			return;
		if(ctx.performed){
			var input = ctx.ReadValue<Vector2>();
			if (input.magnitude < deadZone)
			{
				controller.SetInput(Vector2.zero);
				return;
			}
			else
			{
				controller.SetInput(ctx.ReadValue<Vector2>());
			}
		}
		else if(ctx.canceled){
			controller.SetInput(Vector2.zero);
		}
	}

	private void OnUse(InputAction.CallbackContext ctx){
		if(Doom.isPaused)
			return;
		controller.TryUse();
	}
	private void OnShoot(InputAction.CallbackContext ctx){
		if(Doom.isPaused)
			return;
		if (controller.Health > 0) {
			weaponManager.Shoot ();
		} else {
			controller.Revive(true);
		}
	}
	// Old input, kept for reference
	// void Update ()
	// {
	// 	if (Doom.isPaused)
	// 		return;

	// 	// Move
	// 	// Moved to new input system
	// 	//controller.SetInput (new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")));

	// 	// Use Environment Items
	// 	// if (Input.GetKeyDown (KeyCode.Space)) {
	// 	// 	controller.TryUse ();
	// 	// }
		
	// 	// Shoot
	// 	// if (Input.GetMouseButtonDown (0)) {
	// 	// 	if (controller.Health > 0) {
	// 	// 		weaponManager.Shoot ();
	// 	// 	} else {
	// 	// 		controller.Revive(true);
	// 	// 	}
	// 	// }

	// 	// // Switch Weapons - is there a better way to do this?
	// 	// if (Input.GetKeyDown (KeyCode.Alpha1)) {
	// 	// 	weaponManager.SetSelectedWeapon(0);
	// 	// }
	// 	// if (Input.GetKeyDown (KeyCode.Alpha2)) {
	// 	// 	weaponManager.SetSelectedWeapon(1);
	// 	// }
	// 	// if (Input.GetKeyDown (KeyCode.Alpha3)) {
	// 	// 	weaponManager.SetSelectedWeapon(2);
	// 	// }
	// }
}
