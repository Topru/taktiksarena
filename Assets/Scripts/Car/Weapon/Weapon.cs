﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Fire();
    void Charge();
    float GetCharge();
    float GetCd();
    string GetName();
}