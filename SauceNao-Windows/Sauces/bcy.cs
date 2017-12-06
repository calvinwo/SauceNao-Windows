using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceNao_Windows.Sauces
{
    class bcy : Sauce
    {
        static string ILLUSTENDPOINT = "http://bcy.net/illust/detail/";
        private int MemberLinkId;
        private string Type;
        public new string Url
        {
            get { return GetUrl(); }
        }

        public bcy(dynamic data) : base((string) data.title, (int) data.bcy_id, (string) data.member_name, (int) data.member_id)
        {
            MemberLinkId = (int)data.member_link_id;
            Type = (string)data.bcy_type;
        }

        public override string ToString()
        {
            return String.Format("Title: {0}\nMugimugi ID: {1}\nAuthor: {2} (#{3})\nURL: {4}", Title, SauceId, AuthorName, AuthorId, Url);
        }

        protected override string GetUrl()
        {
            return $"{ILLUSTENDPOINT}/{MemberLinkId}/{SauceId}";
        }

        public new static bool IsTheRightAdapterFor(dynamic data)
        {
            return data.bcy_id != null;
        }
    }
}
