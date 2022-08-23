using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Win32;
using System.Net;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Net.Http;
using Ocelot.Infrastructure;

namespace Upload_videos_demoApp

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string root_address;
        private long file_size;
        public MainWindow()
        {
            InitializeComponent();
        }

        void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            this.root_address = httpAddress.Text;
            if (e.Key == Key.Return)
            {
                textBlock1.Text = "Your file will be sent to: " + this.root_address + "uploadfiles";
            }
        }
        void UploadComplete(Object sender, UploadFileCompletedEventArgs e)
        {
           


            if (e.Cancelled==false & e.Error == null)
            {
                txtEditor.SelectionStart = 0;
                txtEditor.SelectedText = "Upload video successfully!" + "\n" + txtEditor.Text;
            }
            

        }
        long bytesSent;
        long byteSentPercent;
        void UploadPartDone(object sender, UploadProgressChangedEventArgs e)
        {
            FileInfo fi = new FileInfo(filePath.Text);
            if (fi.Exists)
            {
                this.file_size = fi.Length;
            }
            bytesSent = e.BytesSent;

            byteSentPercent = 100 * bytesSent / this.file_size;

            uploadProgress.Value = (int)e.ProgressPercentage;
            Console.WriteLine("Upload {0}%,{1} complete. ", e.ProgressPercentage, byteSentPercent);

        }
        void UploadFileInBackground2(string address, string fileName)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri(address);
            

            // Notify when upload process done
            client.UploadFileCompleted += new UploadFileCompletedEventHandler(UploadComplete);
            // Specify a progress notification handler.
            client.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadPartDone);
            // send request with POST method
            client.UploadFileAsync(uri, "POST", fileName);
            // can perform other tasks while waiting for the upload to complete.
            
            txtEditor.SelectionStart = 0;
            txtEditor.SelectedText = "File upload started.\n" + txtEditor.Text;
        }
        void SubmitVideoButton(object sender, RoutedEventArgs e)
        { 
            String  address = this.root_address+ "uploadfiles";
            Uri uriAddress = new Uri(address);
            string fileName = filePath.Text;
            System.Threading.AutoResetEvent waiter = new System.Threading.AutoResetEvent(false);

            UploadFileInBackground2(address, fileName);
            //waiter.WaitOne();
        }
        // Decode and display the response.

        


        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        //check whether have enough free space on server to upload file
        async Task checkStorage()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(this.root_address+"disk_usage");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                string[] arr = responseBody.Split(',');
                long free_space = long.Parse(arr[2].Replace("]", ""));
                // get size of video file
                FileInfo fi = new FileInfo(filePath.Text); 
                this.file_size = fi.Length;
                
                if (free_space < this.file_size)
                {
                    txtEditor.SelectionStart = 0;
                    txtEditor.SelectedText = "Does not enough free space on server" + "\n" + txtEditor.Text;
                }
                else 
                {
                    txtEditor.SelectionStart = 0;
                    txtEditor.SelectedText = "Ready to submit" + "\n" + txtEditor.Text;
                }
            }
            catch (HttpRequestException e)
            { 
                txtEditor.SelectionStart = 0;
                txtEditor.SelectedText = "Exception Caught!\n - Message : " + e.Message + txtEditor.Text+"\n";
            }
        }


        void OpenFileDialogForm(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video files (*.mp4,*.avi,*.mkv)|*.mp4,*.avi,*.mkv|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
                filePath.Text = openFileDialog.FileName;
                btnOpenFile_Click.Content = "Replace";
                
            uploadProgress.Value = 0;
            checkStorage();
        }

        







        private void checkNull(object sender, RoutedEventArgs e) 
        {
            if (filePath == null)
                btnOpenFile_Click.Content = "Choose file";
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }



}
