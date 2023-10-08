using System.Collections.Generic;
using Code.CameraPrefab;
using Code.PersistentObject;
using UnityEngine;

namespace Code.Play
{
    public class Explosions : MonoBehaviour
    {
        [SerializeField] private GameObject explosionPrefab;
        private CameraSize _cameraSize;
        
        private readonly float _explosionSize = 15f;
        private readonly float _maxForce = 10f;

        private void Awake()
        {
            _cameraSize = FindObjectOfType<CameraSize>();
        }

        private void Update()
        {
            CheckTouches();
        }

        private void CheckTouches()
        {
            //checks if the game is not paused
            if (!GetComponent<PauseGame>().isPaused)
            {
                List<Touch> beganTouches= Persistent.GetPersistentObject().GetComponent<Touches>().GetBeganTouches();

                foreach (Touch beganTouch in beganTouches)
                {
                    SpawnExplosion(beganTouch);
                }
            }
        }

        private void SpawnExplosion(Touch newTouch)
        {
            Vector2 explosionPosition = _cameraSize.ScreenToWorldPoint(newTouch.position);
            Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);
            //apply forces
            ApplyForces(explosionPosition);
        }
    
        //apply forces to rigidbody 2D
        private void ApplyForces(Vector2 worldSpacePosition)
        {
            //get close objects with their colliders
            Collider2D[] closeObjects = new Collider2D[20];
            Physics2D.OverlapCircleNonAlloc(worldSpacePosition, _explosionSize, closeObjects);
            //Collider2D[] closeObjects = Physics2D.OverlapCircleAll(worldSpacePosition, _explosionSize);
            foreach (Collider2D closeObject in closeObjects)
            {
                //check if the collider is null and break if yes
                if (closeObject == null)
                { 
                    break;
                }
                Rigidbody2D objectRigidbody = closeObject.transform.parent.gameObject.GetComponent<Rigidbody2D>();
                //check if the object has a rigidbody
                if (objectRigidbody != null)
                {
                    //calculate force to add
                    Vector2 neededForce = closeObject.transform.position - 
                                          new Vector3(worldSpacePosition.x, worldSpacePosition.y, 0);
                    neededForce = neededForce.normalized * (_maxForce - (neededForce.magnitude / _explosionSize * _maxForce));
                    //add the force to the position and the rotation
                    objectRigidbody.AddForce(neededForce, ForceMode2D.Impulse);
                    objectRigidbody.AddTorque(Random.Range(-15,15) * (neededForce.magnitude / _maxForce), ForceMode2D.Force);
                }
            }
        }
    }
}