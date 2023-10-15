using UnityEngine;

namespace Code.UI
{
    public class LevelsScroll : MonoBehaviour
    {
        [SerializeField] private RectTransform scrollRectContent;
        [SerializeField] private GameObject levelPrefab;
        private int _levelNumber;

        private void Start()
        {
            SetScrollAreaSize(5);
        }

        private void SetScrollAreaSize(int levelNumber)
        {
            _levelNumber = levelNumber;
            scrollRectContent.offsetMin = new Vector2(scrollRectContent.offsetMin.x,
                -500 * (levelNumber - 1));

            for (int i = 0; i < levelNumber; i++)
            {
                SpawnLevel(i);
            }
        }

        private void SpawnLevel(int levelIndex)
        {
            GameObject newLevel = Instantiate(levelPrefab, scrollRectContent);
            newLevel.GetComponent<RectTransform>().anchoredPosition = 
                new Vector2(0, 500 * (_levelNumber - 1) / 2f + -500 * levelIndex);
        }
    }
}