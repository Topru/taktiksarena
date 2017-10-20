using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private string tag;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            tag = gameObject.tag;
        }

        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal" + tag);
            float v = CrossPlatformInputManager.GetAxis("Vertical" + tag);
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump" + tag);
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
