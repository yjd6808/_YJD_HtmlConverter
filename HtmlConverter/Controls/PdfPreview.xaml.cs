using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

using PdfSharp.Windows;
using PdfSharp.Drawing;

namespace HtmlConverter
{
    public partial class PdfPreview : UserControl
    {
        public PdfPreview()
        {
            InitializeComponent();

            //TextBlock tb = new TextBlock(); 
            //Binding b = new Binding("FontSize"); 
            //b.Source = this; 
            //tb.SetBinding(TextBlock.FontSizeProperty, b);

            //_canvasGrid.SetBinding(WidthProperty, new Binding("CanvasWidth"));
            //_canvasGrid.SetBinding(HeightProperty, new Binding("CanvasHeight"));
            //_canvas.SetBinding(WidthProperty, new Binding("CanvasWidth"));
            //_canvas.SetBinding(HeightProperty, new Binding("CanvasHeight"));

            _layoutRoot.DataContext = this;
            Zoom = (Zoom)100;
        }

        void Test()
        {
            double factor = 1;
            int zoom = (int)Zoom;
            if (zoom > 0)
                factor = Math.Max(Math.Min(zoom, 800), 10) / 100.0;
            else
                factor = 1;

            _canvasGrid.Width = 480 * factor;
            _canvasGrid.Height = 640 * factor;
            _scaleTransform.ScaleX = factor;
            _scaleTransform.ScaleY = factor;

            //CanvasWidth = 480 * factor;
            //CanvasHeight = 640 * factor;
            //CanvasScaleX = 1 * factor;
            //CanvasScaleY = 1 * factor;
        }

        /// <summary>
        /// Gets the _canvas.
        /// </summary>
        public Canvas Canvas
        {
            get { return _canvas; }
        }

        /// <summary>
        /// Sets the render function.
        /// </summary>
        public void SetRenderFunction(Action<XGraphics> renderFunction)
        {
            if (_canvas.Children.Count > 0)
                _canvas.Children.Clear();


            XGraphics gfx = XGraphics.FromCanvas(_canvas, new XSize(100, 100), XGraphicsUnit.Presentation);
            renderFunction(gfx);
            gfx.Dispose();  // necessary in WPF
        }

        /// <summary>
        /// Gets or sets the size of the page 1/96 inch.
        /// </summary>
        public Size PageSize
        {
            get { return (Size)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the XGraphicsUnit of the page.
        /// The default value is XGraphicsUnit.Point.
        /// </summary>
        public XGraphicsUnit PageGraphicsUnit
        {
            get { return _pageGraphicsUnit; }
            set { _pageGraphicsUnit = value; }
        }
        XGraphicsUnit _pageGraphicsUnit = XGraphicsUnit.Point;


        /// <summary>
        /// DependencyProperty of PageSize.
        /// </summary>
        public readonly DependencyProperty PageSizeProperty =
          DependencyProperty.Register("PageSize", typeof(Size), typeof(PagePreview), new PropertyMetadata(new Size(480, 640), PageSizeChanged));

        private static void PageSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PdfPreview)d).Test();
        }

        /// <summary>
        /// Gets or sets the zoom.
        /// </summary>
        public Zoom Zoom
        {
            get { return (Zoom)GetValue(ZoomProperty); }
            set { SetValue(ZoomProperty, value); }
        }

        /// <summary>
        /// DependencyProperty of Zoom.
        /// </summary>
        public readonly DependencyProperty ZoomProperty =
          DependencyProperty.Register("Zoom", typeof(Zoom), typeof(PagePreview), new PropertyMetadata(Zoom.FullPage, ZoomChanged));

        private static void ZoomChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PdfPreview)d).Test();
        }

#if true
        public double CanvasWidth
        {
            get { return (double)GetValue(CanvasWidthProperty); }
            set { SetValue(CanvasWidthProperty, value); }
        }
        public readonly DependencyProperty CanvasWidthProperty =
          DependencyProperty.Register("CanvasWidth", typeof(double), typeof(PagePreview), new PropertyMetadata(210.0));

        public double CanvasHeight
        {
            get { return (double)GetValue(CanvasHeightProperty); }
            set { SetValue(CanvasHeightProperty, value); }
        }
        public readonly DependencyProperty CanvasHeightProperty =
          DependencyProperty.Register("CanvasHeight", typeof(double), typeof(PagePreview), new PropertyMetadata(297.0));

        public double CanvasScaleX
        {
            get { return (double)GetValue(CanvasScaleXProperty); }
            set { SetValue(CanvasScaleXProperty, value); }
        }
        public readonly DependencyProperty CanvasScaleXProperty =
          DependencyProperty.Register("CanvasScaleX", typeof(double), typeof(PagePreview), new PropertyMetadata(1.0));

        public double CanvasScaleY
        {
            get { return (double)GetValue(CanvasScaleYProperty); }
            set { SetValue(CanvasScaleYProperty, value); }
        }
        public readonly DependencyProperty CanvasScaleYProperty =
          DependencyProperty.Register("CanvasScaleY", typeof(double), typeof(PagePreview), new PropertyMetadata(1.0));
#endif

        /// <summary>
        /// Gets or sets the page visibility.
        /// </summary>
        public Visibility PageVisibility
        {
            get { return (Visibility)GetValue(PageVisibilityProperty); }
            set { SetValue(PageVisibilityProperty, value); }
        }

        /// <summary>
        /// DependencyProperty of PageVisibility.
        /// </summary>
        public readonly DependencyProperty PageVisibilityProperty =
          DependencyProperty.Register("PageVisibility", typeof(Visibility), typeof(PagePreview), null);
    }
}
