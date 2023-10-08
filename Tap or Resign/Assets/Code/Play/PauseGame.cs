using UnityEngine;

namespace Code.Play
{
    public class PauseGame : MonoBehaviour
    {
        [HideInInspector] public bool isPaused;
        [SerializeField] private Animator pauseAnimator;

        public void OpenPauseMenu()
        {
            isPaused = true;
            pauseAnimator.SetBool(Animator.StringToHash("isPaused"), true);
        }
        
        public void ClosePauseMenu()
        {
            isPaused = false;
            pauseAnimator.SetBool(Animator.StringToHash("isPaused"), false);
        }
    }
}
