using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.IO.Ports;

namespace Editovanje_bitpame {
    public partial class Form1 : Form {
        SerialPort serialPort;
        byte[][] niz;
        Boolean edit = false;
        char[][] buffer;
        public Form1() {
            InitializeComponent();
            btn_posaljiSliku.Enabled = false;
            btn_urediSliku.Enabled = false;
            btn_ucitajSliku.Enabled = false;

            string[] comPorts = SerialPort.GetPortNames();
            if (comPorts.Length == 0) {
                MessageBox.Show("Trenutno na računaru nemate COM port.");
                this.Close();
            }
            cb_comPorts.DataSource = comPorts;
            String port = cb_comPorts.Text;
            serialPort = openSerialPort(port);
        }
        private SerialPort openSerialPort(String portName) {
            if (serialPort != null && serialPort.IsOpen) {
                serialPort.Close();
            }
            serialPort = new SerialPort();
            serialPort.PortName = portName;
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), "none", true);
            serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1", true);

            serialPort.ReadTimeout = 5000;
            serialPort.WriteTimeout = 5000;

            serialPort.Open();
            return serialPort;
        }
        private void btn_prikaziSliku_Click(object sender, EventArgs e) {
            //otvara se dialog openFile i izabere se slika (*.bmp|*.jpg|*.png) i prikaze se u PictureBoxu pb_slika
            Stream stream = null;
            
            openFile.InitialDirectory = "C:\\";
            openFile.Filter = "Bitmap (*.bmp)|*.bmp|PNG (*.png)|*.png|JPEG (*.jpg, *.jpeg)|*.jpg; *.jpeg";
            openFile.FilterIndex = 3;
            openFile.RestoreDirectory = true;
            openFile.Title = "Odaberite sliku za prikaz na displeju.";

            if (openFile.ShowDialog() == DialogResult.OK) {
                try {
                    if ((stream = openFile.OpenFile()) != null) {
                        Bitmap slika = new Bitmap(openFile.FileName);
                        Bitmap smanjenaSlika = Konverzije.Resize(slika);

                        using (Graphics gr = Graphics.FromImage(smanjenaSlika)) {
                            var gray_matrix = new float[][] {
                                new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                                new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                                new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                                new float[] { 0,      0,      0,      1, 0 },
                                new float[] { 0,      0,      0,      0, 1 } };

                            var ia = new System.Drawing.Imaging.ImageAttributes();
                            ia.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(gray_matrix));
                            ia.SetThreshold(0.7f); // Change this threshold as needed
                            var rc = new Rectangle(0, 0, smanjenaSlika.Width, smanjenaSlika.Height);
                            gr.DrawImage(smanjenaSlika, rc, 0, 0, smanjenaSlika.Width, smanjenaSlika.Height, GraphicsUnit.Pixel, ia);
                        }

                        niz = Konverzije.ConvertToByteArray(smanjenaSlika);

                        var image = Konverzije.ConvertToBitmap(niz);
                        pb_slika.Image = image;
                        toolStripStatusLabel1.Text = "Uspješno učitana slika.";
                        btn_posaljiSliku.Enabled = true;
                    }
                } catch (Exception ex) {
                    toolStripStatusLabel1.Text = "Greska: nije moguce učitati datoteku. [" + ex.Message + "]";
                }
            }
        }
        private void btn_posaljiSliku_Click(object sender, EventArgs e) {

            serialPort.Write("1");

            buffer = new char[84][];
            for (int i = 0; i < 84; i++) {
                buffer[i] = new char[6];
            } 

            //ova petlja šalje niz od 6 bajtova na serijski port
            for (int i = 0; i < 84; i++) {
                for (int j = 0; j < 6; j++) {
                    serialPort.Write(((char)niz[i][j]).ToString());
                    //buffer[i][j] = (char)niz[i][j];
                }
            }

            toolStripStatusLabel1.Text = "Slika poslana.";
            btn_urediSliku.Enabled = true;
        }

        private void btn_urediSliku_Click(object sender, EventArgs e) {

            serialPort.Write("2");

            if (!edit) {
                toolStripStatusLabel1.Text = "Uređivanje slike omogućeno.";
            } else {
                toolStripStatusLabel1.Text = "Uređivanje slike onemogućeno.";
            }

            edit = !edit;
            btn_ucitajSliku.Enabled = true;
        }

        private void btn_ucitajSliku_Click(object sender, EventArgs e) {

            serialPort.Write("3");
            serialPort.DiscardInBuffer();
            //buffer[5][3] = (char)1; //simulira edit na lpc

            try {
                //ova petlja čita podatke sa serijskog porta bajt po bajt
                for (int i = 0; i < 84; i++) {
                    for (int j = 0; j < 6; j++) {
                        niz[i][j] = (byte)serialPort.ReadByte();
                        //niz[i][j] = (byte)buffer[i][j];
                    }
                }
                toolStripStatusLabel1.Text = "Slika uspjesno učitana.";
                pb_slika.Image = Konverzije.ConvertToBitmap(niz);
                btn_posaljiSliku.Enabled = false;
                btn_urediSliku.Enabled = false;
                btn_ucitajSliku.Enabled = false;
            } catch (Exception ex) {
                toolStripStatusLabel1.Text = "Greska prilikom citanja slike. [" + ex.Message + "]";
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            serialPort.Close();
        }

        private void Form1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
        }

        private void cb_comPorts_SelectedIndexChanged(object sender, EventArgs e) {
            serialPort = openSerialPort(cb_comPorts.Text);
        }
    }
}

