
With the current implementation, our RichEditControl component copies each table cell as a separate paragraph into the Clipboard in the Text format. You can change this behavior by replacing the default [CopySelectionCommand](https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditCommandsCopySelectionCommandtopic) command with a custom one. 

See the **ExecuteCore** method implementation of the CustomCopySelectionCommand class in this example. In this method text obtained for the OfficeDataFormats.UnicodeText format is postprocessed to separate cell content with Tab symbols.

See also: [E3665: How to customize copy and paste commands](https://isc.devexpress.com/Thread/WorkplaceDetails/E3665) 
