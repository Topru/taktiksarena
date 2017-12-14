using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetWeapon : MonoBehaviour {
    public Texture railgun;
    public Texture gun;
    public Texture aagun;
    private GameObject player;
    private RawImage image;
    private IWeapon currentWeapon;
    // Use this for initialization
    void Start()
    {
        string playerTag;
        if (gameObject.transform.parent.transform.parent.transform.parent.tag == "Player1UI")
        {
            playerTag = "Player1";
        }
        else
        {
            playerTag = "Player2";
        }
        player = GameObject.FindGameObjectWithTag(playerTag);
        image = gameObject.GetComponent<RawImage>();
        currentWeapon = player.GetComponent<WeaponControl>().GetWeapon();

    }
    // Update is called once per frame
    void Update()
    {
        currentWeapon = player.GetComponent<WeaponControl>().GetWeapon();
        if (currentWeapon != null)
        {
            string weaponName = currentWeapon.GetName();
            if (weaponName == "railgun(Clone)")
            {
                image.texture = railgun;
            }
            if (weaponName == "Gun(Clone)")
            {
                image.texture = gun;
            }
            if (weaponName == "aagun(Clone)")
            {
                image.texture = aagun;
            }
        }
    }
}
