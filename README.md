# DS_BarcodeReader_WPF_1
Microsoft WPF (Windows Presentation Foundation) Application to Decode barcodes from live web camera

1. Add a reference to the generated ActiveX interoperability assembly placed in interop folder (interop/AxInterop.BarcodeReaderLib.dll).

2. Add a reference to the WindowsFormsIntegration assembly, which is named WindowsFormsIntegration.dll. 

3. Add a reference to the Windows Forms assembly, which is named System.Windows.Forms.dll.

4. Open MainWindow.xaml in the WPF Designer.

5. Name the Grid element grid1. 
  <Grid Name="grid1">

  </Grid>

6. In Design view or XAML view, select the Window element.

7. In the Properties window, click the Events tab.

8. Double-click the Loaded event.

9. Insert the following code to handle the Loaded event.
This code creates an instance of the WindowsFormsHost control and adds an instance of the AxBarcodeReader control as its child.

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



http://msdn.microsoft.com/en-us/library/ms742735%28v=vs.110%29.aspx

