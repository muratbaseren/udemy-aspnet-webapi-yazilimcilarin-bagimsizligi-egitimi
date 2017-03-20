using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace UdemyWebApiEgitimi.DependencyInjection.Models
{
    public class Creator
    {
        private Creator()
        {

        }

        public static Bildirim CreateBildirimInstance()
        {
            return new Bildirim(new SmsBildirim());
        }
    }


    public class Bildirim
    {
        private IBildirim _bildirim;

        public Bildirim(IBildirim bildirim)
        {
            _bildirim = bildirim;
        }

        public void Yap()
        {
            _bildirim.Gonder();

            Debug.WriteLine("Bildirim yapıldı.");
        }

        public void Yap2()
        {
            _bildirim.Gonder();

            Debug.WriteLine("Bildirim yapıldı.");
        }
    }

    public interface IBildirim
    {
        void Gonder();
    }


    public class EPostaBildirim : IBildirim
    {
        public void Gonder()
        {
            Debug.WriteLine("E-posta gönderildi.");
        }
    }

    public class SmsBildirim : IBildirim
    {
        public void Gonder()
        {
            Debug.WriteLine("SMS gönderildi.");
        }
    }
}