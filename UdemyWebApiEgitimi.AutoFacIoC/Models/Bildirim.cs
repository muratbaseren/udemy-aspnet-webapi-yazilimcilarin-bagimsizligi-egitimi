using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace UdemyWebApiEgitimi.AutoFacIoC.Models
{

    public class BildirimManager
    {
        private IBildirim _bildirim;

        public BildirimManager(IBildirim bildirim)
        {
            _bildirim = bildirim;
        }

        public void BildirimYap()
        {
            _bildirim.Gonder();
        }

        public void BildirimYap2()
        {
            _bildirim.Gonder();
        }
    }

    public interface IBildirim
    {
        void Gonder();
    }

    public class EPostaBildirimi : IBildirim
    {
        private int counter = 0;

        public void Gonder()
        {
            counter++;
            Debug.WriteLine($"E-posta bildirimi gönderildi. counter => {counter}");
        }
    }

    public class SmsBildirimi : IBildirim
    {
        private int counter = 0;

        public void Gonder()
        {
            counter++;
            Debug.WriteLine($"SMS bildirimi gönderildi. counter => {counter}");
        }
    }
}