Imports System.Diagnostics
Imports System.IO
Imports System.Windows
Imports DevExpress.Xpf.Charts
Imports DevExpress.XtraPrinting

Namespace Export

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub ExportChartToHTML(ByVal chart As ChartControl)
            ' Create an object containing HTML export options.
            Dim htmlOptions As HtmlExportOptions = New HtmlExportOptions()
            ' Set HTML-specific export options.
            htmlOptions.CharacterSet = "utf-8"
            htmlOptions.RemoveSecondarySymbols = False
            htmlOptions.Title = "Unicode UTF-8 Example"
            ' Specify print size mode.
            Dim sizeMode As PrintSizeMode = PrintSizeMode.Stretch
            ' Export a chart to an HTML file.
            chart.ExportToHtml("OutputUnicode.html", htmlOptions, sizeMode)
            Call Process.Start("OutputUnicode.html")
        End Sub

        Private Sub ExportChartToMHT(ByVal chart As ChartControl)
            ' Create an object containing MHT export options.
            Dim mhtOptions As MhtExportOptions = New MhtExportOptions()
            ' Specify print size mode.
            Dim sizeMode As PrintSizeMode = PrintSizeMode.ProportionalZoom
            ' Export a chart to a stream as MHT.
            Dim mhtStream As FileStream = New FileStream("OutputDefault.mht", FileMode.Create)
            chart.ExportToMht(mhtStream, mhtOptions, sizeMode)
            Call Process.Start("OutputDefault.mht")
        End Sub

        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.ExportChartToHTML(Me.chartControl)
        End Sub

        Private Sub Button_Click_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.ExportChartToMHT(Me.chartControl)
        End Sub
    End Class
End Namespace
