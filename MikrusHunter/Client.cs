using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace MikrusHunter
{
    class Client
    {
        public void getFile(string path)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(path, "file.txt");
            }
        }

        public bool checkForServer()
        {
            var sr = new StreamReader("file.txt");
            
            while (sr.Peek() >= 0){
                string text = sr.ReadLine();
                string[] textSplited = text.Split(';');
                List<string> textWithRemovedData = new List<string>();

                textWithRemovedData.Add(textSplited[1]);
                textWithRemovedData.Add(textSplited[3]);
                try {
                    if (textWithRemovedData[0] == "3.0" && int.Parse(textWithRemovedData[1].Substring(4)) > 180)
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
                     
            }
            return false;
        }
    }
}
