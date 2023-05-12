using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}: Start Server");

var socketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
var localEndPoint = new IPEndPoint(IPAddress.Any, 1234);
socketListener.Bind(localEndPoint);

socketListener.Listen(10);
Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}: Esperando conexiones...");

var clientSocket = socketListener.Accept();
Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}: Conexión establecida!");

var bytes = new byte[1024];
var bytesRec = clientSocket.Receive(bytes);
var message = Encoding.ASCII.GetString(bytes, 0, bytesRec);
Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}: Mensaje recibido: {message}");

Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}: Close Server");
clientSocket.Shutdown(SocketShutdown.Both);
clientSocket.Close();
socketListener.Close();