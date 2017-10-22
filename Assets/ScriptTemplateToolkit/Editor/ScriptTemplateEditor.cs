/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  ScriptTemplateEditor.cs
 *  Description  :  Editor for script template.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/31/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Developer.ScriptTemplateToolkit
{
    public class ScriptTemplateEditor : EditorWindow
    {
        #region Property and Field
        private static ScriptTemplateEditor instance;
        private const float buttonWidth = 60;
        private const float scrollViewHeight = 95;
        private Vector2 scrollPosition = Vector2.zero;

        private string templatesDirectory { get { return EditorApplication.applicationContentsPath + "/Resources/ScriptTemplates"; } }
        private string[] templateFiles = { string.Empty };
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
            if (GUILayout.Button("Save", GUILayout.Width(buttonWidth)))
                SaveScriptTemplate();
            EditorGUILayout.EndHorizontal();

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            templateText = EditorGUILayout.TextArea(templateText, GUILayout.ExpandHeight(true));
            EditorGUILayout.EndScrollView();

            EditorGUILayout.EndVertical();
        }

        private void FindScriptTemplateFiles()
        {
            try
            {
                var searchFiles = Directory.GetFiles(templatesDirectory, "*.txt", SearchOption.AllDirectories);
                templateFiles = new string[searchFiles.Length];
                for (int i = 0; i < templateFiles.Length; i++)
                {
                    templateFiles[i] = Path.GetFileNameWithoutExtension(searchFiles[i]);
                }
            }
            catch (Exception e)
            {
                ShowNotification(new GUIContent(e.Message));
            }
        }

        private void ReadScriptTemplateText()
        {
            try
            {
                templateText = File.ReadAllText(GetScriptTemplatePath(), Encoding.Default);
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
                File.WriteAllText(GetScriptTemplatePath(), templateText, Encoding.Default);
                ShowNotification(new GUIContent("The script template was saved successfully!"));
            }
            catch (Exception e)
            {
                ShowNotification(new GUIContent(e.Message));
            }
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