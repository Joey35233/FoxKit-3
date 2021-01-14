using System;
using UnityEditor;
using UnityEngine;

namespace Fox.Editor
{
    public static class StringMapDrawerPopup
    {  
        public static String ShowPopup()
        {
            var window = EditorWindow.GetWindow<StringMapDrawerPopupWindow>(true, "Create StringMap Key");
            window.maxSize = new Vector2(250, 70);
            window.minSize = window.maxSize;
            window.ShowModal();

            return window.returnValue;
        }

        private class StringMapDrawerPopupWindow : EditorWindow
        {
            private string _returnValue;
            public String returnValue;

            private bool hasPrefocused = false;

            void OnGUI()
            {
                GUI.SetNextControlName("KeyTextField");
                _returnValue = EditorGUILayout.TextField(_returnValue);
                if (!hasPrefocused)
                {
                    EditorGUI.FocusTextInControl("KeyTextField");
                    hasPrefocused = true;
                }

                EditorGUILayout.BeginHorizontal();

                if (Event.current.keyCode == KeyCode.Return || GUILayout.Button("Ok"))
                {
                    returnValue = new String(_returnValue);
                    this.Close();
                }
                
                if (GUILayout.Button("Cancel"))
                {
                    returnValue = null;
                    this.Close();
                }

                EditorGUILayout.EndHorizontal();
                GUILayout.FlexibleSpace();
            }
        }
    }
}