using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.UI
{
    public class LevelsScroll : MonoBehaviour
    {
        [SerializeField] private RectTransform scrollRectContent;
        [SerializeField] private GameObject levelPrefab;
        private int _levelsNumber;
        private readonly List<Tuple<int, RectTransform>> _levels = new List<Tuple<int, RectTransform>>(); //the spawned levels

        private void Start()
        {
            SetScrollAreaSize(50);
        }

        private void SetScrollAreaSize(int levelNumber)
        {
            _levelsNumber = levelNumber;
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
            RectTransform levelRectTransform = newLevel.GetComponent<RectTransform>(); 
            levelRectTransform.anchoredPosition = 
                new Vector2(0, 500 * (_levelsNumber - 1) / 2f + -500 * levelIndex);
            _levels.Add(new Tuple<int, RectTransform>(levelIndex, levelRectTransform));
        }

        public void ScrollRectMoved()
        {
            //max distance from the middle of the screen
            float maxLevelsDistance = 3000f;
            
            float contentTop = scrollRectContent.offsetMax.y;
            
            //checks if the levels are too far
            for (int i = 0; i < _levels.Count; i++)
            {
                if (Mathf.Abs(contentTop - 500 * _levels[i].Item1) > maxLevelsDistance)
                {
                    Destroy(_levels[i].Item2.gameObject);
                    _levels.RemoveAt(i);
                    i--;
                }
            }
            //checks the closest levels
            //the level below the screen
            int highestLevelIndex = _levels.Max(tuple => tuple.Item1);
            //Debug.Log(highestLevelIndex+1 + " " + Mathf.Abs(contentTop - (highestLevelIndex + 1) * 500));
            if (Mathf.Abs(contentTop - (highestLevelIndex + 1) * 500) < maxLevelsDistance
                && highestLevelIndex + 1 < _levelsNumber)
            {
                SpawnLevel(highestLevelIndex + 1);
            }
            //the level above the screen
            int lowestLevelIndex = _levels.Min(tuple => tuple.Item1);
            //Debug.Log(lowestLevelIndex-1 + " " + Mathf.Abs(contentTop - (lowestLevelIndex + 1) * 500));
            if (Mathf.Abs(contentTop - (lowestLevelIndex - 1) * 500) < maxLevelsDistance
                && lowestLevelIndex - 1 >= 0 && lowestLevelIndex < _levelsNumber)
            {
                SpawnLevel(lowestLevelIndex - 1);
            }
        }
    }
}