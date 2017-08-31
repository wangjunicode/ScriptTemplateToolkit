/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: ScriptTemplateModifier.cs
 *  Author: Mogoson   Version: 1.0   Date: 8/31/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.    ScriptTemplateModifier        Ignore.
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
    using System.Text.RegularExpressions;
    using UnityEditor;

    public class ScriptTemplateModifier : AssetModificationProcessor
    {
        #region Property and Field
        private const string extensions = ".cs|.js|.shader|.compute";
        #endregion

        #region Private Method
        private static void OnWillCreateAsset(string metaPath)
        {
            var assetPath = metaPath.Replace(".meta", string.Empty);
            if (Regex.IsMatch(Path.GetExtension(assetPath), extensions))
            {
                var content = File.ReadAllText(assetPath);
                content = content.Replace("#COPYRIGHTTIME#", DateTime.Now.Year + "-" + (DateTime.Now.Year + 1));
                content = content.Replace("#CREATETIME#", DateTime.Now.ToShortDateString());
                File.WriteAllText(assetPath, content);
                AssetDatabase.Refresh();
            }
        }
        #endregion
    }
}