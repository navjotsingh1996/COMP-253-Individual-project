﻿namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;

    public class Lights : MonoBehaviour
    {
        public GameObject Light;
        public enum switchState { ON, OFF };
        public switchState ss;

        private VRTK_Button_UnityEvents buttonEvents;

        private void Start()
        {
            buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
            if (buttonEvents == null)
            {
                buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
            }
            buttonEvents.OnPushed.AddListener(handlePush);
        }

        private void handlePush(object sender, Control3DEventArgs e)
        {
            VRTK_Logger.Info("Pushed");
            Light.SetActive(ss == switchState.ON);
        }
    }
}