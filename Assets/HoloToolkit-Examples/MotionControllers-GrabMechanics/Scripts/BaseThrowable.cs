﻿using UnityEngine;

namespace MRTK.Grabbables {
    /// <summary>
    /// The abstract class that defines the minimum amount of content for any throwable object
    /// Variables declared at the bottom
    /// </summary>

    public abstract class BaseThrowable : MonoBehaviour
    {
        public float ThrowMultiplier { get { return throwMultiplier; } set { throwMultiplier = value; } }
        public bool ZeroGravityThrow { get { return zeroGravityThrow; } set { zeroGravityThrow = value; } }

        protected virtual void Awake()
        {
            grabbable = GetComponent<BaseGrabbable>();
        }

        /// <summary>
        /// throw needs to subscribe to grab events in order to track the speed/velocity/position of the grabber that has it
        /// </summary>
        protected virtual void OnEnable()
        {
            grabbable.OnReleased += Throw;
        }

        protected virtual void OnDisable()
        {
            grabbable.OnReleased -= Throw;
        }

        protected virtual void BeginThrow()
        {
            Debug.Log("Begin throw detected.");
        }

        protected virtual void MidThrow()
        {
            Debug.Log("mid throw...");
        }

        protected virtual void ReleaseThrow()
        {
            Debug.Log("Throw release...");
        }

        protected virtual void OnThrowCanceled()
        {
            Debug.Log("Throw canceled");
        }

        /// <summary>
        /// throw behaviour should be over ridden in a non-abstract class
        /// </summary>
        /// <param name="grabber"></param>
        public virtual void Throw(BaseGrabbable grabber)
        {
            Debug.Log("Throwing..");
        }

        private BaseGrabbable grabbable;

        [SerializeField]
        private float throwMultiplier;

        [SerializeField]
        private bool zeroGravityThrow;

        [SerializeField]
        private AnimationCurve velocityOverTime;

        [SerializeField]
        private AnimationCurve upDownCurveOverTime;

        [SerializeField]
        private AnimationCurve leftRightCurveOverTime;

    }
}