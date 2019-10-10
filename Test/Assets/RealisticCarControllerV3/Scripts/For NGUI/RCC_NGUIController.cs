//----------------------------------------------
//            Realistic Car Controller
//
// Copyright © 2015 BoneCracker Games
// http://www.bonecrackergames.com
//
//----------------------------------------------

using UnityEngine;
using System.Collections;

[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Mobile/NGUI Button")]
public class RCC_NGUIController : MonoBehaviour {

	// Getting an Instance of Main Shared RCC Settings.
	#region RCC Settings Instance

	private RCC_Settings RCCSettingsInstance;
	private RCC_Settings RCCSettings {
		get {
			if (RCCSettingsInstance == null) {
				RCCSettingsInstance = RCC_Settings.Instance;
			}
			return RCCSettingsInstance;
		}
	}

	#endregion

	internal float input;
	private float sensitivity{get{return RCCSettings.UIButtonSensitivity;}}
	private float gravity{get{return RCCSettings.UIButtonGravity;}}
	public bool pressing;

	void OnPress (bool isPressed){
		
		if(isPressed)
			pressing = true;
		else
			pressing = false;
		
	}

	void Update(){

		if(pressing)
			input += Time.deltaTime * sensitivity;
		else
			input -= Time.deltaTime * gravity;

		if(input < 0f)
			input = 0f;
		if(input > 1f)
			input = 1f;

	}

	void OnDisable(){

		input = 0f;
		pressing = false;

	}

}
