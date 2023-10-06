using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Code.PersistentObject
{
    public class Transitions : MonoBehaviour
    {
        private Transform _transitionObject;
        [SerializeField] private GameObject transitionObjectPrefab;
        [SerializeField] private Sprite[] sceneTransitionsSprites;
        
        //change scene with an animation
        public void ChangeSceneWithTransition(string sceneName, int transitionSpriteIndex, int transitionIndex, float transitionTime)
        {
            LaunchTransition(transitionSpriteIndex, transitionIndex, false, transitionTime);
            StartCoroutine(ChangeSceneAfterLoaded(sceneName, transitionTime));
        }

        private IEnumerator ChangeSceneAfterLoaded(string sceneName, float minimumLoadingTime)
        {
            yield return new WaitForSeconds(minimumLoadingTime);
            //AsyncOperation sceneLoadingOperation = SceneManager.LoadSceneAsync(sceneName);
            SceneManager.LoadSceneAsync(sceneName);
        }

        //create a transition object
        private Transform CreateTransitionObject()
        {
            //if the object reference doesn't contains objects return nothing
            if (transitionObjectPrefab == null)
            {
                return null;
            }
            
            //get the canvas in the scene
            Canvas canvas = FindObjectOfType<Canvas>();
            
            //return null if there is no canvas
            if (canvas == null)
            {
                return null;
            }
            
            //create the transition object
            GameObject newTransitionObject = Instantiate(transitionObjectPrefab, canvas.transform);
            
            //return the transition object
            return newTransitionObject.transform;
        }

        public void LaunchStartTransition(int transitionSpriteIndex, int transitionIndex, float transitionTime)
        {
            LaunchTransition(transitionSpriteIndex, transitionIndex, true, transitionTime);
        }

        private void LaunchTransition(int transitionSpriteIndex, int transitionIndex, bool isEntryTransition, float transitionTime)
        {
            RemoveTransitionObject();
            
            _transitionObject = CreateTransitionObject();
            
            //if there is no transition object, return because it's impossible to do the transition
            if (_transitionObject == null)
            {
                return;
            }

            Animator transitionObjectAnimator = _transitionObject.GetComponent<Animator>();
            Image transitionObjectImage = _transitionObject.GetComponent<Image>();

            //if there is no animator or no Image on the transition object
            //return because it's impossible to launch the animation
            if (transitionObjectAnimator == null && transitionObjectImage == null)
            {
                return;
            }
            
            //sets the selected properties
            //clamping the index to avoid list index out of range
            transitionObjectImage.sprite = sceneTransitionsSprites[
                Mathf.Clamp(transitionSpriteIndex, 0, sceneTransitionsSprites.Length)];
            transitionObjectAnimator.SetInteger(Animator.StringToHash("animationIndex"), transitionIndex);
            transitionObjectAnimator.SetBool(Animator.StringToHash("isEntryAnimation"), isEntryTransition);
            transitionObjectAnimator.speed = 1/transitionTime;
        }

        private void RemoveTransitionObject()
        {
            //destroy the transition object if it exists
            if (_transitionObject != null)
            {
                Destroy(_transitionObject.gameObject);
            }
            
            //stop coroutines to avoid changing scene two times
            StopAllCoroutines();
        }
    }
}
