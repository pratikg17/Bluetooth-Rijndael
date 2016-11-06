using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP
{
    public partial class MainApplication : Form
    {

        [DllImport("user32.dll")]
        public static extern void LockWorkStation();	

        SqlConnection myCon;
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        DialogResult dialgresult;
        public static string[] files;
        string mac = null;
        public static List<string> bd = new List<string>();
        string pwrkey = @"KEY\KEY\";
        string pwrmac = @"KEY\MAC\";
        string k = "KEY";
        string m = "MAC";
        static Boolean flag = true;
        string wr_key;
        byte[] V = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        byte[] key;
        static bool filepathexist = false;
        string read_text;
        string encryptedtext;
        string decryptedtext;
        string USER;
        public MainApplication()
        {
            
           
            InitializeComponent();



            mac = (new WinReg().Get_Registry(pwrmac, m).ToString());
          
            //BluetoothRangeChecker();

            //if (new MainApplication().BluetoothRangeChecker())
            //{
            //    pbStatus.Image = Properties.Resources.connected;
            //    lblStatus.ForeColor = System.Drawing.Color.Green;
            //    lblStatus.Text = "Connected";
    
            //}
            //else
            //{
            //    pbStatus.Image = Properties.Resources.disconnected;
            //    lblStatus.ForeColor = System.Drawing.Color.Red;
            //    lblStatus.Text = "Disconnected";
    
            //}
         

            //key = Encoding.ASCII.GetBytes(mac);
            myCon = new SqlConnection("Data Source=dell;Initial Catalog=FinalYearProj;Integrated Security=True");


        }

        public string SendData(string user)
        {

            USER = user;
           // return usr ;
            return USER;

        }




        private void btnChangeMac_Click(object sender, EventArgs e)
        {
            MacAddress mac = new MacAddress();
            mac.Show();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myCon;
            myCon.Open();
            DialogResult result = fbd.ShowDialog();
            try
            {
                files = Directory.GetFiles(fbd.SelectedPath);
                lbFolder.Items.Add(new DirectoryInfo(fbd.SelectedPath).Name);

                for (int i = 0; i < files.Length; i++)
                {
                   // cmd.CommandText = "insert into filepaths values('" + files[i] + "')";
            ////

                    cmd.CommandText = "insert into userfiles values('" + files[i] + "','"+ USER+"')";
          

                    ////
                    
                    cmd.ExecuteNonQuery();
                }
                foreach (string filename in files)
                {
                    lbFiles.Items.Add(Path.GetFileName(filename));
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Please Select a Folder"+ exc.Message, "INFORMATION!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            myCon.Close();


        }


        private   Boolean BluetoothRangeChecker()
        {
            BluetoothClient bc = new BluetoothClient();
            BluetoothDeviceInfo[] array = bc.DiscoverDevices();
            int count = array.Length;
            for (int i = 0; i < count; i++)
            {
                bd.Add(array[i].DeviceName);
                if (array[i].DeviceAddress.ToString().Equals(mac))
                {
                    if (array[i].Connected)
                    {
                        flag = true;

                    pbStatus.Image = Image.FromFile(@"F:\FYP3\FYP\FYP\Images\connected.jpg");
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = "Connected";

                        break;
                    }
                    else
                    {
                        flag = false;
                        //pbStatus.Image = Image.FromFile(@"F:\FYP3\FYP\FYP\Images\disconnected.jpg");
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        
                        pbStatus.Image = Properties.Resources.disconnected;

                    }
                }
                else
                {
                    flag = false;

                }
            }
            return flag;
        }
        
        private void bckgroundBluetoothRanger_DoWork(object sender, DoWorkEventArgs e)
        {
            new MainApplication().BluetoothRangeChecker();
            return;

        }

        private void bckgroundBluetoothRanger_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (flag)
            {
                lbDevices.Items.Clear(); 
             
                int i = 0;
              
                foreach (var btd in bd)
                {
                    lbDevices.Items.Insert(i, btd);
                    i++;
                }
                bckgroundBluetoothRanger.RunWorkerAsync();
            }
            else
            {


                pbStatus.Image = Properties.Resources.disconnected;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Disconnected";
                MessageBox.Show("Start Encryption");

                new MainApplication().Encryption(null, null);
            }

        }



        private void Encryption(object sender, EventArgs e)
        {
            Process[] processList = Process.GetProcesses();
            myCon.Open();
            SqlCommand myEcommand = new SqlCommand("select * from  userfiles", myCon);
            SqlDataReader dr = myEcommand.ExecuteReader();

            foreach (Process proc in processList)
            {
                if ((proc.ProcessName).Equals("notepad") || (proc.ProcessName).Equals("WINWORD.EXE"))
                {
                    proc.Kill();
                }
            }

            wr_key = (new WinReg().Get_Registry(pwrmac, m).ToString());
            key = Encoding.ASCII.GetBytes(wr_key);
            // key = Encoding.ASCII.GetBytes("abc");
            filepathexist = false;
            while (dr.Read())
            {
                filepathexist = true;
                if (dr.GetString(1).Equals(USER)&&(dr.GetString(0).Contains("docx") || dr.GetString(0).Contains("doc")))
                {
                   MessageBox.Show("DOCX");
                    //    string destpath = @"F:\BE Project\";
                    //    string destfolder = "Recovery";
                    //    string filename = Path.GetFileName(dr.GetString(0).ToString());
                    ////    MessageBox.Show(filename);

                    //    string filepath = Path.GetDirectoryName(dr.GetString(0).ToString());
                    //  //  MessageBox.Show(filepath);
                    //    string[] filearray = Directory.GetFiles(filepath,"*.doc");
                    //    for (int i = 0; i < filearray.Length; i++)
                    //    {
                    //        string destname = Path.GetFileName(filearray[i]);
                    //         File.Copy(filearray[i], destpath + "\\" + destfolder + "\\" + Path.ChangeExtension(destname, ".crp"), true);


                    //    }




                    //}

                    //myCon.Open();

                    read_text = (new ReadWriteDOcs().ReadMsword(dr.GetString(0)));
                   MessageBox.Show(read_text);

                    encryptedtext = new Encryption().Encrypt(read_text, key, V);

                    MessageBox.Show(encryptedtext);

                    string filename = Path.GetFileName(dr.GetString(0));
                    string pathTxt = @"F:\BE Project\Recovery\" + filename + ".txt";

                    MessageBox.Show(pathTxt);

                    TextWriter tw = new StreamWriter(pathTxt);

                    tw.WriteLine(encryptedtext);

                    tw.Close();


                MessageBox.Show("THE FILE IS CREATED");
                    new ReadWriteDOcs().WriteMsword(dr.GetString(0), encryptedtext);

                }
                else if(dr.GetString(1).Equals(USER))

                {

                MessageBox.Show("TXT");
                    read_text = (new ReadWriteFile().Read(dr.GetString(0)));
                    MessageBox.Show(read_text);
                    encryptedtext = new Encryption().Encrypt(read_text, key, V);
                    new ReadWriteFile().Write(encryptedtext, dr.GetString(0));


                }

            }
            if (!filepathexist)
            {
                var icon = new NotifyIcon();
                icon.Visible = true;
                icon.ShowBalloonTip(1000, "Information", "No file to Encrypt!!", ToolTipIcon.Info);
                MessageBox.Show("No file to Encrypt");
                
              
            }
            myCon.Close();
            //MessageBox.Show("Connection closed");
            ////////////////////
            //DialogResult dlgresult = MessageBox.Show(" Bluetooth is off or Out of Range!!!", "",
            //                     MessageBoxButtons.OK,
            //                     MessageBoxIcon.Information);
            Application.Exit();
            LockWorkStation();

        }



        private void Decryption(object sender, EventArgs e)
        {
            bool DFlag = false;
            string p1 = @"KEY\MAC\";
            string k = "MAC";
            new WinReg().SetRegistry();
            wr_key = (new WinReg().Get_Registry(p1, k).ToString());
            key = Encoding.ASCII.GetBytes(wr_key);



            BluetoothClient bc = new BluetoothClient();
            BluetoothDeviceInfo[] arrayD = bc.DiscoverDevices();
            int count = arrayD.Length;

            for (int i = 0; i < count; i++)
            {
                if (arrayD[i].DeviceAddress.ToString().Equals(wr_key))
                {
                    DFlag = true;
                    break;
                }
                else
                {
                    MessageBox.Show("The Authorized Device is not in Range", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DFlag = false;
                }

            }
            if (DFlag == true)
            {
                //   key = Encoding.ASCII.GetBytes("PRATIK");
                myCon.Open();
             //   SqlCommand myDcommmand = new SqlCommand("select * from filepaths", myCon);

                SqlCommand myDcommmand = new SqlCommand("select * from userfiles", myCon);
               
                SqlDataReader dr = myDcommmand.ExecuteReader();
                MessageBox.Show("REading Encr Files");
                filepathexist = false;
                while (dr.Read())
                {
                    filepathexist = true;
                    MessageBox.Show("Iok");

                    string data1 = dr.GetString(1).ToString();
                    MessageBox.Show(data1);
                    MessageBox.Show("IN TH E  1stLOGIC OF AND'S");
                    
                        if ((dr.GetString(0).Contains("docx") || dr.GetString(0).Contains("doc"))&&dr.GetString(1).Equals(USER))
                        {
                            //          MessageBox.Show("In DATA READER");
                            //   read_text = (new ReadWriteDOcs().ReadMsword(dr.GetString(0)));
                            MessageBox.Show("IN THE LOGIC OF AND'S");
                            string filename = Path.GetFileName(dr.GetString(0));
                            string pathTxt = @"F:\BE Project\Recovery\" + filename + ".txt";

                            //     MessageBox.Show(pathTxt);

                            read_text = (new ReadWriteFile().Read(pathTxt));
                            //   read_text = "THc9viwG+ZcxZOD5ZY9pKA==";
                            MessageBox.Show("From text file" + read_text);
                            decryptedtext = (new Decryption().Decrypt(read_text, key, V));
                            MessageBox.Show(decryptedtext);

                            new ReadWriteDOcs().WriteMsword(dr.GetString(0), decryptedtext);
                        }
                        else
                        {

                            read_text = (new ReadWriteFile().Read(dr.GetString(0)));
                            decryptedtext = (new Decryption().Decrypt(read_text, key, V));
                            new ReadWriteFile().Write(decryptedtext, dr.GetString(0));
                        }
                    
                }
                if (!filepathexist)
                {
                    MessageBox.Show("No Files to Decrypt", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Files are Decrypted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                myCon.Close();
            }


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(USER);
            
           
            
            if (new MainApplication().BluetoothRangeChecker())
            {

                pbStatus.Image = Properties.Resources.connected;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Connected";
    

                //ADD BALOOON
                MessageBox.Show("In the System", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           //     pbStatus.Image = Image.FromFile(@"F:\FYP3\FYP\FYP\Images\connected.jpg");
                ////START THE DECRPT FUCNTION 


                new MainApplication().Decryption(null, null);
                if (!bckgroundBluetoothRanger.IsBusy)
                {
                    bckgroundBluetoothRanger.RunWorkerAsync();
                }
                else
                {
                    //ADD BALOOON
                    MessageBox.Show("System is Busy Right now", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {

                pbStatus.Image = Properties.Resources.disconnected;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Disconnected";
                //ADD BALOOON
                DialogResult dlgresult = MessageBox.Show(" Bluetooth is off or Out of Range!!!", "",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
              //  pbStatus.Image = Image.FromFile(@"F:\FYP3\FYP\FYP\Images\disconnected.jpg");
                Encryption(null, null);

            }
        }

        private void MainApplication_Load(object sender, EventArgs e)
        {
            //if (new MainApplication().BluetoothRangeChecker())
            //{

            //    //ADD BALOOON
            //    MessageBox.Show("In the System", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    ////START THE DECRPT FUCNTION 


            //    new MainApplication().Decryption(null, null);
            //    if (!bckgroundBluetoothRanger.IsBusy)
            //    {
            //        bckgroundBluetoothRanger.RunWorkerAsync();
            //    }
            //    else
            //    {
            //        //ADD BALOOON
            //        MessageBox.Show("System is Busy Right now", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    }
            //}
            //else
            //{

            //    //ADD BALOOON
            //    DialogResult dlgresult = MessageBox.Show(" Bluetooth is off or Out of Range!!!", "",
            //                        MessageBoxButtons.OK,
            //                        MessageBoxIcon.Information);

            //    Encryption(null, null);

            //}
        }

        private void MainApplication_Shown(object sender, EventArgs e)
        {
            
        }



    }


            

    
}
