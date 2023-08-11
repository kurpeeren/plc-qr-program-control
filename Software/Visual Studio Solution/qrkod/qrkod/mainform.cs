using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using S7.Net;
using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZXing;

namespace qrkod
{
    public partial class mainform : Form
    {
        
        private Plc Plc_1 = null;
        MJPEGStream streamvideo;
        public mainform()
        {
            InitializeComponent();

        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        private void Form1_Load(object sender, EventArgs e)
        {

            //str_oku(DataType.DataBlock,1,1,1);
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            this.MinimumSize = new Size(600, 400);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cboDevice.Items.Add(filterInfo.Name);
            cboDevice.SelectedIndex = 0;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if ((captureDevice == null))
            {
                captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);

                captureDevice.NewFrame += CaptureDevice_NewFrame;
            }

            txtQr.Text = "";

            Thread t3 = new Thread(captureDevice.Start);
            t3.Start();
            Thread.Sleep(100);
            timer4.Start();
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        void dev_cam()
        {



        }

        private void GetNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                ResizeBicubic filter = new ResizeBicubic(pictureBox2.Size.Width, pictureBox2.Size.Height);
                Bitmap bmpip = (Bitmap)eventArgs.Frame.Clone();
                Bitmap newImage1 = filter.Apply(bmpip);
                pictureBox2.Image = newImage1;
            }
            catch { }
        }
        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                ResizeBicubic filter = new ResizeBicubic(pictureBox1.Size.Width, pictureBox1.Size.Height);
                Bitmap image;
                image = (Bitmap)eventArgs.Frame.Clone();
                Bitmap newImage = filter.Apply(image);
                pictureBox1.Image = newImage;
            }
            catch { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(captureDevice == null))
            {
                if (captureDevice.IsRunning.Equals(true))
                {
                    captureDevice.Stop();
                }
            }
        }

        private bool str_yaz(DataType dataType, int db, int str_baslangic, int str_uzunluk, string str)
        {
            //var bytes = Plc_1.ReadBytes(DataType.DataBlock, 2, baslangic, uzunluk);
            try { 
            if (str.Length < str_uzunluk)
            {

                Plc_1.WriteBytes(dataType, db, str_baslangic + 2, Encoding.ASCII.GetBytes(String.Concat(Enumerable.Repeat("\0", str_uzunluk))));
                Plc_1.WriteBytes(dataType, db, str_baslangic + 1, BitConverter.GetBytes(str.Length));
                Plc_1.WriteBytes(dataType, db, str_baslangic + 2, Encoding.ASCII.GetBytes(str));

                var bytes = Plc_1.ReadBytes(dataType, db, str_baslangic, str_uzunluk);


                if (S7.Net.Types.String.FromByteArray(bytes.Skip(1).Take(str.Length).ToArray()) == str)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            else
            {
                //return false;
                throw new IndexOutOfRangeException("Dizinin sınırları aşıldı");



            }
            }
            catch (Exception ex) 
            {   
                
                throw new IndexOutOfRangeException(ex.ToString());


            }
            
        }
        
        //private string str_oku(DataType dataType, int db, int str_baslangic, int str_uzunluk)
        //{
        //    var asd = "HATA";
        //    try {
            
        //    var bytes = Plc_1.ReadBytes(dataType, db, str_baslangic, str_uzunluk);
        //    asd = S7.Net.Types.String.FromByteArray(bytes.Skip(2).Take(bytes[0]).ToArray());
            
        //    }
        //    catch (Exception ex)
        //    {
                
        //        throw new IndexOutOfRangeException(ex.ToString());


        //    }

        //    return asd;

        //}






        //private bool yaz(DataType dataType = DataType.DataBlock, int db = 1, int str_baslangic = 16, int str_uzunluk = 30)
        //{
        //    //var bytes = Plc_1.ReadBytes(DataType.DataBlock, 2, baslangic, uzunluk);

        //    if (str.Length < str_uzunluk)
        //    {

        //        var bytes = Plc_1.ReadBytes(DataType.DataBlock, 2, str_baslangic, str_uzunluk);

        //        Plc_1.WriteBytes(DataType.DataBlock, db, str_baslangic + 2, Encoding.ASCII.GetBytes(String.Concat(Enumerable.Repeat("\0", str_uzunluk))));
        //        Plc_1.WriteBytes(DataType.DataBlock, db, str_baslangic + 1, BitConverter.GetBytes(str.Length));
        //        Plc_1.WriteBytes(DataType.DataBlock, db, str_baslangic + 2, Encoding.ASCII.GetBytes(str));
        //        return true;
        //    }
        //    else
        //    {
        //        throw new IndexOutOfRangeException("Dizinin sınırları aşıldı");

        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (!(Plc_1 == null) && (Plc_1.IsConnected))
            {

                //var bytes = Plc_1.ReadBytes(DataType.DataBlock, 2, 0, 15);

                //if ((bytes[14].SelectBit(3) == false))
                //{
                //    btnok.Text = "OK";
                //    btnok.BackColor = Color.Green;
                //}
                //else if (!(bytes[14].SelectBit(3) == false))
                //{
                //    btnok.Text = "NOK";
                //    btnok.BackColor = Color.Red;
                //}

                //if ((bytes[14].SelectBit(2) == false))
                //{
                //    btnok.Text = "OK";
                //    btnok.BackColor = Color.Green;
                //}
                //else if (!(bytes[14].SelectBit(2) == false))
                //{
                //    btnok.Text = "NOK";
                //    btnok.BackColor = Color.Red;
                //}


            }




        }

        void barkod_bekle()
        {

            izin.BackColor = Color.Green;
            Thread.Sleep(200);
            Console.Beep(700, 200);
            izin.BackColor = Color.Red;


        }
        bool izinn = true;
        void th_izin()
        {

            Thread.Sleep(100);
            izinn = true;

        }

        void baglanma()
        {
            while (!Plc_1.IsConnected)
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send("192.168.1.173", 50);
                if (reply != null)
                {
                    try { Plc_1.Open(); }
                    catch { Plc_1.Close(); }
                }
            }

        }
        private void btncon_Click(object sender, EventArgs e)
        {
            try
            {
                Plc_1 = new Plc(CpuType.S71200, "192.168.1.178", 0, 1);
                timer3.Start();


                //Plc_1.Open();



                while (Plc_1.IsConnected)// Plc_1.IsConnected
                {
                    //#region OTOMATIK

                    //lblcon.Text = "Bağlı";
                    //lblcon.ForeColor = Color.Green;
                    //Thread.Sleep(100);
                    //lblcon.ForeColor = Color.Lime;
                    //Thread.Sleep(100);

                    //lab.Text = Plc_1.Read(DataType.DataBlock,6,0,VarType.Bit ,0);

                    //var bytes = Plc_1.ReadBytes(DataType.DataBlock, 6, 0, 1);
                    //lab.Text = bytes[0].SelectBit(0).ToString();

                    //Plc_1.WriteBit(DataType.DataBlock, 1, 0, 0, 1);

                    //Plc_1.WriteBit(DataType.DataBlock, 6, 0, 5, false);
                    //Plc_1.WriteBit(DataType.DataBlock, 6, 6, 1, 1);
                    //Plc_1.WriteBit(DataType.DataBlock, 6, 0, 0, true);
                    //Plc_1.WriteBytes(DataType.DataBlock, 6, 0, BitConverter.GetBytes(70).Reverse().ToArray());
                    //Plc_1.WriteBytes(DataType.DataBlock, 6, 2, BitConverter.GetBytes(150).Reverse().ToArray());
                    //Plc_1.WriteBytes(DataType.DataBlock, 6, 6, BitConverter.GetBytes(100).Reverse().ToArray());

                    //var Bool1 = Plc_1.Read(DataType.DataBlock, 6, 0, VarType.Bit, 10, 0);
                    //var bytes = Plc_1.ReadBytes(DataType.DataBlock, 1, 0, 110);
                    //var Bool1 = Plc_1.Read(DataType.DataBlock, 1, 0, VarType.Bit, 10, 0);
                    //var deneme = bytes[0].SelectBit(0);
                    //var deneme1 = bytes[0].SelectBit(1);
                    //Plc_1.WriteBytes(DataType.DataBlock, 1, 53, BitConverter.GetBytes(0));
                    //if(deneme) Plc_1.WriteBit(DataType.DataBlock,1,0,0,false);
                    //else Plc_1.WriteBit(DataType.DataBlock, 1, 0, 0, true);
                    //Plc_1.WriteBit(DataType.DataBlock, 1, 0, 1, true);
                    //Plc_1.WriteBytes(DataType.DataBlock, 6, 1, BitConverter.GetBytes(19));
                    //var integer2 = S7.Net.Types.Int.FromByteArray(bytes.Skip(2).Take(2).ToArray());
                    //Plc_1.WriteBit(DataType.DataBlock, 1, 0, 0, false);
                    //Plc_1.WriteBytes(DataType.DataBlock, 6, 2, BitConverter.GetBytes(0));

                    //#endregion
                    // Plc_1.WriteBytes(DataType.DataBlock, 1, 53, BitConverter.GetBytes(0));
                    
                   
                    //       Plc_1.Write(DataType.DataBlock, 3,0, true);
                }
            }
            catch
            {

            }
        }
        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }
        string bittes, reals1, reals2, reals3;
        void parsee(string kod)
        {
            BitArray mybyte = new BitArray(8);
            try
            {
                if (kod.Length == 17)
                {
                    bittes = kod.Substring(0, 8);
                    reals1 = kod.Substring(8, 3);
                    reals2 = kod.Substring(11, 3);
                    reals3 = kod.Substring(14, 3);

                    float realint1 = Int16.Parse(reals1);
                    float realint2 = Int16.Parse(reals2);
                    float realint3 = Int16.Parse(reals3);
                    for (int i = 0; i < 8; i++)
                    {
                        if (bittes[i] == '0')
                        { mybyte[i] = false; }

                        else if (bittes[i] == '1')
                        { mybyte[i] = true; }
                        else
                        {
                            txtQr.Text = kod;//"Hatalı Barkod";
                        }

                    }

                    if (con == 1)
                    {

                        //&& btnok.Text=="OK"

                        Plc_1.WriteBytes(DataType.DataBlock, 2, 0, BitArrayToByteArray(mybyte));
                        Plc_1.WriteBytes(DataType.DataBlock, 2, 2, BitConverter.GetBytes(realint1).Reverse().ToArray());
                        Plc_1.WriteBytes(DataType.DataBlock, 2, 6, BitConverter.GetBytes(realint2).Reverse().ToArray());
                        Plc_1.WriteBytes(DataType.DataBlock, 2, 10, BitConverter.GetBytes(realint3).Reverse().ToArray());


                    }
                    else
                    {
                        txtQr.Text = kod;// "Bağlı Değil"; }
                    }
                }


                else
                {
                    txtQr.Text = kod;//"Hatalı Barkod";

                }


            }
            catch { txtQr.Text = "Hata"; }


        }

        bool flsa = true;
        int con = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!Plc_1.IsConnected)
                {
                    lblcon.Text = "Disconnect";
                    flsa = !flsa;
                    con = 0;
                    if (flsa) lblcon.ForeColor = Color.Red;
                    else lblcon.ForeColor = Color.Orange;
                }
                if (Plc_1.IsConnected)
                {
                    lblcon.Text = "Connect";
                    flsa = !flsa;
                    con = 1;
                    if (flsa) lblcon.ForeColor = Color.Black;
                    else lblcon.ForeColor = Color.Green;

                    
                }
            }
            catch { }
        }





        private void btnip_Click(object sender, EventArgs e)
        {

            if ((streamvideo == null))
            {

                streamvideo = new MJPEGStream("http://192.168.21.136:4747/video");//http://192.168.21.136:4747/video
                streamvideo.NewFrame += GetNewFrame;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            txtQr.Text = "";
            // create filter

            // apply the filter


            Thread t4 = new Thread(streamvideo.Start);
            t4.Start();
            Thread.Sleep(100);
            txtQr.Text = "";
            timer4.Start();

            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        private void timer3_Tick_1(object sender, EventArgs e)
        {
            Thread t1 = new Thread(baglanma);
            t1.Start();
            timer2.Start();
            timer1.Start();
        }
        BarcodeReader barcodeReader = new BarcodeReader();

        Result result, result1;

        private void timer5_Tick(object sender, EventArgs e)
        {

        }

        private void btngonder_Click(object sender, EventArgs e)
        {
            Console.Beep(800, 200);
            var asd = txtQr.Text;
            //txtQr.Text = str_yaz(DataType.DataBlock, 2, 16, 30, asd).ToString();
            //txtQr.Text = str_oku(DataType.DataBlock, 2, 16, 30);
        }


        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                    if (result != null)
                    {
                        if (izinn)
                        {
                            txtQr.Text = result.ToString();
                            //btnStart.Enabled = true;
                            parsee(result.ToString());
                            //btnok.Text = "OK";
                            //btnok.BackColor = Color.Green;
                            izinn = false;

                        }
                        Thread t5 = new Thread(barkod_bekle);
                        t5.Start();

                        Thread t6 = new Thread(th_izin);
                        t6.Start();


                        //if (!(captureDevice == null))
                        //{
                        //    if (captureDevice.IsRunning)
                        //        captureDevice.Stop();
                        //}
                    }

                }


                if (pictureBox2.Image != null)
                {


                    result1 = barcodeReader.Decode((Bitmap)pictureBox2.Image);

                    if (result1 != null)
                    {



                        if (izinn)
                        {
                            btnok.BackColor = Color.Blue;
                            txtQr.Text = result1.ToString();
                            //btnStart.Enabled = true;
                            parsee(result1.ToString());
                            //btnok.Text = "OK";
                            //btnok.BackColor = Color.Green;
                            izinn = false;

                        }
                        Thread t5 = new Thread(barkod_bekle);
                        t5.Start();

                        Thread t6 = new Thread(th_izin);
                        t6.Start();


                        //if (!(captureDevice == null))
                        //{
                        //    if (captureDevice.IsRunning)
                        //        captureDevice.Stop();
                        //}
                    }

                }





                //if (pictureBox2.Image != null)
                //{
                //    BarcodeReader barcodeReader = new BarcodeReader();
                //    Result result1 = barcodeReader.Decode((Bitmap)pictureBox2.Image);

                //    if (result1 != null)
                //    {
                //        txtQr.Text = result1.ToString();
                //        //btnStart.Enabled = true;
                //        parsee(result1.ToString());
                //        Thread t5 = new Thread(barkod_bekle);
                //        t5.Start();

                //        //timer1.Stop();
                //        //if (!(captureDevice == null))
                //        //{
                //        //    if (streamvideo.IsRunning)
                //        //        streamvideo.Stop();
                //        //}

                //    }

                //}

            }
            catch { }
            finally { }

        }

        private void izin_Click(object sender, EventArgs e)
        {

        }

        private void btnok_Click(object sender, EventArgs e)
        {

        }
    }
}