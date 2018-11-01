using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Touchless.Vision.Camera;
using System.IO;
using Payroll;

namespace Payroll
{
    public partial class CameraFrm : Form
    {

        //private Color _BackColor;
      
        ///// Stores an instance of the originally loaded image

        //private Image _OriginalImage;


        public CameraFrm()
        {
            InitializeComponent();
        }

        //private void InitializeComponent()
        //{
        //    throw new NotImplementedException();
        //}

        //public NewEmployee  MyFirstForm { get; set; }

            private NewEmployee  mainForm = null;
            public CameraFrm(Form callingForm)
                {
                    mainForm = callingForm as NewEmployee; 
                    InitializeComponent();
                }

        private void CameraFrm_Load(object sender, EventArgs e)
        {

            try
            { 
            
                if (!DesignMode)
                {
                    // Refresh the list of available cameras
                    comboBoxCameras.Items.Clear();
                    foreach (Camera cam in CameraService.AvailableCameras)
                        comboBoxCameras.Items.Add(cam);

                    if (comboBoxCameras.Items.Count > 0)
                        comboBoxCameras.SelectedIndex = 0;
                }

                // Early return if we've selected the current camera
                if (_frameSource != null && _frameSource.Camera == comboBoxCameras.SelectedItem)
                    return;

                thrashOldCamera();
                startCapturing();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }


        private void CameraFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            thrashOldCamera();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            thrashOldCamera();
        }

        private CameraFrameSource _frameSource;
        private static Bitmap _latestFrame;

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Early return if we've selected the current camera
            if (_frameSource != null && _frameSource.Camera == comboBoxCameras.SelectedItem)
                return;

            thrashOldCamera();
            startCapturing();
        }

        private void startCapturing()
        {
            try
            {
                Camera c = (Camera)comboBoxCameras.SelectedItem;
                setFrameSource(new CameraFrameSource(c));
                _frameSource.Camera.CaptureWidth = 320;
                _frameSource.Camera.CaptureHeight = 240;
                _frameSource.Camera.Fps = 20;
                _frameSource.NewFrame += OnImageCaptured;

                picCam1.Paint += new PaintEventHandler(drawLatestImage);
                _frameSource.StartFrameCapture();
            }
            catch (Exception ex)
            {
                comboBoxCameras.Text = "Select A Camera";
                MessageBox.Show(ex.Message);
            }
        }

        private void drawLatestImage(object sender, PaintEventArgs e)
        {
            if (_latestFrame != null)
            {
                // Draw the latest image from the active camera
                e.Graphics.DrawImage(_latestFrame, 0, 0, _latestFrame.Width, _latestFrame.Height);
            }
        }

        public void OnImageCaptured(Touchless.Vision.Contracts.IFrameSource frameSource, Touchless.Vision.Contracts.Frame frame, double fps)
        {
             _latestFrame = frame.Image;
             picCam1.Invalidate();
        }

        private void setFrameSource(CameraFrameSource cameraFrameSource)
        {
            if (_frameSource == cameraFrameSource)
                return;
            _frameSource = cameraFrameSource;
        }

        //

        private void thrashOldCamera()
        {
            // Trash the old camera
            if (_frameSource != null)
            {
                _frameSource.NewFrame -= OnImageCaptured;
                _frameSource.Camera.Dispose();
                setFrameSource(null);
                picCam1.Paint -= new PaintEventHandler(drawLatestImage);
            }
        }

        //

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_frameSource == null)
                return;
         
           // MyFirstForm.picCam.Image = picCam1.Image;
            string exePath = Application.StartupPath + "\\Image";
           //Create Directory on application path check if exist
           if (!Directory.Exists(@exePath))
               Directory.CreateDirectory(@exePath);
           
            //Initialize filename

           string Pathfilename = exePath+"\\DateTime.Now" +".bmp";

            //GeLatest frame
            Bitmap current = (Bitmap)_latestFrame.Clone();
            //Save frame to path
            current.Save(Pathfilename);

            //Load picture to person picturebox
            //MyFirstForm.picImage.Image = new Bitmap(Pathfilename);
           // MyFirstForm.picImage.Image = Image.FromFile(Pathfilename);
         //   CameraFrm cam = new CameraFrm();

            using (Stream str = File.OpenRead(Pathfilename))
            {
                Image img = Image.FromStream(str);
                mainForm.picImage.Image = img;
            }
             
            File.Delete(Pathfilename);

            //_OriginalImage = Image.FromFile(Pathfilename);
            //ResizeAndDisplayImage();

           //Dispose 
            current.Dispose();
            this.Close();
          
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            // snap camera
            if (_frameSource != null)
                _frameSource.Camera.ShowPropertiesDialog();
        }

        //private void ResizeAndDisplayImage()
        //{
        //    // Set the backcolor of the pictureboxes
        //    MyFirstForm.picImage.BackColor = _BackColor;
        //  //  MyFirstForm.picZoom.BackColor = _BackColor;

        //    // If _OriginalImage is null, then return. This situation can occur
        //    // when a new backcolor is selected without an image loaded.
        //    if (_OriginalImage == null)
        //        return;

        //    MyFirstForm.picImage.Image = _OriginalImage;
        //    return;
        //    // sourceWidth and sourceHeight store the original image's width and height
        //    // targetWidth and targetHeight are calculated to fit into the picImage picturebox.
        //    int sourceWidth = _OriginalImage.Width;
        //    int sourceHeight = _OriginalImage.Height;
        //    int targetWidth;
        //    int targetHeight;
        //    double ratio;

        //    // Calculate targetWidth and targetHeight, so that the image will fit into
        //    // the picImage picturebox without changing the proportions of the image.
        //    if (sourceWidth > sourceHeight)
        //    {
        //        // Set the new width
        //        targetWidth = MyFirstForm.picImage.Width;
        //        // Calculate the ratio of the new width against the original width
        //        ratio = (double)targetWidth / sourceWidth;
        //        // Calculate a new height that is in proportion with the original image
        //        targetHeight = (int)(ratio * sourceHeight);
        //    }
        //    else if (sourceWidth < sourceHeight)
        //    {
        //        // Set the new height
        //        targetHeight = MyFirstForm.picImage.Height;
        //        // Calculate the ratio of the new height against the original height
        //        ratio = (double)targetHeight / sourceHeight;
        //        // Calculate a new width that is in proportion with the original image
        //        targetWidth = (int)(ratio * sourceWidth);
        //    }
        //    else
        //    {
        //        // In this case, the image is square and resizing is easy
        //        targetHeight = MyFirstForm.picImage.Height;
        //        targetWidth = MyFirstForm.picImage.Width;
        //    }

        //    // Calculate the targetTop and targetLeft values, to center the image
        //    // horizontally or vertically if needed
        //    int targetTop = (MyFirstForm.picImage.Height - targetHeight) / 2;
        //    int targetLeft = (MyFirstForm.picImage.Width - targetWidth) / 2;

        //    // Create a new temporary bitmap to resize the original image
        //    // The size of this bitmap is the size of the picImage picturebox.
        //    Bitmap tempBitmap = new Bitmap(MyFirstForm.picImage.Width, MyFirstForm.picImage.Height, PixelFormat.Format24bppRgb);

        //    // Set the resolution of the bitmap to match the original resolution.
        //    tempBitmap.SetResolution(_OriginalImage.HorizontalResolution, _OriginalImage.VerticalResolution);

        //    // Create a Graphics object to further edit the temporary bitmap
        //    Graphics bmGraphics = Graphics.FromImage(tempBitmap);

        //    // First clear the image with the current backcolor
        //    bmGraphics.Clear(_BackColor);

        //    // Set the interpolationmode since we are resizing an image here
        //    bmGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

        //    // Draw the original image on the temporary bitmap, resizing it using
        //    // the calculated values of targetWidth and targetHeight.
        //    bmGraphics.DrawImage(_OriginalImage,
        //                         new Rectangle(targetLeft, targetTop, targetWidth, targetHeight),
        //                         new Rectangle(0, 0, sourceWidth, sourceHeight),
        //                         GraphicsUnit.Pixel);

        //    // Dispose of the bmGraphics object
        //    bmGraphics.Dispose();

        //    // Set the image of the picImage picturebox to the temporary bitmap
        //    MyFirstForm.picImage.Image = tempBitmap;
        //}

  


    }
}
