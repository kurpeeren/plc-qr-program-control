using S7.Net;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace qrkod
{
    public partial class setform : Form
    {
        private Plc Plc_1 = null;

        //private Exceptioncode = errorList ;

        public setform()
        {
            InitializeComponent();
        }
        private void EnabledBox(bool enabledFlag)
        {
            IpAdressBox.Enabled = enabledFlag;
            CPUTypeBox.Enabled = enabledFlag;
            SlotBox.Enabled = enabledFlag;
            RockBox.Enabled = enabledFlag;
            btndis.Enabled = !btndis.Enabled;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                this.EnabledBox(true);
                CPUTypeBox.SelectedIndex = 3;
                IpAdressBox.Text = "192.168.0.1";
                SlotBox.Value = 1;
                RockBox.Value = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Not.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btncon_Click(object sender, EventArgs e)
        {
            try
            {
                //
                if (string.IsNullOrEmpty(IpAdressBox.Text)) throw new Exception("IP adres yok IP adres giriniz.");

                int selectPLCType = CPUTypeBox.SelectedIndex;

                CpuType plcType = CpuType.S71200;
                string cpuIP = IpAdressBox.Text;

                switch (selectPLCType)
                {

                    case 0:
                        plcType = CpuType.S7200;
                        break;
                    case 1:
                        plcType = CpuType.S7300;
                        break;
                    case 2:
                        plcType = CpuType.S7400;
                        break;
                    case 3:
                        plcType = CpuType.S71200;
                        break;
                    case 4:
                        plcType = CpuType.S71500;
                        break;
                    default:
                        plcType = CpuType.S71200;
                        CPUTypeBox.SelectedIndex = 3;
                        break;
                }




                Plc_1 = new Plc(plcType, cpuIP, 0, 1);
                Plc_1.Open();


                // Thread t1 = new Thread();
                // t1.Start();

                // Thread.Sleep(200);

                if (!Plc_1.IsConnected) MessageBox.Show(this, "connect olmadım ", "Not.", MessageBoxButtons.OK, MessageBoxIcon.Error);


                if (Plc_1.IsConnected)// Plc_1.IsConnected
                {
                    #region OTOMATIK

                    durum.Text = "Bağlı";
                    durum.ForeColor = Color.Green;

                    //lab.Text = Plc_1.Read(DataType.DataBlock,6,0,VarType.Bit ,0);

                    //var bytes = Plc_1.ReadBytes(DataType.DataBlock, 6, 0, 1);
                    //lab.Text = bytes[0].SelectBit(0).ToString();

                    Plc_1.WriteBit(DataType.DataBlock, 6, 0, 1, true);

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

                    #endregion
                }


                /*
                if (!plc1.IsConnected) throw new Exception("No PLC");
                if (plc1.IsConnected)
                {
                    var bytes = plc1.ReadBytes(DataType.DataBlock, 1, 0, 110);
                    var Bool1 = plc1.Read(DataType.DataBlock, 1, 0, VarType.Bit, 10, 0);
                    var deneme = bytes[0].SelectBit(0);

                }*/
                //errorList = plc.Open();
                //if (errorList != ExceptionCode.ExceptionNo) throw new Exception(plc.lastErrorString);
                this.EnabledBox(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Not.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
