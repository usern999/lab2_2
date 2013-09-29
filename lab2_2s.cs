using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using lab2_0;

namespace lab2_2
{
    class lab2_2s
    {
        static void Main(string[] args)
        {
            SKIF();
            Console.Read();

        }

        private static void SKIF()
        {
            FileSystemWatcher Watcher = new FileSystemWatcher();
            Console.WriteLine("Введите имя каталога");
            Watcher.Path = Console.ReadLine();
            Watcher.Filter = "*.*";
            
            Watcher.Created += new FileSystemEventHandler(OnCreate);
            Watcher.Deleted += new FileSystemEventHandler(OnCreate);
            Watcher.Changed += new FileSystemEventHandler(OnChange);
            Watcher.EnableRaisingEvents=true;

        }

        private static void OnCreate(object source, FileSystemEventArgs e)
        {
            Consolelogger Clog = new Consolelogger();
            WatcherChangeTypes wct = e.ChangeType;
            Clog.Log(Severity.Error, wct.ToString()+"  "+e.Name);
        }

        private static void OnChange(object source, FileSystemEventArgs e)
        {
            Consolelogger Clog = new Consolelogger();
            WatcherChangeTypes wct = e.ChangeType;
            Clog.Log(Severity.Warning, wct.ToString()+"  "+e.Name);
        }
    }
}
