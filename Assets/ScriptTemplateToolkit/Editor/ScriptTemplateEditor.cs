/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: ScriptTemplateEditor.cs
 *  Author: Mogoson   Version: 1.0   Date: 8/31/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.      ScriptTemplateEditor        Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     8/31/2017       1.0        Build this file.
 *************************************************************************/

namespace Developer.ScriptTemplateToolkit
{
    using System;
    using System.IO;
    using System.Text;
    using UnityEditor;
    using UnityEngine;

    public class ScriptTemplateEditor : EditorWindow
    {
        #region Enum
        private enum EditTarget
        {
            CsharpBehaviour,
            JavascriptBehaviour,
            StateMachineBehaviour,
            SubStateMachineBehaviour,
            SurfaceShader,
            UnlitShader,
            ImageEffectShader,
            ComputeShader
        }
        #endregion

        #region Property and Field
        private static ScriptTemplateEditor instance;
        private static EditTarget editTarget;

        private Vector2 scrollPosition;
        private string templateText;
        #endregion

        #region Private Method
        [MenuItem("Tool/Script Template Editor &S")]
        private static void ShowEditor()
        {
            instance = GetWindow<ScriptTemplateEditor>("Script Editor");
            instance.Show();
        }

        private void OnEnable()
        {
            ReadScriptTemplateText();
        }

        private void OnGUI()
        {
            EditorGUI.BeginChangeCheck();
            editTarget = (EditTarget)EditorGUILayout.EnumPopup("Edit Target", editTarget);
            if (EditorGUI.EndChangeCheck())
                ReadScriptTemplateText();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Script Template");
            EditorGUILayout.Space();
            if (GUILayout.Button("Save", GUILayout.Width(60)))
                SaveScriptTemplate();
            EditorGUILayout.EndHorizontal();

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            templateText = EditorGUILayout.TextArea(templateText, GUILayout.ExpandHeight(true));
            EditorGUILayout.EndScrollView();
        }

        private void ReadScriptTemplateText()
        {
            try
            {
                templateText = File.ReadAllText(GetScriptTemplatePath(), Encoding.Default);
            }
            catch (Exception e)
            {
                ShowNotification(new GUIContent(e.Message));
                templateText = string.Empty;
            }
        }

        private void SaveScriptTemplate()
        {
            try
            {
                File.WriteAllText(GetScriptTemplatePath(), templateText, Encoding.Default);
                ShowNotification(new GUIContent("Script template was successfully saved!"));
            }
            catch (Exception e)
            {
                ShowNotification(new GUIContent(e.Message));
            }
        }

        private string GetScriptTemplatePath()
        {
            string scriptPath = string.Empty;
            switch (editTarget)
            {
                case EditTarget.CsharpBehaviour:
                    scriptPath = "81-C# Script-NewBehaviourScript.cs";
                    break;
                case EditTarget.JavascriptBehaviour:
                    scriptPath = "82-Javascript-NewBehaviourScript.js";
                    break;
                case EditTarget.StateMachineBehaviour:
                    scriptPath = "86-C# Script-NewStateMachineBehaviourScript.cs";
                    break;
                case EditTarget.SubStateMachineBehaviour:
                    scriptPath = "86-C# Script-NewSubStateMachineBehaviourScript.cs";
                    break;
                case EditTarget.SurfaceShader:
                    scriptPath = "83-Shader__Standard Surface Shader-NewSurfaceShader.shader";
                    break;
                case EditTarget.UnlitShader:
                    scriptPath = "84-Shader__Unlit Shader-NewUnlitShader.shader";
                    break;
                case EditTarget.ImageEffectShader:
                    scriptPath = "85-Shader__Image Effect Shader-NewImageEffectShader.shader";
                    break;
                case EditTarget.ComputeShader:
                    scriptPath = "90-Shader__Compute Shader-NewComputeShader.compute";
                    break;
            }
            return EditorApplication.applicationContentsPath + "/Resources/ScriptTemplates/" + scriptPath + ".txt";
        }
        #endregion
    }
}