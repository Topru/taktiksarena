using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMaster : MonoBehaviour, IWeapon {

    private WeaponControl weaponControl;
    public float cdPercent;
    public double timeStamp = 0; //cooldown
    public bool onCd;
    public bool softCd;
    public double cdAmount;
    public AudioSource shootClip;

    // Use this for initialization
    public virtual void Start () {
        weaponControl = gameObject.transform.parent.gameObject.GetComponent<WeaponControl>();
        shootClip = GetComponent<AudioSource>();
        weaponControl.Switched(this);
    }

    public virtual void Fire()
    {

    }

    public virtual void Charge()
    {

    }

    public virtual float GetCharge()
    {
        return 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public float GetCd()
    {
        return cdPercent;
    }
    public string GetName()
    {
        return gameObject.name;
    }

    public virtual void FixedUpdate()
    {
        if (timeStamp <= Time.time)
        {
            onCd = false;
            cdPercent = 0;
        }
        if (onCd)
        {
            float cd = Mathf.Abs((float)timeStamp - (float)Time.time);
            cdPercent = cd / (float)cdAmount * 100;
        }
    }
}
