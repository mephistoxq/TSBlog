using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TsBlog.Core;
using TsBlog.ViewModel.Post;

namespace TsBlog.Frontend.Extensions
{
    public static class PostExtension
    {
        /// <summary>
        /// 格式化文章的视图实体
        /// </summary>
        /// <param name="model">文章视图实体类</param>
        /// <returns></returns>
        public static PostViewModel FormatPostViewModel(this PostViewModel model)
        {
            if (model == null)
            {
                return null;
            }
            model.Summary = model.Content.CleanHtml().TruncateString(200, TruncateOptions.FinishWord | TruncateOptions.AllowLastWordToGoOverMaxLength);//去掉所有html标签，并截取指定长度字符串作为文章摘要
            return model;
        }
    }
}