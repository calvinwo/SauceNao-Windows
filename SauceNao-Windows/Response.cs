﻿using SauceNao_Windows.Sauces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceNao_Windows {
  public class Response {
    private dynamic data;
    private Type    provider;

    public Response(dynamic data) {
      this.data     = data;
      this.provider = guessTheProvider();
    }

    private Type guessTheProvider() {
      Type[] providers = { typeof(Pixiv), typeof(Seiga), typeof(Booru), typeof(Nijie), typeof(bcy) };

      foreach(Type provider in providers) {
        bool isTheRightAdapter = (bool) provider.GetMethod("IsTheRightAdapterFor").Invoke(null, new object[] { data });

        if(isTheRightAdapter) {
          return provider;
        }
      }

      return null;
    }

    public Sauce GetResponse() {
      return provider == null ? null : Activator.CreateInstance(provider, data);
    }
  }
}
