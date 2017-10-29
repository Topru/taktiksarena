using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private string pTag;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            pTag = gameObject.tag;
        }

        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal" + pTag);
            float v = CrossPlatformInputManager.GetAxis("Vertical" + pTag);
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump" + pTag);
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
