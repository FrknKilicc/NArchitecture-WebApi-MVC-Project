﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;



namespace MVCLayer
{
    public class GlobalVariables
    {
        public static HttpClient webapiclient = new HttpClient();
        static GlobalVariables()
        {
            webapiclient.BaseAddress = new Uri("https://localhost:44336/api/");
            webapiclient.DefaultRequestHeaders.Clear();
            webapiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}