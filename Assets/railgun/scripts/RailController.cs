using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailController : MonoBehaviour, IWeapon
{
    private WeaponControl weaponControl;
    public int damage;
    public GameObject railParticle;

    // Use this for initialization
    void Start()
    {
        weaponControl = gameObject.transform.parent.gameObject.GetComponent<WeaponControl>();
        weaponControl.Switched(this);
    }
    public void Charge()
    {
        Vector3 fwd = transform.parent.TransformDirection(Vector3.forward);
        RaycastHit hit;
        GameObject startPoint = transform.Find("startpoint").gameObject;
        if (Physics.Raycast(startPoint.transform.position, fwd, out hit))
        {
            float step = 0.2f;
            float particleCount = hit.distance / step;
            float currentStep = 0;
            List<GameObject> partList = new List<GameObject>();
            for (int i = 0; i < particleCount; ++i)
            {
                currentStep += step;
                Vector3 position = Vector3.MoveTowards(startPoint.transform.position, hit.point, currentStep);
                var part = Instantiate(railParticle, position, new Quaternion(1f, 1f, 1f, 1f));
                partList.Add(part);
            }
            for (int i = 0; i < partList.Count; i++)
            {
                Destroy(partList[i].gameObject, 0.3f);
            }
            GameObject target = hit.transform.gameObject;
            if(target.tag == "Player1" || target.tag == "Player2")
            {
                target.GetComponent<DamageController>().ApplyDamage(damage);
            }
        }
    }
    public void Fire()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
