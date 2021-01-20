using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pixel
{



    public partial class Form1 : Form
    {
        

        Bitmap newBitmap;
        Bitmap bitmapObj;
        Image imgOriginal;
        Boolean openimage_picture = false;


        public CancellationTokenSource cTokenSource;
        public CancellationToken cToken;

        int[,,] buffer;

        int preColor = 0;
        int brightness = 0;
        

        private Bitmap _currentBitmap;
        private Bitmap _bitmapbeforeProcessing;


        public Form1()
        {
            InitializeComponent();
        }


        
        //storing image to use it for undo & redo-----------
        public Bitmap CurrentBitmap
        {
            get
            {
                if (_currentBitmap == null)
                    _currentBitmap = new Bitmap(1, 1);
                return _currentBitmap;
            }
            set { _currentBitmap = value; }
        }

        public Bitmap BitmapBeforeProcessing
        {
            get { return _bitmapbeforeProcessing; }
            set { _bitmapbeforeProcessing = value; }
        }

        public void RestorePrevious()
        {
            _bitmapbeforeProcessing = _currentBitmap;
        }

        public void ResetBitmap()
        {
            if (_currentBitmap != null && _bitmapbeforeProcessing != null)
            {
                Bitmap temp = (Bitmap)_currentBitmap.Clone();
                _currentBitmap = (Bitmap)_bitmapbeforeProcessing.Clone();
                _bitmapbeforeProcessing = (Bitmap)temp.Clone();
            }
            else
            {
                MessageBox.Show("No edits done yet!");
            }
        }
        //--------------------------------



        //---Add image method
        public void Add_Image()
        {
            try
            {
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    CurrentBitmap = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                    imgOriginal = Image.FromFile(openFileDialog1.FileName);
                    newBitmap = new Bitmap(openFileDialog1.FileName);
                    buffer = new int[3, newBitmap.Height, newBitmap.Width];
                    pictureBox1.Image = imgOriginal;
                    openimage_picture = true;
                    this.TransparencyKey = Color.Empty;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        //-----------------------------------


        private void ReadPixels()
        {
            for (int row = 0; row < newBitmap.Height; row++)
            {
                for(int col = 0; col < newBitmap.Width; col++)
                {
                    Color c = newBitmap.GetPixel(col, row);
                    buffer[0, row, col] = c.R;
                    buffer[1, row, col] = c.G;
                    buffer[2, row, col] = c.B;


                }
            }
        }

        
        //---------Save image method
        public void Save_picutre()
        {
            if (openimage_picture)
            {

                SaveFileDialog save_pic = new SaveFileDialog();
                save_pic.Filter = "Images|*.png;*.jpg*;.bmp*";
                ImageFormat format = ImageFormat.Png;


                if (save_pic.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string extension = Path.GetExtension(save_pic.FileName);

                    switch (extension)
                    {

                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;

                        case ".png":
                            format = ImageFormat.Png;
                            break;
                    }

                    pictureBox1.Image.Save(save_pic.FileName, format);
                    MessageBox.Show("Image saved sucessfully");
                }


            }
            else
            {
                MessageBox.Show("No Image Found!!");
            }

        }

        //openimage Button
        private void button1_Click(object sender, EventArgs e)
        {
            
            Add_Image();
        }

        //Saveimage button
        private void button2_Click(object sender, EventArgs e)
        {
            
            Save_picutre();
        }


        //crop-------------------------------------------------------------------
        private void selectAreaBtn_Click(object sender, EventArgs e)
        {
            
            if (pictureBox1.Image != null)
            {
                pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);

                pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);

                pictureBox1.MouseEnter += new EventHandler(pictureBox1_MouseEnter);
                Controls.Add(pictureBox1);
            }
            else
            {
                MessageBox.Show("Image box is empty..", "PIXEL");
            }
        }

        private void CropBtn_Click(object sender, EventArgs e)
        {
            RestorePrevious();
            Cursor = Cursors.Default;
            //Now draw the cropped image
            
            Bitmap bmp2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bmp2, pictureBox1.ClientRectangle);
            
            Bitmap crpImg = new Bitmap(rectW, rectH);

            for (int i = 0; i < rectW; i++)
            {
                for (int y = 0; y < rectH; y++)
                {
                    Color pxlclr = bmp2.GetPixel(crpX + i, crpY + y);
                    crpImg.SetPixel(i, y, pxlclr);
                }
            }

            pictureBox1.Image = (Image)crpImg;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            Cursor = Cursors.Default;

            _currentBitmap = (Bitmap)crpImg;

            
            


        }

        int crpX, crpY, rectW, rectH;
        public Pen crpPen = new Pen(Color.White);
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Cursor = Cursors.Cross;
                crpPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                // set initial x,y co ordinates for crop rectangle
                //this is where we firstly click on image
                crpX = e.X;
                crpY = e.Y;

            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.Cross;

            Cursor = Cursors.Default;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBox1.Refresh();
                //set width and height for crop rectangle.
                rectW = e.X - crpX;
                rectH = e.Y - crpY;
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawRectangle(crpPen, crpX, crpY, rectW, rectH);
                g.Dispose();
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
        }

    //endofcrop--------------------------------------------------------------------


   
        //reset button
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            reset_image();

        }

        //Bar change to 0 method
        public void none()
        {

            Task task1 = new Task(() =>
            {
                pictureBox1.Image = imgOriginal;

                
            });

            task1.Start(TaskScheduler.FromCurrentSynchronizationContext());
        }
        //reset method
        public void reset_image()
        {

            if (!openimage_picture)
            {
                MessageBox.Show("Please upload an image first ! ");
            }
            else
            {
                if (openimage_picture)
                {
                    imgOriginal = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = imgOriginal;
                    openimage_picture = true;

                    Task t1none = new Task(() =>
                    {
                        none();
                    });
                    t1none.Start(TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }
        //---------------------------------


        //Clear button
        private void clearBtn_Click(object sender, EventArgs e)
        {
            Delete_Picture();
            openimage_picture = false;
        }

        public void Delete_Picture()
        {
            pictureBox1.Image = null;
        }

        /*---------------------Effects-------------------------------------*/

        /*grayscale--------------------------------------------------------------------------------*/
        private void GrayscalBtn_Click(object sender, EventArgs e)
        {
            RestorePrevious();
            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            if (openimage_picture) { 

            Func<Object, Image> func = new Func<object, Image>(Grayscale);
            Task<Image> t = new Task<Image>(func, imgOriginal,cToken);
            t.Start();
            t.ContinueWith((task) =>
                {
                    pictureBox1.Image = task.Result;

                }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                MessageBox.Show("No image found");
            }

        }


        Image Grayscale(object obj)
        {
            
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();

            //Image img = (Image)obj;

            Image imgG = null;


            Bitmap oriBmp = new Bitmap(bmp);
            //Bitmap bmp = new Bitmap(img.Width, img.Height);

            Color c1, c2;

            for (int i = 1; i < bmp.Width; i++)
            {
                for (int j = 1; j < bmp.Height; j++)
                {
                    cToken.ThrowIfCancellationRequested();
                    c1 = oriBmp.GetPixel(i, j);
                    int c2A = (int)c1.A;
                    int c2Gray = (int)(
                    (Convert.ToDouble(c1.R) * 0.3) +
                    (Convert.ToDouble(c1.G) * 0.59) +
                    (Convert.ToDouble(c1.B) * 0.11)
                    );
                    c2 = Color.FromArgb(c2A, c2Gray, c2Gray, c2Gray);
                    bmp.SetPixel(i, j, c2);
                }
            }



            _currentBitmap = (Bitmap)bmp.Clone();
            
            imgG = (Image)bmp;
            return imgG;


        }

        /*invert--------------------------------------------------------------------------------*/

        private void InvertBtn_Click(object sender, EventArgs e)
        {
            RestorePrevious();
            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;

            Func<Object, Image> func = new Func<object, Image>(Invert);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());


        }

        Image Invert(object obj)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();

            //Image img = (Image)obj;

            Image imgI;

            Bitmap oriBmp = new Bitmap(bmp);
            //Bitmap bmp = new Bitmap(img.Width, img.Height);

            Color c;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    cToken.ThrowIfCancellationRequested();
                    c = oriBmp.GetPixel(x, y);

                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;
                    bmp.SetPixel(x, y, Color.FromArgb(255 - red, 255 - green, 255 - blue));
                }
            }

            _currentBitmap = (Bitmap)bmp.Clone();

            imgI = (Image)bmp;
            return imgI;


        }

        /*contrast--------------------------------------------------------------------------------*/

        private void ContrastBtn_Click(object sender, EventArgs e)
        {
            RestorePrevious();
            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;

            Func<Object, Image> func = new Func<object, Image>(Contrast);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());


        }

        Image Contrast(object obj)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();

            //Image img = (Image)obj;

            Image imgCtrst;

            Bitmap oriBmp = new Bitmap(bmp);
            //Bitmap bmp = new Bitmap(img.Width, img.Height);


            double contrast = -20;

            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    cToken.ThrowIfCancellationRequested();
                    c = oriBmp.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    bmp.SetPixel(i, j, Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }

            _currentBitmap = (Bitmap)bmp.Clone();

            imgCtrst = (Image)bmp;
            return imgCtrst;



        }

        /*Blur--------------------------------------------------------------------------------*/
        private void BlurBtn_Click(object sender, EventArgs e)
        {

            RestorePrevious();
            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(Blur);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());


        }

        Image Blur(object obj)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();

            //Image img = (Image)obj;

            Image imgBlur;

            Bitmap oriBmp = new Bitmap(bmp);
            //Bitmap bmp = new Bitmap(img.Width, img.Height);



            for (int x = 1; x < bmp.Width ; x++)
            {
                for (int y = 1; y < bmp.Height; y++)
                {
                   cToken.ThrowIfCancellationRequested();

                        Color prevX = oriBmp.GetPixel(x - 1, y);
                        Color nextX = oriBmp.GetPixel(x - 1, y);
                        Color prevY = oriBmp.GetPixel(x, y - 1);
                        Color nextY = oriBmp.GetPixel(x, y - 1);


                        int avgR = (int)((prevX.R + nextX.R + prevY.R + nextY.R) / 4);
                        int avgG = (int)((prevX.G + nextX.G + prevY.G + nextY.G) / 4);
                        int avgB = (int)((prevX.B + nextX.B + prevY.B + nextY.B) / 4);

                        bmp.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));



                    
                }


            }
            _currentBitmap = (Bitmap)bmp.Clone();

            imgBlur = (Image)bmp;
            return imgBlur;

        }


       
        /*Emboss--------------------------------------------------------------------------------*/
        private void EmbossBtn_Click(object sender, EventArgs e)
        {

            RestorePrevious();
            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(Emboss);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());
           

        }


        Image Emboss(object obj)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();

            
            Image imgEmb = null;

            Bitmap oriBmp = new Bitmap(bmp);



            for (int x = 1; x <= bmp.Width - 1; x++)
            {
                for (int y = 1; y <= bmp.Height - 1; y++)
                {

                    cToken.ThrowIfCancellationRequested();
                    bmp.SetPixel(x, y, Color.DarkGray);
                }

            }
            for (int x = 1; x <= bmp.Width - 1; x++)
            {
                for (int y = 1; y <= bmp.Height - 1; y++)
                {
                    try
                    {
                        Color pixel = oriBmp.GetPixel(x, y);

                        int colVal = (pixel.R + pixel.G + pixel.B);

                        if (preColor == 0) preColor = (pixel.R + pixel.G + pixel.B);

                        int diff;

                        if (colVal > preColor) { diff = colVal - preColor; } else { diff = preColor - colVal; }

                        if (diff > 100)
                        {
                            bmp.SetPixel(x, y, Color.Gray);
                            preColor = colVal;
                        }


                    }
                    catch (Exception) { }
                }
            }

            for (int y = 1; y <= bmp.Height - 1; y++)
            {

                for (int x = 1; x <= bmp.Width - 1; x++)
                {
                    try
                    {
                        Color pixel = oriBmp.GetPixel(x, y);

                        int colVal = (pixel.R + pixel.G + pixel.B);

                        if (preColor == 0) preColor = (pixel.R + pixel.G + pixel.B);

                        int diff;

                        if (colVal > preColor) { diff = colVal - preColor; } else { diff = preColor - colVal; }

                        if (diff > 100)
                        {
                            bmp.SetPixel(x, y, Color.Gray);
                            preColor = colVal;
                        }

                    }
                    catch (Exception) { }
                }

            }
            _currentBitmap = (Bitmap)bmp.Clone();

            imgEmb = (Image)bmp;
            return imgEmb;



        }



        /*Vertical flip--------------------------------------------------------------------------------*/
        private void VerticalFlipBtn_Click(object sender, EventArgs e)
        {
            
            RestorePrevious();
            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(Vertical_flip);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());
        }

        /*Horizontal flip--------------------------------------------------------------------------------*/
        private void HorizontalFlipBtn_Click(object sender, EventArgs e)
        {
            RestorePrevious();
            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(Horizontal_flip);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());

        }


        //horizontal Flip method
        Image Horizontal_flip(object obj)
        {

            Image imghf;

            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();

            Bitmap oriBmp = new Bitmap(bmp);

            Color c;

            var w = bmp.Width - 1;

            for (int i = 0; i < bmp.Width; i++)
            {
                var h = bmp.Height - 1;
                for (int j = 0; j < bmp.Height; j++)
                {
                    cToken.ThrowIfCancellationRequested();
                    c = oriBmp.GetPixel(i, j);
                    bmp.SetPixel(i, h, c);
                    h--;
                }
                w--;
            }

            _currentBitmap = (Bitmap)bmp.Clone();

            imghf = (Image)bmp;
            return imghf;


        }

        //Verticl method
        Image Vertical_flip(object obj)
        {
            Image imgvf;

            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();

            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);

            _currentBitmap = (Bitmap)bmp.Clone();

            imgvf = (Image)bmp;
            return imgvf;

        }


        public void picture_refresh()
        {
            pictureBox1.Image = imgOriginal;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RotateLeftBtn_Click(object sender, EventArgs e)
        {
            
            RestorePrevious();
            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(Rotate_left);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());
        }

        //rotate right
        private void Rotate_Click(object sender, EventArgs e)
        {
            
            RestorePrevious();
            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(Rotate_right);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());

        }

        Image Rotate_right(Object obj)
        {
            Image imgRt;

            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();

            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);

            _currentBitmap = (Bitmap)bmp.Clone();

            imgRt = (Image)bmp;
            return imgRt;


        }



        //rotate left
        Image Rotate_left(Object obj)
        {
            Image imgLft;

            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();

            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);

            _currentBitmap = (Bitmap)bmp.Clone();

            imgLft = (Image)bmp;
            return imgLft;


        }

       
        private void BrightUp_Click(object sender, EventArgs e)
        {

            RestorePrevious();
            brightness = 10;
            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(Brightness);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void BrightDown_Click(object sender, EventArgs e)
        {
            RestorePrevious();
            brightness = -10;
            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(Brightness);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());
        }


        //brightness method
        Image Brightness(object obj)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();

            //Image img = (Image)obj;
            Image imgBri = null;

            Bitmap oriBmp = new Bitmap(bmp);
            

            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;
            Color c;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = oriBmp.GetPixel(i, j);
                    int cR = c.R + brightness;
                    int cG = c.G + brightness;
                    int cB = c.B + brightness;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    bmp.SetPixel(i, j, Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                }
            }
            _currentBitmap = (Bitmap)bmp.Clone();

            imgBri = (Image)bmp;
            return imgBri;



        }

        

       

        private void RedColorBtn_Click(object sender, EventArgs e)
        {
            RestorePrevious();

            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(RedColor);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());
        }

        //red color effect method
        Image RedColor(object obj)
        {

            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();

            Image imgColor = null;
            Bitmap oriBmp = new Bitmap(bmp);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    //get pixel value
                    Color p = oriBmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //set red image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, 0, 0));

                }
                
            }
            _currentBitmap = (Bitmap)bmp.Clone();
            imgColor = (Image)bmp;
            return imgColor;
        }

        private void GreenColorBtn_Click(object sender, EventArgs e)
        {
            RestorePrevious();

            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(GreenColor);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());
        }

        //green effect method
        Image GreenColor(object obj)
        {
            Image temp = (Image)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();

            Image imgColor = null;
            Bitmap oriBmp = new Bitmap(bmp);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    //get pixel value
                    Color p = oriBmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //set Green image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(a, 0, g, 0));

                }

            }
            _currentBitmap = (Bitmap)bmp.Clone();
            imgColor = (Image)bmp;
            return imgColor;

        }

        private void BlueColorBtn_Click(object sender, EventArgs e)
        {
            RestorePrevious();

            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(BlueColor);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());
        }

        //blue effect method
        Image BlueColor(object obj)
        {

            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();

            Image imgColor = null;
            Bitmap oriBmp = new Bitmap(bmp);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    //get pixel value
                    Color p = oriBmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //set Blue image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(a, 0, 0, b));

                }

            }
            _currentBitmap = (Bitmap)bmp.Clone();
            imgColor = (Image)bmp;
            return imgColor;
        }

        /*sharpen.....................................................................................*/
        private void SharpenBtn_Click(object sender, EventArgs e)
        {
            RestorePrevious();

            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(Sharpen);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());
        }

       
        Image Sharpen(object obj)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();


            Image imgShrp = null;

            Bitmap oriBmp = new Bitmap(bmp);

            Color c;

            for (int row = 1; row < bmp.Height - 2; row++)
            {
                for (int col = 1; col < bmp.Width - 2; col++)
                {

                    

                    c = oriBmp.GetPixel(col, row);
                    buffer[0, row, col] = c.R;
                    buffer[1, row, col] = c.G;
                    buffer[2, row, col] = c.B;


                    int R = (int)(buffer[0, row, col] + 0.5 * (buffer[0, row, col] - buffer[0, row - 1, col - 1]));
                   int G = (int)(buffer[1, row, col] + 0.5 * (buffer[1, row, col] - buffer[1, row - 1, col - 1]));
                    int B = (int)(buffer[2, row, col] + 0.5 * (buffer[2, row, col] - buffer[2, row - 1, col - 1]));
                    if (R > 255)
                    {
                        R = 255;
                    }
                    if (R < 0)
                    {
                        R = 0;
                    }
                    if (G > 255)
                    {
                        G = 255;
                    }
                    if (G < 0)
                    {
                        G = 0;
                    }
                    if (B > 255)
                    {
                        B = 255;
                    }
                    if (B < 0)
                    {
                        B = 0;
                    }
                    Color c1 = Color.FromArgb(R, G, B);
                    bmp.SetPixel(col, row, c1);
                }
                


            }

            _currentBitmap = (Bitmap)bmp.Clone();
            imgShrp = (Image)bmp;
            return imgShrp;


        }


        /*Sepia.....................................................................................*/
        private void SepiaBtn_Click(object sender, EventArgs e)
        {
            RestorePrevious();
            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(Sepia);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());

        }

        Image Sepia(object obj)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();


            Image imgSep = null;

            Bitmap oriBmp = new Bitmap(bmp);

            Color c;

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    c = oriBmp.GetPixel(x, y);

                    int a = c.A;
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }
                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        b = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));


                }
            }
            _currentBitmap = (Bitmap)bmp.Clone();
            imgSep = (Image)bmp;
            return imgSep;

        }

        /*Diffuse.....................................................................................*/
        private void DiffuseBtn_Click(object sender, EventArgs e)
        {
            RestorePrevious();

            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(Diffuse);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());

        }

        Image Diffuse(object obj)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();


            Image imgDiff = null;

            Bitmap oriBmp = new Bitmap(bmp);

            Color c;

            ReadPixels();
            

            for ( int row = 3; row < bmp.Height - 4; row++)
            {
                for(int col = 3; col < bmp.Width -4; col++)
                {

                    int rx = new Random().Next(4);
                    int ry = new Random().Next(4);

                    int R = buffer[0, row + rx, col + ry];
                    int G = buffer[1, row + rx, col + ry];
                    int B = buffer[2, row + rx, col + ry];

                    c = Color.FromArgb(R, G, B);
                    bmp.SetPixel(col, row, c);

                }
            }
            _currentBitmap = (Bitmap)bmp.Clone();
            imgDiff = (Image)bmp;
            return imgDiff;

        }

        /*threshold.....................................................................................*/
        private void ThresholdBtn_Click(object sender, EventArgs e)
        {
            RestorePrevious();

            cTokenSource = new CancellationTokenSource();
            cToken = cTokenSource.Token;
            Func<Object, Image> func = new Func<object, Image>(Threshold);
            Task<Image> t = new Task<Image>(func, imgOriginal, cToken);
            t.Start();
            t.ContinueWith((task) =>
            {
                pictureBox1.Image = task.Result;

            }, CancellationToken.None,
                TaskContinuationOptions.NotOnCanceled,
                TaskScheduler.FromCurrentSynchronizationContext());
            t.ContinueWith((task) =>
            {
                MessageBox.Show("Task Cancelled..");
            }, CancellationToken.None,
            TaskContinuationOptions.OnlyOnCanceled,
            TaskScheduler.FromCurrentSynchronizationContext());

        }

        Image Threshold(object obj)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmp = (Bitmap)temp.Clone();


            Image imgThres = null;

            Bitmap oriBmp = new Bitmap(bmp);

            Color c;

            double avgBright = 0;
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    // Get the brightness of this pixel
                    avgBright += oriBmp.GetPixel(x, y).GetBrightness();
                }
            }

            // Get the average brightness and limit it's min / max
            avgBright = avgBright / (oriBmp.Width * oriBmp.Height);
            avgBright = avgBright < .3 ? .3 : avgBright;
            avgBright = avgBright > .7 ? .7 : avgBright;

            // Convert image to black and white based on average brightness
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    // Set this pixel to black or white based on threshold
                    if (oriBmp.GetPixel(x, y).GetBrightness() > avgBright) bmp.SetPixel(x, y, Color.White);
                    else bmp.SetPixel(x, y, Color.Black);
                }
            }
            _currentBitmap = (Bitmap)bmp.Clone();
            imgThres = (Image)bmp;
            return imgThres;

        }

        //undo button
        private void undoBtn_Click(object sender, EventArgs e)
        {

            if(imgOriginal != null ) {
                ResetBitmap();
                this.pictureBox1.Image = CurrentBitmap;
                this.Invalidate();


            }
            else
            {
                MessageBox.Show("Nothing to undo");
            }

            

        }

        //redo button
        private void redoBtn_Click(object sender, EventArgs e)
        {
            if (imgOriginal != null) {
                ResetBitmap();
                this.pictureBox1.Image = CurrentBitmap;
                this.Invalidate();



            }
            else
            {
                MessageBox.Show("Nothing to Redo");
            }
            
               
            
        }

        //Task cancelation button
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            cTokenSource.Cancel();
        }


        //end------------------------------------








    }
}
