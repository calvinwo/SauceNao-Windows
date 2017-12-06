using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceNao_Windows.Sauces
{
    public class Seiga : Sauce
    {
        static string ENDPOINT = "http://seiga.nicovideo.jp/seiga/im";
        public new string Url
        {
            get { return GetUrl(); }
        }

        public Seiga(dynamic data) : base((string) data.title, (int) data.seiga_id, (string) data.member_name, (int) data.member_id) { }

        public override string ToString()
        {
            return String.Format("Title: {0}\nSeiga ID: {1}\nAuthor: {2} (#{3})\nURL: {4}", Title, SauceId, AuthorName, AuthorId, Url);
        }

        protected override string GetUrl()
        {
            return ENDPOINT + SauceId;
        }

        public new static bool IsTheRightAdapterFor(dynamic data)
        {
            return data.seiga_id != null;
        }
    }
}
