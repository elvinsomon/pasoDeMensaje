using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Inicio Cliente");

Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1234);

sender.Connect(remoteEP);

Console.WriteLine("Conexión establecida!");

byte[] msg = Encoding.ASCII.GetBytes("Hola, servidor!");
sender.Send(msg);

sender.Shutdown(SocketShutdown.Both);
sender.Close();
