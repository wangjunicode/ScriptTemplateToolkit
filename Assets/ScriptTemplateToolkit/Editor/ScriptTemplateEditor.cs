/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ScriptTemplateEditor.cs
 *  Description  :  Editor for script template.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/12/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Developer.ScriptTemplateToolkit
{
    public class ScriptTemplateEditor : EditorWindow
    {
        #region Field and Property
        private static ScriptTemplateEditor instance;
        private const float ButtonWidth = 60;
        private const float ScrollViewHeight = 95;
        private Vector2 scrollPosition = Vector2.zero;

        private readonly string templatesDirectory = EditorApplication.applicationContentsPath + "/Resources/ScriptTemplates";
        private string[] templateFiles = { };
        private string templateText = string.Empty;
        private int templateIndex = 0;
        #endregion

        #region Private Method
        [MenuItem("Tool/Script Template Editor &S")]
        private static void ShowEditor()
        {
            instance = GetWindow<ScriptTemplateEditor>("Template");
            instance.Show();
        }

        private void OnEnable()
        {
            FindScriptTemplateFiles();
            ReadScriptTemplateText();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical("Window");

            EditorGUI.BeginChangeCheck();
            templateIndex = EditorGUILayout.Popup("Type", templateIndex, templateFiles);
            if (EditorGUI.EndChangeCheck())
            {
                RevertScrollPosition();
                ReadScriptTemplateText();
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Text");
            EditorGUILayout.Space();
            if (GUILayout.Button("Save", GUILayout.Width(ButtonWidth)))
                SaveScriptTemplate();
            EditorGUILayout.EndHorizontal();

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            templateText = EditorGUILayout.TextArea(templateText, GUILayout.ExpandHeight(true));
            EditorGUILayout.EndScrollView();

            EditorGUILayout.EndVertical();
        }

        private void FindScriptTemplateFiles()
        {
            var searchFiles = new string[] { };
            try
            {
                searchFiles = Directory.GetFiles(templatesDirectory, "*.txt", SearchOption.AllDirectories);
            }
            catch (Exception e)
            {
                ShowNotification(new GUIContent(e.Message));
                return;
            }

            templateFiles = new string[searchFiles.Length];
            for (int i = 0; i < templateFiles.Length; i++)
            {
                templateFiles[i] = Path.GetFileNameWithoutExtension(searchFiles[i]);
            }
        }

        private void ReadScriptTemplateText()
        {
            try
            {
                templateText = File.ReadAllText(GetScriptTemplatePath());
            }
            catch (Exception e)
            {
                templateText = string.Empty;
                ShowNotification(new GUIContent(e.Message));
            }
        }

        private void SaveScriptTemplate()
        {
            try
            {
                File.WriteAllText(GetScriptTemplatePath(), templateText);
            }
            catch (Exception e)
            {
                ShowNotification(new GUIContent(e.Message));
                return;
            }

            ShowNotification(new GUIContent("The script template is saved!"));
        }

        private string GetScriptTemplatePath()
        {
            return templatesDirectory + "/" + templateFiles[templateIndex] + ".txt";
        }

        private void RevertScrollPosition()
        {
            scrollPosition = Vector2.zero;
        }
        #endregion
    }
}