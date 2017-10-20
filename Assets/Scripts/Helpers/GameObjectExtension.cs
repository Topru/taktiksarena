using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public static class GameObjectExtensions
    {

        public static GameObject FindChildrenWithTag(this GameObject go, string tagToFind)
        {
            Transform trans = go.transform;
            int childCount = trans.childCount;
            //Debug.LogError( go.name + " ChildCount: " + childCount);
            for (int i = 0; i < childCount; ++i)
            {
                Transform child = trans.GetChild(i);
                if (child.gameObject.tag == tagToFind)
                {
                    return child.gameObject;
                }
            }
            return null;
        }
    }
}