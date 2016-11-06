using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP
{
    public partial class MacAddress : Form
    {
        public MacAddress()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnChangeM.Enabled = true;
            cbDevices.Items.Clear();
            //cbmac.Items.Clear();
            BluetoothClient bc = new BluetoothClient();
            BluetoothDeviceInfo[] arrayD = bc.DiscoverDevices();
            int count = arrayD.Length;
            for (int i = 0; i < count; i++)
            {

                cbDevices.Items.Add(arrayD[i].DeviceName.ToString());
                //   cbDevices.Items.Add(arrayD[i].DeviceName.ToString() +"  Mac Address is "+ arrayD[i].DeviceAddress.ToString());
                //   cbmac.Items.Add(arrayD[i].DeviceAddress.ToString());
                //   txtKMac.Text = cbmac.SelectedItem.ToString();
            }

        }

        private void btnChangeM_Click(object sender, EventArgs e)
        {
            string pass = @"MAC_PASS\Pass";
            string key = @"Pass";
            string reg_key = (new WinReg().Get_Registry(pass, key).ToString());
            string pkass = txtKpass.Text;

            //  MessageBox.Show(reg_key);
            if (pkass.Equals(reg_key))
            {

                new WinReg().Set_Registry_of_Mac(txtKMac.Text);
                txtKMac.Text = "";
                txtKpass.Text = "";
                MessageBox.Show("MAC IS UPDATED");

            }
            else
            {
                MessageBox.Show("Password Doest Match");
                txtKMac.Text = "";
                txtKpass.Text = "";

            }

        }

        private void cbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            BluetoothClient bc = new BluetoothClient();
            BluetoothDeviceInfo[] arrayM = bc.DiscoverDevices();


            int count = arrayM.Length;
            for (int i = 0; i < count; i++)
            {
                if (cbDevices.SelectedItem.Equals(arrayM[i].DeviceName.ToString()))
                {

                    txtKMac.Text = arrayM[i].DeviceAddress.ToString();
                    // cbmac.Items.Add(arrayM[i].DeviceAddress.ToString());
                    //     cbDevices.SelectedValue = cbmac.SelectedValue;
                }
            }
        }
    }
}
