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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AxBarcodeReaderLib.AxBarcodeDecoder barcodeDecoder;
        System.Windows.Forms.Integration.WindowsFormsHost host;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create the interop host control.
            host = new System.Windows.Forms.Integration.WindowsFormsHost();

            //host.
            host.Width = 320;
            host.Height = 240;

            // Create the ActiveX control.
            barcodeDecoder = new AxBarcodeReaderLib.AxBarcodeDecoder();

            // Assign the ActiveX control as the host control's child.
            host.Child = barcodeDecoder;

            // Add the interop host control to the Grid control's collection of child controls. 
            this.grid1.Children.Add(host);

            // sets barcode types
            barcodeDecoder.BarcodeTypes |= 0x40000000;  //add QRCode decoding
            barcodeDecoder.SetProperty("LinearVerify", true);
            barcodeDecoder.ShowImage = true;

            //barcodeDecoder.DecodeFile("c:\\1\\1.jpg");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AxBarcodeReaderLib._IReaderEvents_BarcodeInEventHandler barcodeIn = new AxBarcodeReaderLib._IReaderEvents_BarcodeInEventHandler(OnBarcodeIn);
            barcodeDecoder.BarcodeIn += barcodeIn;

            barcodeDecoder.VideoStart(0, 0, 0);
        }

        void OnBarcodeIn(object sender, AxBarcodeReaderLib._IReaderEvents_BarcodeInEvent e)
        {
            this.label1.Content = e.barcode;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            barcodeDecoder.VideoStop();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            barcodeDecoder.AboutBox();
        }
    }
}
