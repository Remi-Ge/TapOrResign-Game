using UnityEngine;


namespace Code.Play
{
    public class PlayerCollision : MonoBehaviour
    {
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

        private void DeadlyCollision()
        {
            Debug.LogWarning("not done!");
        }
    }
}