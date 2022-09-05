using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Windows;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using TheArtOfDev.HtmlRenderer.WPF;

namespace HtmlConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static PageSize[] s_pdfPageSizes;

        static MainWindow()
        {
            s_pdfPageSizes = Enum.GetValues(typeof(PageSize)).Cast<PageSize>().ToArray();

            
        }


        private bool _isPageSizesLoaded = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializePdfComponent();


          
        }

        private void InitializePdfComponent()
        {

            // ===========================================================
            // PDF 콤보박스 초기화
            // ===========================================================
            Task.Run(() =>
            {
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    foreach (var pageSize in s_pdfPageSizes)
                        _pdfPageSizeComboBox.Items.Add(pageSize);

                    if (!SelectFontFamily(PageSize.A4))
                        _pdfPageSizeComboBox.SelectedIndex = -1;

                    _isPageSizesLoaded = true;
                }));
            });
        }

        private bool SelectFontFamily(PageSize pageSize)
        {
            bool selectSuccess = false;

            for (int i = 0; i < _pdfPageSizeComboBox.Items.Count; i++)
            {
                PageSize pageSizeItem = (PageSize)_pdfPageSizeComboBox.Items[i];


                if (pageSizeItem == pageSize)
                {
                    _pdfPageSizeComboBox.SelectedIndex = i;
                    selectSuccess = true;
                    break;
                }
            }

            return selectSuccess;
        }

        private void _header_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Opacity = 0.3;
                DragMove();
                Opacity = 1.0;
            }
        }

        private void _minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void _maximizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void _closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NumberTextBox_PreviewInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "[0-9]+");
        }

        private void _savePDFBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //HtmlRender.Render()

            //PdfDocument pdf = PdfGenerator.GeneratePdf("<p><h1>Hello World</h1>This is html rendered text</p>", PageSize.A1);
            //pdf.Save("document.pdf");

            //PdfPage pdfp = pdf.Pages[0];
            ///XGraphics xgfx = XGraphics.FromPdfPage(pdfp);
            //Bitmap b = new Bitmap((int)pdfp.Width.Point, (int)pdfp.Height.Point, xgfx.);
            //MemoryStream strm = new MemoryStream();
            //img.Save(strm, System.Drawing.Imaging.ImageFormat.Png);
            //new XGraphics()


            //XImage xfoto = XImage.FromStream(strm);
            //XGraphics.
        }

        private void _saveImageBtn_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void _savePDFBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

