using UnityEngine;


namespace Code.Play
{
    public class PlayerCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("deadly"))
            {
                DeadlyCollision();
            }
        }

        private void DeadlyCollision()
        {
            Debug.LogWarning("not done!");
        }
    }
}