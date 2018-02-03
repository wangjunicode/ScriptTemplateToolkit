/*************************************************************************
 *  Copyright 2017-2018 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ScriptTemplateModifier.cs
 *  Description  :  Modifier for script template.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/3/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;

namespace Developer.ScriptTemplateToolkit
{
    public class ScriptTemplateModifier : UnityEditor.AssetModificationProcessor
    {
        #region Property and Field
        private const string extensions = ".cs$|.js$|.boo$|.shader$|.compute$";
        #endregion

        #region Private Method
        private static void OnWillCreateAsset(string metaPath)
        {
            var assetPath = metaPath.Replace(".meta", string.Empty);
            if (Regex.IsMatch(Path.GetExtension(assetPath), extensions))
            {
                var content = File.ReadAllText(assetPath);
                content = content.Replace("#COPYRIGHTYEAR#", DateTime.Now.Year.ToString());
                content = content.Replace("#CREATEDATE#", DateTime.Now.ToShortDateString());
                File.WriteAllText(assetPath, content);
                AssetDatabase.Refresh();
            }
        }
        #endregion
    }
}