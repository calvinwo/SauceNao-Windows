using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceNao_Windows.Sauces
{
    class Mugimugi : Sauce {
        static string ENDPOINT = "https://www.doujinshi.org/index.php?P=BOOK&ID=";
        public new string Url
        {
            get { return GetUrl(); }
        }

        public Mugimugi(dynamic data) : base((string) data.title, (int) data.ddb_id, (string) data.member_name, (int) data.member_id) { }

        public override string ToString()
        {
            return String.Format("Title: {0}\nMugimugi ID: {1}\nAuthor: {2} (#{3})\nURL: {4}", Title, SauceId, AuthorName, AuthorId, Url);
        }

        protected override string GetUrl()
        {
            return ENDPOINT + SauceId;
        }

        public new static bool IsTheRightAdapterFor(dynamic data)
        {
            return data.ddb_id != null;
        }
    }
}
