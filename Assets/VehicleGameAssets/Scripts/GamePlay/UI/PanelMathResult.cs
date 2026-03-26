using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VehicleGame.Gameplay.UI
{
    public class PanelMathResult : MonoBehaviour
    {
        public enum MatchResult
        {
            Win, Lose
        }
        [Header("Animation")]
        public float duration = 0.3f;
        public Ease ease = Ease.OutBack;
        
        [Header("Components")]
        [SerializeField] private TMP_Text textResult;
        [SerializeField] private Transform panelWinLose;

        private void Awake()
        {
            panelWinLose.localScale = Vector3.zero;
        }

        /// <summary>
        /// Плавное появление панели
        /// </summary>Show result match
        /// <param name="onComplete"></param>
        public void Show(MatchResult matchResult, System.Action onComplete = null)
        {
            gameObject.SetActive(true);
            textResult.text = matchResult.ToString();

            panelWinLose.DOKill();
            panelWinLose.localScale = Vector3.zero;

            panelWinLose.DOScale(0.6f, duration)
                .SetEase(ease)
                .OnComplete(() =>
                {

                    onComplete?.Invoke();
                });

        }

        #region Events
        public void OnBtnRestartClick()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void OnBtnExitClick()
        {
            Application.Quit();
        }

        #endregion
    }

}