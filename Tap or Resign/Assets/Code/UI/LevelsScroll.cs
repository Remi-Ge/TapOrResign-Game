using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.UI
{
    public class LevelsScroll : MonoBehaviour
    {
        [SerializeField] private RectTransform scrollRectContent;
        [SerializeField] private GameObject levelPrefab;
        private int _levelNumber;
        private readonly List<Tuple<int, RectTransform>> _levels = new List<Tuple<int, RectTransform>>(); //the spawned levels

        private void Start()
        {
            SetScrollAreaSize(10);
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
            RectTransform levelRectTransform = newLevel.GetComponent<RectTransform>(); 
            levelRectTransform.anchoredPosition = 
                new Vector2(0, 500 * (_levelNumber - 1) / 2f + -500 * levelIndex);
            _levels.Add(new Tuple<int, RectTransform>(levelIndex, levelRectTransform));
        }

        public void ScrollRectMoved()
        {
            float contentTop = scrollRectContent.offsetMax.y;
            //checks if the levels are too far
            for (int i = 0; i < _levels.Count; i++)
            {
                if (Mathf.Abs(contentTop - 500 * _levels[i].Item1) > 3000)
                {
                    Destroy(_levels[i].Item2.gameObject);
                    _levels.RemoveAt(i);
                    i--;
                }
            }
            //rect top value x -1 to have the position of the screen
        }
    }
}