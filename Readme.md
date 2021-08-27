<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/163182759/18.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830486)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to copy a table from the RichEditControl document to the Clipboard in the UnicodeText format

With the current implementation, our RichEditControl component copies each table cell as a separate paragraph into the Clipboard in the Text format. As a result, the tabular structure of the copied content is lost when you paste it into a Notepad or Microsoft Office Excel document. 
You can change this behavior by replacing the default [CopySelectionCommand](https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditCommandsCopySelectionCommandtopic) command with a custom one.

See the **ExecuteCore** method implementation of the CustomCopySelectionCommand class in this example. In this method text obtained for the OfficeDataFormats.UnicodeText format is postprocessed to separate cell content with Tab symbols.

See also: [E3665: How to customize copy and paste commands](https://www.devexpress.com/Support/Center/Example/Details/E3665/how-to-customize-copy-and-paste-commands) 
