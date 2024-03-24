using Laphed.ScenariosUI.SingleActions;
using UnityEngine;
using UnityEngine.UI;

namespace Laphed.ScenariosUI.Menus.Mono
{
    public class ButtonClickRegistrator
        : MonoBehaviour,
          IResettableCondition
    {
        public bool IsMet { get; private set; }

        [SerializeField] private Button button;

        private void Awake()
        {
            button.onClick.AddListener(OnClick);
        }

        public void Reset()
        {
            IsMet = false;
        }

        private void OnClick()
        {
            IsMet = true;
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnClick);
        }
    }
}
