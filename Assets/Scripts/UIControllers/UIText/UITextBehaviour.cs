using UnityEngine;
using TMP_Text = TMPro.TMP_Text;

namespace UIControllers.UIText
{
    public abstract class UITextBehaviour : MonoBehaviour
    {
        [SerializeField] protected TMP_Text EditableText;
        public abstract void UpdateEditableText<T>(T value);
    }
}