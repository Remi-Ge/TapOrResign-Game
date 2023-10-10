using UnityEngine;

namespace Code.BackgroundPrefab
{
    public class Background : MonoBehaviour
    {
        //the height of a single tile
        [SerializeField] private float tileHeight = 10f; //change in editor
        private Transform _mainCamera;

        private void Awake()
        {
            _mainCamera = FindObjectOfType<Camera>().transform;
        }

        private void Update()
        {
            FollowCamera();
        }

        private void FollowCamera()
        {
            transform.position = new Vector3(0, Mathf.Round(_mainCamera.position.y/tileHeight)*tileHeight, 0);
        }

        public void SetTilesSize(float cameraOrthographicSize)
        {
            //get the background sprite renderer on the background
            SpriteRenderer backgroundSpriteRenderer = GetComponent<SpriteRenderer>();
            
            //return if the background has no sprite renderer
            if (backgroundSpriteRenderer == null)
            {
                return;
            }

            //sets the tiles size
            backgroundSpriteRenderer.size = new Vector2(backgroundSpriteRenderer.size.x
            , cameraOrthographicSize / 2 + tileHeight / transform.localScale.y);
        }
    }
}