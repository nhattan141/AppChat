﻿namespace MESSAGE
{
    public class COMMON
    {
        public COMMON(int kind, string? content)
        {
            this.kind = kind;
            this.content = content;
        }
        public int kind { get; set; }
        public string? content { get; set; }
    }
    public class FILE
    {
        public FILE(string? usernameSender, string? usernameReceiver,byte[]? file)
        {
            this.usernameSender = usernameSender;
            this.usernameReceiver = usernameReceiver;
            this.file = file;
        }
        public string? usernameSender { get; set; }
        public string? usernameReceiver { get; set; }
        public byte[]? file { get; set; }

    }
    public class LOGIN
    {
        public LOGIN(string ? username, string? pass)
        {
            this.username = username;
            this.pass = pass;
        }
        public string? username { get; set; }
        public string? pass { get; set; }
    }
    public class MESSAGE
    {
        public MESSAGE(string? usernameSender, string? usernameReceiver, string? content)
        {
            this.usernameSender = usernameSender;
            this.usernameReceiver = usernameReceiver;
            this.content = content;
        }
        public string? usernameSender { get; set; }
        public string? usernameReceiver { get; set; }
        public string? content { get; set; }
    }
    public class ADDNHOM
    {
        public ADDNHOM(string? GrpName, List<string>? members)
        {
            this.GrpName = GrpName;
            this.members = members;
        }
        public string? GrpName { get; set; }
        public List<string>? members { get; set; }
    }

}