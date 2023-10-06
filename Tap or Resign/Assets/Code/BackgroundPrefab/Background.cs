using UnityEngine;

namespace Code.BackgroundPrefab
{
    public class Background : MonoBehaviour
    {
        //the height of a single tile
        [SerializeField] private float tileHeight = 10f; //change in editor
        
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