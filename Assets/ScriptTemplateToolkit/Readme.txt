==========================================================================
  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
  Name: ScriptTemplateToolkit
  Author: Mogoson   Version: 0.1.0   Date: 8/31/2017
==========================================================================
  [Summary]
    Unity plugin for script template.
--------------------------------------------------------------------------
  [Demand]
    Quickly edit Unity engine script template and auto add file header
    comments to the new script file when it is created in Unity editor.
--------------------------------------------------------------------------
  [Environment]
    Unity 5.0 or above.
    .Net Framework 3.0 or above.
--------------------------------------------------------------------------
  [Achieve]
    ScriptTemplateEditor : Draw editor window, Read/Edit/Save Unity
    engine script template file.

    ScriptTemplateModifier : Capture the event of create script file
    in Unity editor, and replace the [Mark] to corresponding content.
--------------------------------------------------------------------------
  [Usage]
    Find the menu item "Tool/Script Template Editor" in Unity editor menu
    bar and click it or press key combination Alt+S to open the editor
    window.

    Select "EditTarget"(example CSharp Behaviour) to browse current script
    template.

    Open the corresponding [Template] and copy the text to "ScriptTemplate"
    text edit area and click the "Save" button.

    "ScriptTemplateModifier" will be work when a script(example C# Script)
    is created in Unity editor.
--------------------------------------------------------------------------
  [Template]
    Templates(example CsharpBehaviour.txt) in the path
    "ScriptTemplateToolkit/Templates" provide reference to you.

    In fact, you can use the [Mark] to create your style script template.
--------------------------------------------------------------------------
  [Mark]
    #SCRIPTNAME#, #COPYRIGHTTIME#, #CREATETIME#.
--------------------------------------------------------------------------
  [Resource]
    https://github.com/mogoson/ScriptTemplateToolkit.
--------------------------------------------------------------------------
  [Contact]
    If you have any questions, feel free to contact me at mogoson@qq.com.
--------------------------------------------------------------------------