using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public interface IWeapon
{
    [Command]
    void Fire();
    [Command]
    void Charge();
}