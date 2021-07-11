using UnityEditor;

namespace UIControllers.UIButton
{
    public class QuitButton : UIButtonBehaviour 
    {
        public override void OnClickButton()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}