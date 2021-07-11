using System;
using Managers;
using UIControllers.UIText;
using UnityEngine;
using TMP_Text = TMPro.TMP_Text;

namespace UIControllers
{
    public class UISelectedProjectile : UITextBehaviour
    {
        private ProjectileSelectionManager _projectileSelectionManager;
        private void Start()
        {
            _projectileSelectionManager = FindObjectOfType<ProjectileSelectionManager>();
            _projectileSelectionManager.OnSelectedProjectile += UpdateEditableText;
        }

        private void OnDestroy()
        {
            _projectileSelectionManager.OnSelectedProjectile -= UpdateEditableText;

        }

        public override void UpdateEditableText<T>(T value)
        {
            EditableText.text = $"Selected: {value.ToString()}";
        }
    }
}