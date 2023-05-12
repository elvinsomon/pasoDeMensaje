using System.Net;
using System.Net.Sockets;
using System.Text;

Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 1234);
listener.Bind(localEndPoint);

listener.Listen(10);

Console.WriteLine("Esperando conexiones...");

Socket clientSocket = listener.Accept();

Console.WriteLine("Conexión establecida!");

byte[] bytes = new byte[1024];

int bytesRec = clientSocket.Receive(bytes);

string message = Encoding.ASCII.GetString(bytes, 0, bytesRec);

Console.WriteLine("Mensaje recibido: {0}", message);

clientSocket.Shutdown(SocketShutdown.Both);
clientSocket.Close();
listener.Close();