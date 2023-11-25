﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

class MyTcpListener
{

    public static void Main()
    {


        TcpListener server;

        try
        {

            // Set the TcpListener on port 3600.
            Int32 port = 3600;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // TcpListener server = new TcpListener(port);
            server = new TcpListener(localAddr, port);

            // Start listening for client requests.
            server.Start();

            // Buffer for reading data
            Byte[] bytes = new Byte[256];

            // Enter the listening loop.
            while (true)
            {
                Console.Write("Waiting for a connection... ");

                // Perform a blocking call to accept requests.
                // You could also use server.AcceptSocket() here.
                using TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");


                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                /*
                int i;

                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);

                    // Process the data sent by the client.
                    data = data.ToUpper();

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);
                }*/

                // open random file from Directory
                string[] files = Directory.GetFiles("");
                Random rnd = new Random();
                int r = rnd.Next(files.Length);
                string file = files[0];
                Console.WriteLine("File: {0}", file);



                // open the file and read the in the file
                string text = File.ReadAllText(file);

                // read the second line of the file
                string[] lines = File.ReadAllLines(file);
                string line = lines[1];

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(line);


                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("Sent: {0}", msg);

            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }

        Console.WriteLine("\nHit enter to continue...");
        Console.Read();
    }
}