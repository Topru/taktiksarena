using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Helpers;

public class WeaponControl : MonoBehaviour {
    // Use this for initialization
    private IWeapon currentWeapon;

    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonDown("Fire1" + tag))
        {
            currentWeapon.Charge();
        }
        if (CrossPlatformInputManager.GetButtonUp("Fire1" + tag))
        {
            currentWeapon.Fire();
        }
    }
    public void Switched(IWeapon newWeapon)
    {
        Debug.Log("New Weapon");
        currentWeapon = newWeapon;
    }
}
