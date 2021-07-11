using UnityEngine;
using TMP_Text = TMPro.TMP_Text;

namespace UIControllers.UIText
{
    public abstract class UITextBehaviour : MonoBehaviour
    {
        public abstract void UpdateEditableText<T>(T value);
        
        [SerializeField] protected TMP_Text EditableText;
    }
}