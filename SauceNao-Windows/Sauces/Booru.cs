using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceNao_Windows.Sauces
{
    public class Booru : Sauce
    {
        static string DANBOORUENDPOINT = "https://danbooru.donmai.us/post/show/";
        static string GELBOORUENDPOINT = "https://gelbooru.com/index.php?page=post&s=view&id=";
        static string SANKAKUENDPOINT = "https://chan.sankakucomplex.com/post/show/";
        static string YANDEREENDPOINT = "https://yande.re/post/show/";
        private int danbooruId = 0, gelbooruId = 0, sankakuId = 0, yandereId = 0;
        public new string Url
        {
            get { return GetUrl(); }
        }

        public string DanbooruUrl
        {
            get { return (danbooruId != 0 ? DANBOORUENDPOINT + danbooruId : ""); }
        }

        public string GelbooruUrl
        {
            get { return (gelbooruId != 0 ?GELBOORUENDPOINT + gelbooruId : ""); }
        }

        public string SankakuUrl
        {
            get { return (sankakuId != 0 ? SANKAKUENDPOINT + sankakuId : ""); }
        }

        public string YandereUrl
        {
            get { return (yandereId != 0 ? YANDEREENDPOINT + yandereId : ""); }
        }

        public string Source = "";
        public string Creator = "";

        public Booru(dynamic data) : base()
        {
            if(data.creator != null)
            {
                Creator = (string) data.creator;
            }
            if(data.source != null)
            {
                Source = (string) data.source;
            }
            if(data.danbooru_id != null)
            {
                danbooruId = (int) data.danbooru_id;
            }
            if (data.gelbooru_id != null)
            {
                gelbooruId = (int) data.gelbooru_id;
            }
            if (data.sankaku_id != null)
            {
                sankakuId = (int) data.sankaku_id;
            }
            if (data.yandere_id != null)
            {
                yandereId = (int) data.yandere_id;
            }
        }

        public override string ToString()
        {
            return String.Format("ID: {0}\nURL: {1}", GetID(), GetUrl());
        }
        
        public int GetID()
        {
            return (danbooruId != 0 ? danbooruId :
                gelbooruId != 0 ? gelbooruId :
                sankakuId != 0 ? sankakuId :
                yandereId != 0 ? yandereId : 0);
        }

        protected override string GetUrl()
        {
            return (!String.IsNullOrWhiteSpace(DanbooruUrl) ? DanbooruUrl :
                !String.IsNullOrWhiteSpace(GelbooruUrl) ? GelbooruUrl :
                !String.IsNullOrWhiteSpace(SankakuUrl) ? SankakuUrl :
                !String.IsNullOrWhiteSpace(YandereUrl) ? YandereUrl : "");
        }

        public new static bool IsTheRightAdapterFor(dynamic data)
        {
            return data.danbooru_id != null ||
                data.gelbooru_id != null ||
                data.sankaku_id != null ||
                data.yandere_id != null ||
                data.anime_pictures_id != null;
        }
    }
}
