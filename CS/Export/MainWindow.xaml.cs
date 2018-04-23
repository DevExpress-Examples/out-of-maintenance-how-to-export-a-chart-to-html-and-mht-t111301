using System.Diagnostics;
using System.IO;
using System.Windows;
using DevExpress.Xpf.Charts;
using DevExpress.XtraPrinting;

namespace Export {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void ExportChartToHTML(ChartControl chart) {

            // Create an object containing HTML export options.
            HtmlExportOptions htmlOptions = new HtmlExportOptions();

            // Set HTML-specific export options.
            htmlOptions.CharacterSet = "utf-8";
            htmlOptions.RemoveSecondarySymbols = false;
            htmlOptions.Title = "Unicode UTF-8 Example";

            // Specify print size mode.
            PrintSizeMode sizeMode = PrintSizeMode.Stretch;

            // Export a chart to an HTML file.
            chart.ExportToHtml("OutputUnicode.html", htmlOptions, sizeMode);
            Process.Start("OutputUnicode.html");
        }

        private void ExportChartToMHT(ChartControl chart) {

            // Create an object containing MHT export options.
            MhtExportOptions mhtOptions = new MhtExportOptions();

            // Specify print size mode.
            PrintSizeMode sizeMode = PrintSizeMode.ProportionalZoom;

            // Export a chart to a stream as MHT.
            FileStream mhtStream = new FileStream("OutputDefault.mht", FileMode.Create);
            chart.ExportToMht(mhtStream, mhtOptions, sizeMode);
            Process.Start("OutputDefault.mht");
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            ExportChartToHTML(chartControl);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            ExportChartToMHT(chartControl);
        }
    }
}
