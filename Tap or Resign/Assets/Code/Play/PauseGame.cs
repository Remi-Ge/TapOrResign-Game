using UnityEngine;

namespace Code.Play
{
    public class PauseGame : MonoBehaviour
    {
        [SerializeField] private Animator pauseAnimator;

        public void OpenPauseMenu()
        {
            pauseAnimator.SetBool(Animator.StringToHash("isPaused"), true);
        }
        
        public void ClosePauseMenu()
        {
            pauseAnimator.SetBool(Animator.StringToHash("isPaused"), false);
        }
    }
}
