﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public interface IWeapon
{
    void CmdFire();
    void CmdCharge();
}