using System.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using MESSAGE;
namespace server
{
    public partial class Form1 : Form
    {
        IPEndPoint iep ;
        Socket server ;
        Dictionary<string, string> DS;
        Dictionary<string, List<string>> DSNhom;
        Dictionary<string, Socket> DSClient;
        
        bool active = false;
        private void KhoiTaoUser()
        {
            DS = new Dictionary<string, string>();
            DSNhom = new Dictionary<string, List<string>>();
            char u;
            for(u='A';u<'Z';u++)
                DS.Add(u.ToString(), "123");
            for(byte i = 0; i < 5; i++)
            {
                List<string> nhom = new List<string>();
                for(byte j = 0; j < 3; j++)
                {
                    u = (Char)('A'+3 * i + j);
                    nhom.Add(u.ToString());
                }
                DSNhom.Add("N"+i.ToString(), nhom);
            }
            DSClient = new Dictionary<string, Socket>();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            //Console.WriteLine(hostName);
            // Get the IP
            foreach(IPAddress ip in Dns.GetHostByName(hostName).AddressList)
            {
                if(ip.ToString().Contains("."))
                {
                    IP.Text = ip.ToString();
                    break;
                }
            }
            KhoiTaoUser();
        }
        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            KQ.Text += value;
        }
        private  void sendJson(Socket client,object obj)
        {
            byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(obj);
            client.Send(jsonUtf8Bytes, jsonUtf8Bytes.Length, SocketFlags.None);
        }
        private void ThreadClient(Socket client)
        {            
            byte[] data = new byte[1024];
            int recv = client.Receive(data);
            if (recv == 0) return;
            string jsonString = Encoding.ASCII.GetString(data, 0, recv);
            
            MESSAGE.COMMON? com = JsonSerializer.Deserialize<MESSAGE.COMMON>(jsonString);
            if (com!=null )
            {
                if(com.content!=null)
                {
                    switch (com.kind)
                    {
                        case 1:
                            { 
                            LOGIN? login = JsonSerializer.Deserialize<LOGIN>(com.content);
                            if (login != null && login.username != null && DS.Keys.Contains(login.username) && login.pass == DS[login.username])
                            {
                                com = new COMMON(3, "OK");
                                sendJson(client, com);
                                DSClient.Remove(login.username);
                                DSClient.Add(login.username, client);
                            }
                            else
                            {
                                com = new COMMON(3, "CANCEL");
                                sendJson(client, com);
                                return;
                            }
                            break;
                            }
                        case 5:
                            {
                                LOGIN? login = JsonSerializer.Deserialize<LOGIN>(com.content);
                                if (login != null && login.username != null && !DS.Keys.Contains(login.username))
                                {
                                    DS.Add(login.username, login.pass);
                                    com = new COMMON(3, "OK");
                                    sendJson(client, com);                                    
                                }
                                else
                                {
                                    com = new COMMON(3, "CANCEL");
                                    sendJson(client, com);
                                    return;
                                }
                            }
                            
                            break;
                    }
                    
                }
                else
                {
                    com = new COMMON(3, "CANCEL");
                    sendJson(client, com);                    
                    return;
                }                
            }
            try
            {
                bool tieptuc = true;
                while (tieptuc)
                {
                    data = new byte[1024 * 5000];
                    recv = client.Receive(data);
                    if (recv == 0) continue;
                    string s = Encoding.ASCII.GetString(data, 0, recv);
                    if (s.ToUpper().Equals("QUIT")) break;
                    com = JsonSerializer.Deserialize<MESSAGE.COMMON>(s);

                    if (com != null && com.content != null)
                    {
                        switch (com.kind)
                        {
                            case 2:
                                MESSAGE.MESSAGE? mes = JsonSerializer.Deserialize<MESSAGE.MESSAGE>(com.content);
                                if (mes != null && mes.usernameReceiver != null)
                                {
                                    if (DSClient.Keys.Contains(mes.usernameReceiver))
                                    {
                                        AppendTextBox(mes.usernameSender + " send to " + mes.usernameReceiver + " content: " + mes.content + Environment.NewLine);
                                        Socket friend = DSClient[mes.usernameReceiver];
                                        friend.Send(data, recv, SocketFlags.None);
                                    }
                                    else//Nhom
                                    {
                                        if (DSNhom.Keys.Contains(mes.usernameReceiver)) 
                                        {
                                            if (DSNhom[mes.usernameReceiver].Contains(mes.usernameSender))
                                            {
                                                AppendTextBox(mes.usernameSender + " send to " + mes.usernameReceiver + " content: " + mes.content + Environment.NewLine);
                                                foreach (String user in DSNhom[mes.usernameReceiver])
                                                {
                                                    if (DSClient.Keys.Contains(user))
                                                    {
                                                        Socket friend = DSClient[user];
                                                        friend.Send(data, recv, SocketFlags.None);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                com = new COMMON(10, "CANCEL");
                                                sendJson(client, com);
                                            }
                                        }
                                        else
                                        {
                                            com = new COMMON(11, "CANCEL");
                                            sendJson(client, com);
                                        }

                                    }
                                }
                                break;
                            case 4:
                                DSClient[com.content].Close();
                                DSClient.Remove(com.content);
                                tieptuc = false;
                                break;
                            case 6:
                                {

                                    if (!DSNhom.Keys.Contains(com.content))
                                    {
                                        DSNhom.Add(com.content, new List<string>());
                                        com = new COMMON(8, "OK");
                                        sendJson(client, com);
                                    }
                                    else
                                    {
                                        com = new COMMON(8, "CANCEL");
                                        sendJson(client, com);
                                        //return;
                                        
                                    }
                                }
                                break;
                            case 7:
                                {
                                    MESSAGE.ADDNHOM? obj = JsonSerializer.Deserialize<MESSAGE.ADDNHOM>(com.content);
                                    if (!DSNhom.Keys.Contains(obj.GrpName))
                                    {
                                        com = new COMMON(9, "CANCEL");
                                        sendJson(client, com);
                                        return;
                                        
                                    }                                    
                                    else 
                                    {
                                        foreach(var user in obj.members)
                                            if (!DS.Keys.Contains(user))
                                            {
                                                com = new COMMON(9, "CANCEL");
                                                sendJson(client, com);
                                                return;
                                            }
                                        foreach (var user in obj.members)
                                        {
                                            if (!DSNhom[obj.GrpName].Contains(user))                                            
                                                    DSNhom[obj.GrpName].Add(user);
                                        }
                                        
                                        //DSNhom.Add(com.content, new List<string>());
                                        com = new COMMON(9, "OK");
                                        sendJson(client, com);
                                    }
                                }
                                break;
                            case 8:
                                {
                                    MESSAGE.FILE? obj = JsonSerializer.Deserialize<MESSAGE.FILE>(com.content);
                                    if (DSClient.Keys.Contains(obj.usernameReceiver))
                                    {
                                        
                                        string path = "D:/LapTrinhMang/DoAn/NhanFile_server";

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
                                        BinaryWriter bWrite = new BinaryWriter(File.Open(path + "/" + fileName, FileMode.Create));
                                        bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);
                                        bWrite.Close();

                                        AppendTextBox(obj.usernameSender + " send a file to " + obj.usernameReceiver + " content: " + fileName + Environment.NewLine);
                                        //Gửi cho người nhận
                                        MESSAGE.FILE file = new MESSAGE.FILE(obj.usernameSender, obj.usernameReceiver, clientData);
                                        string datagui = JsonSerializer.Serialize(file);
                                        com = new COMMON(12, datagui);
                                        Socket friend = DSClient[obj.usernameReceiver];
                                        byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(com);
                                        friend.Send(jsonUtf8Bytes, jsonUtf8Bytes.Length, SocketFlags.None);
                                    }
                                    else//Nhom
                                    {
                                        if (DSNhom.Keys.Contains(obj.usernameReceiver))
                                        {
                                            if (DSNhom[obj.usernameReceiver].Contains(obj.usernameSender))
                                            {

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
                                                string path = "D:/LapTrinhMang/DoAn/NhanFile_server";
                                                BinaryWriter bWrite = new BinaryWriter(File.Open(path + "/" + fileName, FileMode.Create));
                                                bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);
                                                bWrite.Close();

                                                MESSAGE.FILE file = new MESSAGE.FILE(obj.usernameSender, obj.usernameReceiver, clientData);
                                                string datagui = JsonSerializer.Serialize(file);
                                                com = new COMMON(12, datagui);
                                                byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(com);
                                                AppendTextBox(obj.usernameSender + " send file to Group " + obj.usernameReceiver + " content: " + fileName + Environment.NewLine);
                                                foreach (String user in DSNhom[obj.usernameReceiver])
                                                {
                                                 
                                               
                                                    if (DSClient.Keys.Contains(user))
                                                    {
                                                        Socket friend = DSClient[user];
                                                        friend.Send(jsonUtf8Bytes, jsonUtf8Bytes.Length, SocketFlags.None);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                com = new COMMON(10, "CANCEL");
                                                sendJson(client, com);
                                            }
                                        }
                                        else
                                        {
                                            com = new COMMON(11, "CANCEL");
                                            sendJson(client, com);
                                        }

                                    }



                                    //Phản hồi về người gửi
                                    /*  com = new COMMON(9, "OK");
                                      sendJson(client, com);*/

                                }
                                break;



                        }
                    }
                }
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception)
            {
                //server.Close();
            }

        }
        private void ThreadTask()
        {
            while (active)
            {
                try
                {
                    Socket client = server.Accept();                   
                    var t = new Thread(() => ThreadClient(client));
                    t.Start();
                }
                catch (Exception)
                {
                    active = false;
                }
                               
            }
            
            
            
            
        }
        private void Start_Click(object sender, EventArgs e)
        {
            active = true;
            iep = new IPEndPoint(IPAddress.Parse(IP.Text), int.Parse(PORT.Text));
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
            server.Bind(iep);
            server.Listen(10);
            //Console.WriteLine("Cho  ket  noi  tu  client");
            KQ.Text += "Cho  ket  noi  tu  client" + Environment.NewLine;
            
            
            Thread trd = new Thread(new ThreadStart(this.ThreadTask));
            trd.IsBackground = true;
            trd.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            active = false;
        }
    }
}