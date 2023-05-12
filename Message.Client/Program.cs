using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}: Start Client");

var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

var ipAddress = IPAddress.Parse("127.0.0.1");
var endPoint = new IPEndPoint(ipAddress, 1234);

socket.Connect(endPoint);

Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}: Conexión establecida!");

var msg = Encoding.ASCII.GetBytes("Hola, servidor! Este es un mensaje desde el cliente");
socket.Send(msg);

// Close Client
Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}: Close Client");
socket.Shutdown(SocketShutdown.Both);
socket.Close();
