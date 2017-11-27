using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCharge : MonoBehaviour {

    private IWeapon currentWeapon;
    private GameObject player;
    private Slider slider;

    // Use this for initialization
    void Start () {
        string playerTag;
        if (gameObject.transform.parent.transform.parent.tag == "Player1UI")
        {
            playerTag = "Player1";
        }
        else
        {
            playerTag = "Player2";
        }
        player = GameObject.FindGameObjectWithTag(playerTag);
        slider = gameObject.GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        currentWeapon = player.GetComponent<WeaponControl>().GetWeapon();
        if (currentWeapon == null)
        {
            return;
        }
        float charge = currentWeapon.GetCharge();
        float cd = currentWeapon.GetCd();
        if (cd == 0)
        {
            slider.value = charge;
        }
        else
        {
            slider.value = cd;
        }
    }
}
