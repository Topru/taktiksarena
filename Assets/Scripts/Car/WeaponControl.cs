using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Helpers;

public class WeaponControl : MonoBehaviour {
    WeaponController weaponController;
    private string tag;
    // Use this for initialization
    void Start () {
        GameObject weapon = gameObject.FindChildrenWithTag("Weapon");
        weaponController = weapon.GetComponent<WeaponController>();
        tag = gameObject.tag;
    }
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonDown("Fire1" + tag))
        {
            weaponController.Charge();
        }
        if (CrossPlatformInputManager.GetButtonUp("Fire1" + tag))
        {
            weaponController.Fire();
        }
    }
}
