using Code.SavesData.DataStructs;
using UnityEngine;

namespace Code.PersistentObject
{
    public class Skins : MonoBehaviour
    {
        [SerializeField] private Sprite[] bodyTypes;
        [SerializeField] private Color[] bodyColors;
        [SerializeField] private Sprite[] eyesTypes;
        [SerializeField] private Color[] eyesColors;

        public void ApplySkin(Transform playerTransform, SkinsStruct.SkinStruct skin)
        {
            Transform playerSpritesTransform = playerTransform.Find("sprites");

            //checks if the player has no sprites game object
            if (playerSpritesTransform == null)
            {
                return;
            }
            
            //animation
            Animator playerAnimator = playerSpritesTransform.GetComponent<Animator>();
            if (playerAnimator != null)
            {
                playerAnimator.SetInteger(Animator.StringToHash("animationIndex"), skin.animationType);
            }
            
            //body
            Transform playerBodyTransform = playerSpritesTransform.Find("body");
            if (playerSpritesTransform != null)
            {
                SpriteRenderer bodySpriteRender = playerBodyTransform.GetComponent<SpriteRenderer>();
                //check if there is a sprite renderer on the body
                if (bodySpriteRender != null)
                {
                    if (skin.bodyType > bodyTypes.Length || skin.bodyType < 0) //check if bodyType is valid
                    {
                        bodySpriteRender.sprite = bodyTypes[skin.bodyType];
                    }
                    else
                    {
                        //apply the skin not found texture
                    }
                    
                    if (skin.bodyColor > bodyColors.Length || skin.bodyColor < 0) //check if bodyType is valid
                    {
                        bodySpriteRender.color = bodyColors[skin.bodyColor];
                    }
                    else
                    {
                        //apply the skin not found color
                    }
                }
            }
            
            //eyes
            Transform eyesParent = playerBodyTransform.Find("eyes");
            //checks if the eye parent exists
            if (eyesParent != null)
            {
                Transform eye1 = eyesParent.Find("eye1");
                Transform eye2 = eyesParent.Find("eye2");
                if (eye1 != null && eye2 != null)
                {
                    SpriteRenderer eye1SpriteRenderer = eye1.GetComponent<SpriteRenderer>();
                    SpriteRenderer eye2SpriteRenderer = eye2.GetComponent<SpriteRenderer>();

                    if (eye1SpriteRenderer != null && eye2SpriteRenderer != null)
                    {
                        if (skin.eyesType > eyesTypes.Length || skin.eyesType < 0) //check if bodyType is valid
                        {
                            eye1SpriteRenderer.sprite = eyesTypes[skin.eyesType];
                            eye2SpriteRenderer.sprite = eyesTypes[skin.eyesType];
                        }
                        else
                        {
                            //apply the skin not found texture
                        }

                        if (skin.eyesColor > eyesColors.Length || skin.eyesColor < 0)
                        {
                            eye1SpriteRenderer.color = eyesColors[skin.eyesColor];
                            eye2SpriteRenderer.color = eyesColors[skin.eyesColor];
                        }
                        else
                        {
                            //apply bugged color
                        }
                    }
                }
            }
        }
    }
}