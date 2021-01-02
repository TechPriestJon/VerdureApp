using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Realms;
using Verdure.Domain.Realm;

namespace Verdure.WinForm
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //var config = new RealmConfiguration("/myYXPHFGAN.realm")
            //{   };
            //var localRealm = Realm.GetInstance(config);

            //var mongotest = new MongoTest()
            //{
            //    Name = "Do this thing2",
            //    Status = Domain.Realm.TaskStatus.Open.ToString(),
            //    //ListOfNumbers = new List<int>() { 2, 5, 17 }
            //};

            //var mongotest2 = new MongoTest()
            //{
            //    Name = "Another Thing2",
            //    Status = Domain.Realm.TaskStatus.Complete.ToString()
            //};


            //localRealm.Write(() =>
            //{
            //    localRealm.Add(mongotest);
            //    localRealm.Add(mongotest2);
            //});


            //var tasks = localRealm.All<MongoTest>();



            Application.Run(new Form1());

        }
    }
}
