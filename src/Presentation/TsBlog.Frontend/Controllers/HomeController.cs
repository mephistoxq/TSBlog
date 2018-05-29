using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TsBlog.AutoMapperConfig;
using TsBlog.Frontend.Extensions;
using TsBlog.Repositories;
using TsBlog.Services;
using TsBlog.ViewModel.Post;

namespace TsBlog.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public ActionResult Index(int? page)
        {
            //如果未登录，则跳转到登录页面
            //if (Session["user_account"] == null)
            //{
            //    return RedirectToAction("login", "account");
            //}

            page = page ?? 1;
            //var list = _postService.FindHomePagePosts();
            //var model = list.Select(x => x.ToModel().FormatPostViewModel());
            var list = _postService.FindPagedList(x => !x.IsDeleted && x.AllowShow, pageIndex: (int)page, pageSize: 10);
            var model = list.Select(x => x.ToModel().FormatPostViewModel());
            ViewBag.Pagination = new StaticPagedList<PostViewModel>(model, list.PageIndex, list.PageSize, list.TotalCount);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Post()
        {
            //如果未登录，则跳转到登录页面
            if (Session["user_account"] == null)
            {
                return RedirectToAction("login", "account");
            }

            //安装autofac前
            //var postRepository = new PostRepository();
            //var post = postRepository.FindById(1);
            //return View(post);

            //安装autofac后
            //var post = _postService.FindById(1);

            var post = _postService.FindById(1).ToModel();   //安装了AutoMapper后Post映射为PostViewModel
            return View(post);
        }
    }
}