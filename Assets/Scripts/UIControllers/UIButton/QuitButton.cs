using UnityEditor;
using UnityEngine;

namespace UIControllers.UIButton
{
    public class QuitButton : UIButtonBehaviour 
    {
        public override void OnClickButton()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();  
#endif
            Application.Quit();
        }
    }
}