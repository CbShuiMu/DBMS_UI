using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Text;
using System.Threading;

public class PipeClient
{

    private static int numClients = 1;

    //创建管道，发送指令并返回值
    public static string MainSend(string s)
    {
        var pipeClient =
            new NamedPipeClientStream(".", "testpipe",
                PipeDirection.InOut, PipeOptions.None,
                TokenImpersonationLevel.Impersonation);

        pipeClient.Connect();

        var ss = new StreamString(pipeClient);
        // Validate the server's signature string.
        string receive = null;
        if (ss.ReadString() == "I am the one true server!")
        {

            //客户端发送数据
            ss.WriteString(s);

            //客户端接受信息
            receive = ss.ReadString();

            // The client security token is sent with the first write.
            // Send the name of the file whose contents are returned
            // by the server.
            //ss.WriteString("D:\\textfile.txt");
        }
        else
        {
            Console.WriteLine("Server could not be verified.");
        }
        pipeClient.Close();

        return receive;
    }



}

public class StreamString
{
    private Stream ioStream;
    private UnicodeEncoding streamEncoding;

    public StreamString(Stream ioStream)
    {
        this.ioStream = ioStream;
        streamEncoding = new UnicodeEncoding();
    }

    public string ReadString()
    {
        int len;
        len = ioStream.ReadByte() * 256;
        len += ioStream.ReadByte();
        var inBuffer = new byte[len];
        ioStream.Read(inBuffer, 0, len);

        return streamEncoding.GetString(inBuffer);
    }

    public int WriteString(string outString)
    {
        byte[] outBuffer = streamEncoding.GetBytes(outString);
        int len = outBuffer.Length;
        if (len > UInt16.MaxValue)
        {
            len = (int)UInt16.MaxValue;
        }
        ioStream.WriteByte((byte)(len / 256));
        ioStream.WriteByte((byte)(len & 255));
        ioStream.Write(outBuffer, 0, len);
        ioStream.Flush();

        return outBuffer.Length + 2;
    }
}
