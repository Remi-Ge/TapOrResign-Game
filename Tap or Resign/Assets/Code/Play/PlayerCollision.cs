using UnityEngine;


namespace Code.Play
{
    public class PlayerCollision : MonoBehaviour
    {
        private int _waterTriggers;
        private float _defaultDrag;
        private int _touchedWaterNumber;

        private void Awake()
        {
            _defaultDrag = GetComponent<Rigidbody2D>().drag;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            //check if deadly
            if (other.collider.CompareTag("deadly"))
            {
                DeadlyCollision();
            }
            
            //check if it's a bouncer
            if (other.collider.name == "bouncerCollider")
            {
                Animator bouncerAnimator =
                    other.collider.gameObject.transform.parent.GetComponentInChildren<Animator>();
                if (bouncerAnimator != null)
                {
                    bouncerAnimator.Play(Animator.StringToHash("bouncerBounce"));
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("slowly"))
            {
                _touchedWaterNumber += 1;
                UpdateDrag();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("slowly"))
            {
                _touchedWaterNumber -= 1;
                UpdateDrag();
            }
        }

        private void UpdateDrag()
        {
            if (_touchedWaterNumber == 0)
            {
                GetComponent<Rigidbody2D>().drag = _defaultDrag;
            }
            else
            {
                GetComponent<Rigidbody2D>().drag = _defaultDrag + 3;
            }
        }

        private void DeadlyCollision()
        {
            Debug.LogWarning("not done!");
        }
    }
}