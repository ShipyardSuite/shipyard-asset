using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shipyard.shared
{
    public class LoadingIndicator : MonoBehaviour
    {
        public GameObject innerRing;
        public GameObject outerRing;

        public float speed = 10;

        void Update()
        {
            innerRing.transform.Rotate((Vector3.back * (10 * speed)) * Time.deltaTime);
            outerRing.transform.Rotate((-Vector3.back * (10 * speed)) * Time.deltaTime);
        }
    }
}
