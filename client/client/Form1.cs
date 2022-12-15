using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using MESSAGE;
namespace client
{
    public partial class Form1 : Form
    {
        IPEndPoint iep;
        Socket server;
        Socket client;
        bool thoat = false;
        Thread trd;
        Thread trd1;
        public Form1()
        {
            InitializeComponent();
        }
        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                try { this.Invoke(new Action<string>(AppendTextBox), new object[] { value }); }
                catch (Exception) { }
                return;
            }
            KQ.Text += value+Environment.NewLine;
        }
        public void ChangeAttribute(Button btn, bool value)
        {
            btn.BeginInvoke(new MethodInvoker(() =>
            {
                btn.Enabled = value;
            }));
        }
        private void sendJson(object obj)
        {
            byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(obj);
            client.Send(jsonUtf8Bytes, jsonUtf8Bytes.Length, SocketFlags.None);
        }
        private void ThreadTask()
        {
            byte[] data = new byte[1024 * 5000];
            MESSAGE.LOGIN login = new MESSAGE.LOGIN(UserName.Text, Pass.Text);
            
            string jsonString = JsonSerializer.Serialize(login);
            
            MESSAGE.COMMON common = new MESSAGE.COMMON(1, jsonString);            
            sendJson(common);            
            int recv = client.Receive(data);
            
            jsonString = Encoding.ASCII.GetString(data, 0, recv);
            jsonString.Replace("\\u0022", "\"");
            MESSAGE.COMMON? com =JsonSerializer.Deserialize<MESSAGE.COMMON>(jsonString);
            try
            {
                if (com != null && com.kind == 3 )
                {
                    if (com.content == "OK" )
                    {
                        MessageBox.Show("Login success!");
                        ChangeAttribute(Connect, false);
                        ChangeAttribute(Logout, true);
                        while (!thoat)
                        {
                            data = new byte[1024 * 5000];
                            recv = client.Receive(data);

                            jsonString = Encoding.ASCII.GetString(data, 0, recv);
                            //jsonString=jsonString.Replace("\\u0022", "\"");
                            //jsonString = jsonString.Replace("\0", "");
                            com = JsonSerializer.Deserialize<MESSAGE.COMMON>(jsonString);
                           
                            if (com != null )
                            {
                                switch(com.kind)
                                {
                                    case 2:
                                        MESSAGE.MESSAGE? mes = JsonSerializer.Deserialize<MESSAGE.MESSAGE>(com.content);
                                        AppendTextBox(mes.usernameSender + ":" + mes.content);
                                        break;
                                    case 8:
                                        
                                        if (com.content == "OK")
                                            MessageBox.Show("Create Group success!");
                                        else MessageBox.Show("Create Group fail!");
                                        break;
                                    case 9:

                                        if (com.content == "OK")
                                            MessageBox.Show("Add members success!");
                                        else MessageBox.Show("Add members fail!");
                                        break;
                                    case 10:

                                        if (com.content == "CANCEL")
                                            MessageBox.Show("User not in group!");                                        
                                        break;
                                    case 11:

                                        if (com.content == "CANCEL")
                                            MessageBox.Show("No group!");
                                        break;
                                    case 12:
                                        MESSAGE.FILE? obj = JsonSerializer.Deserialize<MESSAGE.FILE>(com.content);
                                        if (MessageBox.Show( obj.usernameSender+" đã gửi một file cho bạn , bạn có muốn nhận không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            string path = "D:/LapTrinhMang/DoAn/NhanFile_client";
                                            byte[] clientData = new byte[1024 * 5000];
                                            clientData = obj.file;
                                            int receivedBytesLen = clientData.Length;
                                            int fileNameLen = BitConverter.ToInt32(clientData, 0);
                                            string fileName = Encoding.ASCII.GetString(clientData, 4, fileNameLen);
                                            fileName = fileName.Replace("\\", "/");
                                            while (fileName.IndexOf("/") > -1)
                                            {
                                                fileName = fileName.Substring(fileName.IndexOf("/") + 1);
                                            }
                                            string link = path + "/" + fileName; 
                                            BinaryWriter bWrite = new BinaryWriter(File.Open(link, FileMode.Create));
                                            bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);
                                            bWrite.Close();
                                            AppendTextBox(obj.usernameSender + " send a file to " + obj.usernameReceiver + " Path: " + path + "/" + fileName + Environment.NewLine);
                                        }

                                        break;
                                }
                                
                            }
                            
                           

                        }
                    }
                    else MessageBox.Show("Login fail!");
                }
                client.Disconnect(true);
                client.Close();
            }
            catch (Exception)
            {

            }
            
        }
        private void ThreadRegister()
        {
            byte[] data = new byte[1024];
            MESSAGE.LOGIN login = new MESSAGE.LOGIN(UserName.Text, Pass.Text);

            string jsonString = JsonSerializer.Serialize(login);

            MESSAGE.COMMON common = new MESSAGE.COMMON(5, jsonString);
            sendJson(common);
            int recv = client.Receive(data);

            jsonString = Encoding.ASCII.GetString(data, 0, recv);
            //jsonString.Replace("\\u0022", "\"");
            MESSAGE.COMMON? com = JsonSerializer.Deserialize<MESSAGE.COMMON>(jsonString);

            try
            {
                if (com != null && com.kind == 3)
                {
                    if (com.content == "OK")
                    {
                        MessageBox.Show("Register success!");                        
                    }
                    else MessageBox.Show("Register fail!");
                }
                client.Disconnect(true);
                client.Close();
            }
            catch (Exception)
            {

            }
        }
        private void Connect_Click(object sender, EventArgs e)
        {
            iep = new IPEndPoint(IPAddress.Parse(IP.Text), int.Parse(PORT.Text));
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
            client.Connect(iep);
            trd = new Thread(new ThreadStart(this.ThreadTask));
            trd.IsBackground = true;
            trd.Start();

        }

        private void Send_Click(object sender, EventArgs e)
        {

            MESSAGE.MESSAGE mes = new MESSAGE.MESSAGE(UserName.Text, receiver.Text, message.Text);
            //var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(mes);
            MESSAGE.COMMON common = new MESSAGE.COMMON(2, jsonString);
            sendJson(common);

            
            if (message.Text.ToUpper().Equals("QUIT"))
            {
                thoat = true;
                Close();
            }
                
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                if (trd != null)
                    trd.Abort();
            }
            catch (Exception)
            {

            }
            
            thoat = true;
        }

        private void Logout_Click(object sender, EventArgs e)
        {            
            MESSAGE.COMMON common = new MESSAGE.COMMON(4, UserName.Text);
            sendJson(common);
            ChangeAttribute(Connect, true);
            ChangeAttribute(Logout, false);
        }

        private void Register_Click(object sender, EventArgs e)
        {
            
            iep = new IPEndPoint(IPAddress.Parse(IP.Text), int.Parse(PORT.Text));
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(iep);
            ThreadRegister();
            //trd1 = new Thread(new ThreadStart(this.ThreadRegister));
            //trd1.IsBackground =  true;
            //trd1.Start();
        }

        private void CreateGroup_Click(object sender, EventArgs e)
        {
            
            MESSAGE.COMMON common = new MESSAGE.COMMON(6, GRP.Text);
            sendJson(common);

        }

        private void Add_Click(object sender, EventArgs e)
        {
            string[] mang = Members.Text.Split(",");
            List<string> l = new List<string>();
            foreach (string user in mang)
                l.Add(user);
            MESSAGE.ADDNHOM mes = new MESSAGE.ADDNHOM(GRP.Text, l);
            string jsonString = JsonSerializer.Serialize(mes);
            MESSAGE.COMMON common = new MESSAGE.COMMON(7, jsonString);
            sendJson(common);            
            
        }

        private void sendfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                namepath.Text = filePath;
                //textBox2.Text = Path.GetFileName(openFileDialog.FileName);
                var fileStream = openFileDialog.OpenFile();
                string path = "";
                filePath = filePath.Replace("\\", "/");
                while (filePath.IndexOf("/") > -1)
                {
                    path += filePath.Substring(0, filePath.IndexOf("/") + 1);
                    filePath = filePath.Substring(filePath.IndexOf("/") + 1);
                }
                string fileName = filePath;// "c:\\filetosend.txt";
                byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);
                byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                byte[] fileData = File.ReadAllBytes(path + fileName);
                byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
                if (clientData.Length > 1024 * 5000)
                {
                    MessageBox.Show(" Kích thước file không được lớn hơn 5mb ");
                }
                else
                {
                    fileNameLen.CopyTo(clientData, 0);
                    fileNameByte.CopyTo(clientData, 4);
                    fileData.CopyTo(clientData, 4 + fileNameByte.Length);
                    MESSAGE.FILE file = new MESSAGE.FILE(UserName.Text, receiver.Text, clientData);
                    string jsonString = JsonSerializer.Serialize(file);
                    MESSAGE.COMMON common = new MESSAGE.COMMON(8, jsonString);
                    sendJson(common);
                }
            }
        }
    }
}