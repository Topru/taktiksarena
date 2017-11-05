using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;
using Helpers;

public class WeaponControl : NetworkBehaviour {
    // Use this for initialization
    private IWeapon currentWeapon;

    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
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
