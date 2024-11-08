﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _63CNTT4N1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Khai bao cho URL co dinh: gio-hang
            routes.MapRoute(
               name: "Giohang",
               url: "gio-hang",
               defaults: new { controller = "Giohang", action = "Index", id = UrlParameter.Optional }
           );

            //Khai bao cho URL co dinh: thanh-toan
            routes.MapRoute(
               name: "Thanhtoan",
               url: "thanh-toan",
               defaults: new { controller = "Giohang", action = "ThanhToan", id = UrlParameter.Optional }
           );

            //Khai bao cho URL co dinh: dăng-nhap
            routes.MapRoute(
               name: "DangNhap",
               url: "dang-nhap",
               defaults: new { controller = "Khachhang", action = "DangNhap", id = UrlParameter.Optional }
           );

            //Khai bao cho URL co dinh: dăng-ky
            routes.MapRoute(
               name: "DangKy",
               url: "dang-ky",
               defaults: new { controller = "Khachhang", action = "DangKy", id = UrlParameter.Optional }
           );

            //Khai bao cho URL co dinh: tim-kiem
            routes.MapRoute(
               name: "Timkiem",
               url: "tim-kiem",
               defaults: new { controller = "Timkiem", action = "Index", id = UrlParameter.Optional }
           );

            //Khai bao cho URL dong
            routes.MapRoute(
              name: "Siteslug",
              url: "{slug}",
              defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
          );

            //Gia tri mac dinh
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
