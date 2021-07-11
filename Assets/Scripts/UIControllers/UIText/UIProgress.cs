using System;
using Controllers;
using UIControllers.UIText;
using UnityEngine;
using TMP_Text = TMPro.TMP_Text;

namespace UIControllers
{
    public class UIProgress : UITextBehaviour
    {
        private ProgressController _progressController;
        private void Start()
        {
            _progressController = FindObjectOfType<ProgressController>();
            _progressController.OnIncreasedProgress += UpdateEditableText;
        }

        private void OnDestroy()
        {
            _progressController.OnIncreasedProgress -= UpdateEditableText;
        }

        public override void UpdateEditableText<T>(T value)
        {
            EditableText.text = $"Progress: %{value}";
        }
    }
}
