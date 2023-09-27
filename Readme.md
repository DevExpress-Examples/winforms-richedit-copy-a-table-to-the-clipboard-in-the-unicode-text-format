<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/163182759/18.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830486)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Rich Text Editor for WinForms - How to Copy a Table to the Clipboard in the UnicodeText Format

With the current implementation, our RichEditControl component copies each table cell as a separate paragraph into the Clipboard in the Text format. As a result, the tabular structure of the copied content is lost when you paste it into a Notepad or Microsoft Office Excel document. 
You can replace the default [CopySelectionCommand](https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditCommandsCopySelectionCommandtopic) command with a custom command to change this behavior. See the `ExecuteCore` method implementation of the `CustomCopySelectionCommand` class in this example. In this method, text is obtained for the OfficeDataFormats.UnicodeText format is postprocessed to separate cell content with Tab symbols.

## Files to Review

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [CustomCopySelectionCommand.cs](./CS/CustomCopySelectionCommand.cs) (VB:[CustomCopySelectionCommand.vb](./VB/CustomCopySelectionCommand.vb))

## More Examples

* [How to: Customize Copy and Paste Commands](https://github.com/DevExpress-Examples/how-to-customize-copy-and-paste-commands)

## Documentation

* [Commands in Rich Text Editor](https://docs.devexpress.com/WindowsForms/9328/controls-and-libraries/rich-text-editor/commands)
