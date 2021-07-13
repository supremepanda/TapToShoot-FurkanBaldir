using UnityEditor;
using UnityEngine;

namespace UIControllers.UIButton
{
    public class QuitButton : MonoBehaviour, IButtonBehaviour 
    {
        public void OnClickButton()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();  
#endif
            Application.Quit();
        }
    }
}