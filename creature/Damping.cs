using System;
using UnityEngine;
using System.Collections;

namespace UnityDamping
{
    public class Damping
    {
        public float lerp;

        public float damping(float target, float current, float lerp)
        {
            lerp = this.lerp;
            return Mathf.Lerp(current, target, lerp);
        }
    }
}