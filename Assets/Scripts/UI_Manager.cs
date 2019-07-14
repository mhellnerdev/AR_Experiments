using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace AR.UI
{

    public class UI_Manager : MonoBehaviour
    {

        #region Variables
        [Header("System Events")]
        public UnityEvent onSwitchedScreen = new UnityEvent();

        public Component[] screens = new Component[0];

        private UI_Screen previousScreen;
        public UI_Screen PreviousScreen{get{return previousScreen;}}

        private UI_Screen currentScreen;
        public UI_Screen CurrentScreen{get{return currentScreen;}}
        
        #endregion



        #region Main Methods

        // Start is called before the first frame update
        void Start()
        {
            screens = GetComponentsInChildren<UI_Screen>(true);
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion


        #region Helper Methods

        public void SwitchScreens(UI_Screen aScreen)
        {
            if (aScreen)
            {
                if (currentScreen)
                {
//                    currentScreen.Close();
                    previousScreen = currentScreen;

                }

                currentScreen = aScreen;
                currentScreen.gameObject.SetActive(true);
//                currentScreen.StartScreen();

                if (onSwitchedScreen != null)
                {
                    onSwitchedScreen.Invoke();
                }

            }
        }

        public void GoToPreviousScreen()
        {
            if (previousScreen)
            {
                SwitchScreens(previousScreen);
            }
        }

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(WaitToLoadScene(sceneIndex));
        }

        IEnumerator WaitToLoadScene(int sceneIndex)
        {
            yield return null;
        }

        
        #endregion

    }

}
