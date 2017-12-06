﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceNao_Windows {
  public class Result {
    public float Similarity;
        public string Thumbnail;
    public Sauce Response;

    public Result(dynamic header, dynamic data) {
      this.Similarity = (float) header.similarity;
      this.Thumbnail = (string)header.thumbnail;
            this.Response   = new Response(data).GetResponse();
    }

    public bool HasRecognizableSauce() {
      return Response != null;
    }

    public override string ToString() {
      return String.Format("Similarity: {0}\n{1}", Similarity, Response.ToString());
    }
  }
}
