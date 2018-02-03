==========================================================================
  Copyright 2017-2018 Mogoson All rights reserved.
  Name: ScriptTemplateToolkit
  Author: Mogoson   Version: 0.1.0   Date: 2/3/2018
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

    Select "Type"(example C# Script) to load the script template text to
    the "Text" area.

    Reference the [Template], edit the script template to apply your
    style in the "Text" area and click the "Save" button.

    ScriptTemplateModifier will be work when a script(example C# Script)
    is created in Unity editor.
--------------------------------------------------------------------------
  [Template]
    Templates(example C#Script.txt) in the path
    "ScriptTemplateToolkit/Templates" provide reference to you.

    In fact, you can use the [Mark] to create your style script template.
--------------------------------------------------------------------------
  [Mark]
    #SCRIPTNAME#, #COPYRIGHTYEAR#, #CREATEDATE#.
--------------------------------------------------------------------------
  [Resource]
    https://github.com/mogoson/ScriptTemplateToolkit.
--------------------------------------------------------------------------
  [Contact]
    If you have any questions, feel free to contact me at mogoson@qq.com.
--------------------------------------------------------------------------