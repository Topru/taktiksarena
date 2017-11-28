using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAController : WeaponMaster
{
    public int damage;
    public GameObject aaBullet;
    public GameObject aaExplosion;
    public float fireRate;
    public float timeToOverHeat;
    public float spread;
    private bool fire;
    private GameObject startPoint;
    private float lastFire;
    private float overHeatAt;
    public float overHeatPercent;
    public float timeLeft;
    private float cooledTime;
    public float timeToCool;

    public override void Start()
    {
        startPoint = transform.Find("startpoint").gameObject;
        base.Start();
    }

    public override void Charge()
    {
        if (!onCd)
        {
            overHeatAt = Time.time + timeToOverHeat - timeToOverHeat*overHeatPercent/100;
            fire = true;
        }

    }
    public override void Fire()
    {
        cooledTime = Time.time + (float)cdAmount * overHeatPercent / 100;
        fire = false;
    }

    public override float GetCharge()
    {
        return overHeatPercent;
    }

    public override void FixedUpdate()
    {
        if (fire)
        {
            if (!onCd)
            {
                timeLeft = overHeatAt - Time.time;
                overHeatPercent = (timeToOverHeat - timeLeft) / timeToOverHeat * 100;
            }
            if(timeLeft <= 0)
            {
                onCd = true;
                timeStamp = Time.time + cdAmount;
            }
            if (Time.time >= lastFire + fireRate && !onCd)
            {
                float accuracy = spread;
                float randomOffset_y = UnityEngine.Random.Range(-(1 - accuracy), 1 - accuracy);

                Vector3 direction = transform.forward;
                direction.y += randomOffset_y;
                transform.localRotation = Quaternion.Euler(0, direction.y, 0);
                RaycastHit hit;
                if (Physics.Raycast(startPoint.transform.position, transform.forward, out hit))
                {
                    Vector3 position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    Instantiate(aaExplosion, position, gameObject.transform.rotation);
                }
                lastFire = Time.time;
            }
        }
        if (!onCd && !fire)
        {
            timeToCool = cooledTime - Time.time;
            overHeatPercent = timeToCool/(float)cdAmount * 100;
            if(timeToCool < 0)
            {
                timeToCool = 0;
            }
        }
        if(timeLeft < 0)
        {
            timeLeft = 0;
        }
        if(overHeatPercent < 0)
        {
            overHeatPercent = 0;
        }
        if (overHeatPercent > 100)
        {
            overHeatPercent = 100;
        }
        base.FixedUpdate();
    }

}
