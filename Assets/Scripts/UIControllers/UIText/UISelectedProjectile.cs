using Managers;

namespace UIControllers.UIText
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