using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public abstract class BaseCharacterAnimation : MonoBehaviour
    {
        [SerializeField] protected Animator animator;

        protected virtual void Update()
        {
            UpdateAnimations(Time.deltaTime);
        }

        protected abstract void UpdateAnimations(float dt);

        public void Flip(bool isRight)
        {
            float angle = isRight ? 0f : 180f;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        public bool IsCurrentlyOnState(string stateName)
        {
            return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
        }

        public float GetAnimationNormalizedTime()
        {
            return animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        }

        public void PlayAnimation(string stateName)
        {
            animator.Play(stateName, 0, 0f);
        }

        protected void PlayAnimIfNotAlreadyPlaying(string stateName)
        {
            if (!IsCurrentlyOnState(stateName))
            {
                PlayAnimation(stateName);
            }
        }
    }
}
